using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml;
using KrekelSchool.Models;
using KrekelSchool.Models.DAL;
using KrekelSchool.Models.Domain1;
using KrekelSchool.Models.ViewModels;
using MySql.Data.MySqlClient;

namespace KrekelSchool
{
    public class LeerlingController : Controller
    {
        //private ILeerlingRepository LeerlingRepository;
        //private KrekelSchoolContext Context;
        private MediatheekRepository MediatheekRepository;
        private Mediatheek Mediatheek;

        public LeerlingController(MediatheekRepository mediatheekRepository)
        {
            MediatheekRepository = mediatheekRepository;
            Mediatheek = mediatheekRepository.GetMediatheek();

        }

        //#region methods

        //public void KenLeningToeAan(Lener lener,Uitlening uitlening)
        //{   
        //    repos.FindBy(lener.Id).KrijgLening(uitlening);
        //    repos.SaveChanges();
        //}
        //#endregion

        //public void AddLeerling(Lener leerling)
        //{
        //    repos.Add(leerling);
        //    repos.SaveChanges();
        //}

        //public Lener getLeerling()
        //{
        //    throw new System.NotImplementedException();
        //}

        //public List<Lener>  GetLeerlingen()
        //{
        //    return repos.FindAll().ToList();
        //}

        //public void EditLeerling(Lener leerling)
        //{
        //    RemoveLeerling(repos.FindBy(leerling.Id));
        //    AddLeerling(leerling);
        //}

        //public void RemoveLeerling(Lener leerling)
        //{
        //    repos.Delete(leerling);
        //}

        //public ActionResult LenerEnUitlening(string search)
        //{
        //    ViewBag.Message = "Selecteer Lener of Uitlening";
        //    Context = new KrekelSchoolContext();
        //    return View(Context.Leerlingen.Where(n => n.Naam == search || search == null).ToList());
            
        //    //return View();
        //}

        public ActionResult LenerEnUitlening()
        {
            ViewBag.Message = "Selecteer Lener of Uitlening";

            return View();
        }

        public ActionResult Leerling(string zoek)
        {
            ViewBag.Message = "Geef ID, naam of achternaam in als zoekcriteria.";
            IEnumerable<Lener> leerlingen = Mediatheek.Leners.OrderBy(l => l.Naam);
            IEnumerable<LeerlingViewModel> lvm = leerlingen.Select(l => new LeerlingViewModel(l)).ToList();
            if (!String.IsNullOrEmpty(zoek))
            {
                lvm = lvm.Where(s => s.Naam.ToLower().Contains(zoek.ToLower()) ||
                    s.Voornaam.ToLower().Contains(zoek.ToLower()) ||
                    s.Klas.ToLower().Contains(zoek.ToLower()) ||
                    //s.Email.ToLower().Contains(zoek.ToLower()) ||
                    //s.Gemeente.ToLower().Contains(zoek.ToLower()) ||
                    //s.Straat.ToLower().Contains(zoek.ToLower()) ||
                    //s.HuisNr.ToString().Contains(zoek.ToLower()) ||
                    s.Id.ToString().Contains(zoek.ToLower()) //||
                    //s.Postcode.ToLower().Contains(zoek.ToLower())
                    );
            }
            return View(lvm);
        }

        [HttpPost]
        public ActionResult Leerling(HttpPostedFileBase file)
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
                        
                            Mediatheek.VoegLenerToe(new Lener(dataSet.Tables[0].Rows[i][0].ToString(),
                             dataSet.Tables[0].Rows[i][1].ToString(),
                             dataSet.Tables[0].Rows[i][2].ToString(),
                             dataSet.Tables[0].Rows[i][3].ToString(),
                             dataSet.Tables[0].Rows[i][4].ToString(),
                             dataSet.Tables[0].Rows[i][5].ToString(),
                             dataSet.Tables[0].Rows[i][6].ToString(),
                             dataSet.Tables[0].Rows[i][7].ToString()));
                            MediatheekRepository.SaveChanges(); 
                       
                        
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
            return RedirectToAction("Leerling");
        }

        public ActionResult LeerlingDetail(int id)
        {
            Lener leerling = Mediatheek.Leners.First(l => l.Id == id);
            if (leerling == null)
                return HttpNotFound();
            ViewBag.Title = "Details van: ";
            ViewBag.Message =  leerling.Naam + ", " + leerling.Voornaam;
            return PartialView(new LeerlingViewModel(leerling));
        }

        #region Leerling Toevoegen
        [HttpGet]
        public ActionResult LeerlingToevoegen()
        {
            Lener leerling = new Lener();
            ViewBag.Title = "Leerling toevoegen";
            return PartialView(new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult LeerlingToevoegen(LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lener leerling = new Lener();
                    MapToLeerling(lvm, leerling);
                    Mediatheek.VoegLenerToe(leerling);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", leerling.Naam);
                    return RedirectToAction("Leerling");
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
            return PartialView(lvm);
        }
        #endregion


        [HttpGet]
        public ActionResult LeerlingAanpassen(int id)
        {
            Lener leerling = Mediatheek.Leners.First(l => l.Id == id);
            if (leerling == null)
                return HttpNotFound();
            ViewBag.Title = "Leerling aanpassen";
            return PartialView("LeerlingToevoegen", new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult LeerlingAanpassen(int id, LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Lener leerling = Mediatheek.Leners.First(l => l.Id == id);
                    MapToLeerling(lvm, leerling);
                    MediatheekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd aangepast.", leerling.Naam);
                    return RedirectToAction("Leerling");
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
            return PartialView("LeerlingToevoegen", lvm);
        }

        [HttpGet]
        public ActionResult LeerlingVerwijderen(int id)
        {
            Lener leerling = Mediatheek.Leners.First(l => l.Id == id);
            if (leerling == null)
                return HttpNotFound();
            ViewBag.Title = "Leerling verwijderen";
            return PartialView(new LeerlingViewModel(leerling));
        }

        [HttpPost, ActionName("LeerlingVerwijderen")]
        public ActionResult LeerlingVerwijderenBevestig(int id)
        {
            try
            {
                Lener leerling = Mediatheek.Leners.First(l => l.Id == id);
                if (leerling == null)
                    return HttpNotFound();
                Mediatheek.VoegLenerToe(leerling);
                MediatheekRepository.SaveChanges();
                ViewBag.Title = "Leerling verwijderen";
                TempData["Message"] = String.Format("{0} {1} werd verwijderd!", leerling.Naam, leerling.Voornaam);
            }
            catch (Exception ex)
            {
                TempData["error"] = ViewBag.ErrorMessage = "Verwijderen van boek mislukt. Probeer opnieuw. " +
                           "Als de problemen zich blijven voordoen, contacteer de  administrator.";
            }
            return RedirectToAction("Leerling");
        }

        private void MapToLeerling(LeerlingViewModel lvm, Lener leerling)
        {
            leerling.Naam = lvm.Naam;
            leerling.Voornaam = lvm.Voornaam;
            leerling.Straat = lvm.Straat;
            leerling.HuisNr = lvm.HuisNr;
            leerling.Postcode = lvm.Postcode;
            leerling.Gemeente = lvm.Gemeente;
            leerling.Email = lvm.Email;
            leerling.Klas = lvm.Klas;
        }
    }
}
