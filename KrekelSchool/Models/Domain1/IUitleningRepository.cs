using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrekelSchool.Models.Domain1
{
    public interface IUitleningenRepository
    {
        Uitlening FindBy(int itemId);
        
        IQueryable<Uitlening> FindAll();
        void Add(Uitlening uitlening);
        void Delete(Uitlening uitlening);
        void SaveChanges();
    }
}
