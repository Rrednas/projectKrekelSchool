using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;

namespace KrekelSchool.Controllers
{
    public class BoekController : Controller
    {
        //private IboekRepository BoekRepository;
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public BoekController(MediatheekRepository repos)
        {
            
            MediatheekRepository = repos;
            Mediatheek = repos.GetMediatheek();
        }

        [HttpGet]
        public ActionResult Boek(string zoek,VoorlopigeUitlening voorlopige,User user)
       {
            ViewBag.Title = "Boeken-Lijst";
            ViewBag.Message = "Geef ID, naam,... in als zoekcriteria.";
            IEnumerable<Boek> boeken = Mediatheek.Boeks.AsEnumerable();
                //BoekRepository.FindAll().OrderBy(b => b.Naam);
            IEnumerable<BoekViewModel> bvm = boeken.Select(b => new BoekViewModel(b)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                bvm = bvm.Where(b => b.Naam.ToLower().Contains(zoek.ToLower()) ||
                    b.Leeftijd.ToString().Contains(zoek.ToLower()));
            }
            return View(new ItemScreenViewModel(voorlopige,bvm,user));
        }

        [HttpPost]
        public ActionResult Boek(HttpPostedFileBase file)
        {
            DataSet dataSet = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Excel/") + Request.Files["file"].FileName;

                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR = Yes;IMEX=2\"";

                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                                fileLocation + ";Extended Properties=\"Excel 8.0;HDR = Yes;IMEX=2\"";
                    }

                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                fileLocation + ";Extended Properties=\"Excel 12.0;HDR = Yes;IMEX=2\"";
                    }

                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dataTable = new DataTable();

