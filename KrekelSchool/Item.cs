using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace KrekelSchool
{
    public interface Item
    {
        Uitlening GetUitlening();
    }
}
