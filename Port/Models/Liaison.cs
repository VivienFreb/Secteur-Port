using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Port.Models
{
    public class Liaison
    {
        public int IdLiaison { get; set; }
        public int IdPortArrive { get; set; }
        public int IdPortDepart { get; set; }
        public int IdSecteur { get; set; }
        public int Distance { get; set; }


    }
}