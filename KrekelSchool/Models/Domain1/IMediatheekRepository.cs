using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace KrekelSchool.Models.Domain1
{
    public interface IMediatheekRepository
    {
        Mediatheek GetMediatheek();
        void SaveChanges();

    }
}