                    dataTable = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dataTable == null)
                    {
                        return null;
                    }

                    String[] excelsSheets = new String[dataTable.Rows.Count];
                    int i = 0;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        excelsSheets[i] = row["TABLE_NAME"].ToString();
                        i++;
                    }

                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);

                    string query = string.Format("Select * from [{0}]", excelsSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(dataSet);
                    }
                }

                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Excel/") + Request.Files["FileUpload"].FileName;

                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlReader = new XmlTextReader(fileLocation);

                    dataSet.ReadXml(xmlReader);
                    xmlReader.Close();
                }


                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    if (Mediatheek.LenerBestaat(dataSet.Tables[0].Rows[i][0].ToString(),
                        dataSet.Tables[0].Rows[i][1].ToString()) == false)
                    {
                        bool beschikbaar = dataSet.Tables[0].Rows[i][1].Equals("ja");
                        int leeftijd = (int) dataSet.Tables[0].Rows[i][3];
                        Categorie cat = new Categorie(dataSet.Tables[0].Rows[i][5].ToString());

                        Mediatheek.VoegBoekToe(new Boek(dataSet.Tables[0].Rows[i][0].ToString(),
                             beschikbaar,
                             dataSet.Tables[0].Rows[i][2].ToString(),
                             leeftijd,
                             dataSet.Tables[0].Rows[i][4].ToString(),
                             cat,
                             dataSet.Tables[0].Rows[i][6].ToString(),
                             dataSet.Tables[0].Rows[i][7].ToString(),
                             dataSet.Tables[0].Rows[i][8].ToString()));
                        MediatheekRepository.SaveChanges();
                    }

                    //string connection = ConfigurationManager.ConnectionStrings["projecten2"].ConnectionString;
                    //MySqlConnection connect = new MySqlConnection(connection);
                    //string query =
                    //    "INSERT INTO Leerlingen(Naam,Voornaam,Straat,HuisNr,Postcode,Gemeente,Email,Klas) " +
                    //    "Values(@NAAM, @VOORNAAM, @STRAAT, @HUISNR, @POSTCODE, @GEMEENTE, @EMAIL, @KLAS)";

                    //connect.Open();
                    //MySqlCommand command = new MySqlCommand(query, connect);
                    //command.Parameters.AddWithValue("@NAAM", dataSet.Tables[0].Rows[i][0].ToString());
                    //command.Parameters.AddWithValue("@VOORNAAM", dataSet.Tables[0].Rows[i][1].ToString());
                    //command.Parameters.AddWithValue("@STRAAT", dataSet.Tables[0].Rows[i][2].ToString());
                    //command.Parameters.AddWithValue("@HUISNR", dataSet.Tables[0].Rows[i][3].ToString());
                    //command.Parameters.AddWithValue("@POSTCODE", dataSet.Tables[0].Rows[i][4].ToString());
                    //command.Parameters.AddWithValue("@GEMEENTE", dataSet.Tables[0].Rows[i][5].ToString());
                    //command.Parameters.AddWithValue("@EMAIL", dataSet.Tables[0].Rows[i][6].ToString());
                    //command.Parameters.AddWithValue("@KLAS", dataSet.Tables[0].Rows[i][7].ToString());
                    //command.ExecuteNonQuery();
                    //connect.Close();
                }

            }
            return RedirectToAction("Boek");
        }

        public ActionResult BoekDetail(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message = boek.Naam;
            return PartialView(new BoekViewModel(boek));
        }

        #region Boek Toevoegen
        [HttpGet]
        public ActionResult BoekToevoegen()
        {
            Boek boek = new Boek();
            ViewBag.Title = "Boek toevoegen";
            return PartialView(new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult BoekToevoegen(BoekViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boek boek = new Boek();
                    MapToBoek(bvm,boek);
                    Mediatheek.VoegBoekToe(boek);
                    MediatheekRepository.SaveChanges();
                  //  BoekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", boek.Naam);
                    return RedirectToAction("Boek");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return PartialView(bvm); 
        }
        #endregion


        [HttpGet]
        public ActionResult BoekAanpassen(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + boek.Naam + " aanpassen";
            return PartialView("BoekToevoegen", new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult BoekAanpassen(int id, BoekViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
                    MapToBoek(bvm, boek);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", boek.Naam);
                    return RedirectToAction("Boek");
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {

                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);

                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return PartialView("BoekToevoegen",bvm);
        }

        [HttpGet]
        public ActionResult BoekVerwijderen(int id)
        {
            Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Title = "Boek: " + boek.Naam + " verwijderen";
            return PartialView(new BoekViewModel(boek));
        }

        [HttpPost, ActionName("BoekVerwijderen")]
        public ActionResult BoekVerwijderenBevestig(int id)
        {
            try
            {
                Boek boek = Mediatheek.Boeks.First(b => b.Id == id);
                if (boek == null)
                    return HttpNotFound();
                Mediatheek.VerwijderBoek(boek);
                MediatheekRepository.SaveChanges();
                TempData["Message"] = String.Format("{0} werd verwijderd!", boek.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Boek");
        }

        private void MapToBoek(BoekViewModel bvm, Boek boek)
        {
            boek.Naam = bvm.Naam;
            boek.Leeftijd = bvm.Leeftijd;
            boek.Isbn = bvm.Isbn;
            boek.Uitgever = bvm.Uitgever;
            boek.Auteur = bvm.Auteur;
            boek.Beschikbaar = bvm.Beschikbaar;
            boek.Beschrijving = bvm.Beschrijving;
            boek.ImgUrl = bvm.ImgUrl;
            boek.Categorie = bvm.Categorie;
        }
        public ActionResult KiesVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(Mediatheek.Boeks.First(b => b.Id == id));
            return RedirectToAction("Boek");
        }

        public ActionResult VerwijderVoorlopigItem(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesItem(null);
            return RedirectToAction("Boek");
        }
        public ActionResult VerwijderVoorlopigeLener(VoorlopigeUitlening voorlopige, int id)
        {
            voorlopige.KiesLener(null);
            return RedirectToAction("Boek");
        }
        public ActionResult AanvaardUitlening(VoorlopigeUitlening voorlopige)
        {
            Mediatheek.VoegUitleningBoekToe(voorlopige.VoorlopigeLener, voorlopige.VoorlopigItem);
            MediatheekRepository.SaveChanges();
            voorlopige.Clear();
            TempData["Succes"] = "Uitlening succesvol aangemaakt";
            return RedirectToAction("Boek");
        }

    }
}