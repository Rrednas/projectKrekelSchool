using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrekelSchool.Models.Domain1
{
    public interface ILeerlingrepository
    {
        Leerling FindBy(int itemId);
        IQueryable<Leerling> FindAll();
        void Add(Leerling leerling);
        void Delete(Leerling leerling);
        void SaveChanges();
    }
}
