using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrekelSchool.Models.Domain1
{
    public interface ILenerRepository
    {
        Lener FindBy(int itemId);
        IQueryable<Lener> FindAll();
        void Add(Lener leerling);
        void Delete(Lener leerling);
        void SaveChanges();
    }
}
