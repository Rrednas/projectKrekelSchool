using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrekelSchool.Models.Domain1
{
    public interface IitemRepository
    {
        Item FindBy(int itemId);
        IQueryable<Item> FindAll();
        void Add(Item item);
        void Delete(Item item);
        void SaveChanges();
    }
}
