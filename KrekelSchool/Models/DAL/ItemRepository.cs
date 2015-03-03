using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class ItemRepository : IitemRepository
    {
        private KrekelSchoolContext kc;
        private DbSet Items;

        private string Soort;


        public ItemRepository(KrekelSchoolContext context, string soort)
        {
            kc = context;
            Soort = soort;
            switch (Soort)
            {
                case "Boeken":
                    Items = kc.Boeken;
                    break;
                case "Cd":
                    Items = kc.Cds;
                    break;
                case "Dvd":
                    Items = kc.Dvds;
                    break;
                case "Verteltassen":
                    Items = kc.Verteltassen;
                    break;
                case "Spellen":
                    Items = kc.Spellen;
                    break;
                default:
                    throw new Exception("geen Id meegegeven");
            }
            
        }

        
        public Item FindBy(string itemId)
        {
            return (Item) Items.Find(itemId);
        }

        public IQueryable<Item> FindAll()
        {
            return  (IQueryable<Item>) Items;
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Delete(Item item)
        {
            Items.Remove(item);
        }

        public void SaveChanges()
        {
            kc.SaveChanges();
        }
    }
}