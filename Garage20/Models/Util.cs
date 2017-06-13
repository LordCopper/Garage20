using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Garage20.Models
{
   public class Util
    {
        static public int GetTotalMinutes(DateTime dt)
        {
            return (int)(DateTime.Now - dt).TotalMinutes;
        }
    }
}