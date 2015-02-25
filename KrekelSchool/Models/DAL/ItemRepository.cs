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
        private DbSet<Item> items;

        public ItemRepository(KrekelSchoolContext context)
        {
            kc = context;
            items = context.items;
        }
        public Item FindBy(int itemId)
        {
            return items.Find(itemId);
        }

        public IQueryable<Item> FindAll()
        {
            return items;
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Delete(Item item)
        {
            items.Remove(item);
        }

        public void SaveChanges()
        {
            kc.SaveChanges();
        }
    }
}