using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrekelSchool.Models.Domain1
{
    public interface IitemRepository
    {
    }

    public interface IboekRepository
    {
        Boek FindBy(int itemId);
        IQueryable<Boek> FindAll();
        void Add(Boek boek);
        void Delete(Boek boek);
        void SaveChanges();
    }

    public interface IcdRepository
    {
        CD FindBy(int itemId);
        IQueryable<CD> FindAll();
        void Add(CD cd);
        void Delete(CD cd);
        void SaveChanges();
    }

    public interface IdvdRepository
    {
        DVD FindBy(int itemId);
        IQueryable<DVD> FindAll();
        void Add(DVD dvd);
        void Delete(DVD dvd);
        void SaveChanges();
    }

    public interface IspelRepository
    {
        Spel FindBy(int itemId);
        IQueryable<Spel> FindAll();
        void Add(Spel spel);
        void Delete(Spel spel);
        void SaveChanges();
    }

    public interface IverteltasRepository
    {
        Verteltas FindBy(int itemId);
        IQueryable<Verteltas> FindAll();
        void Add(Verteltas vt);
        void Delete(Verteltas vt);
        void SaveChanges();
    }
}
