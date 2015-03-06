﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KrekelSchool.Models.Domain1;

namespace KrekelSchool.Models.DAL
{
    public class ItemRepository : IitemRepository
    {
        private KrekelSchoolContext context;
        private DbSet Items;
        public DbSet<Boek> Boeken;
        public DbSet<Cd> Cds;
        public DbSet<Dvd> Dvds;
        public DbSet<Spel> Spellen;
        public DbSet<Verteltas> Verteltassen;
        private string Soort { get; set; }



        public ItemRepository(KrekelSchoolContext context, string soort)
        {
            this.context = context;
           // items = context.Items;
            Soort = soort;
            switch (Soort)
            {
                case "Boeken":
                    Items = context.Boeken;
                    break;
                case "Cd":
                    Items = context.Cds;
                    break;
                case "Dvd":
                    Items = context.Dvds;
                    break;
                case "Verteltassen":
                    Items = context.Verteltassen;
                    break;
                case "Spellen":
                    Items = context.Spellen;
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
            return (IQueryable < Item >) Items;
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
            context.SaveChanges();
        }
    }
}