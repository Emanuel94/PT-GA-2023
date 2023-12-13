using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceMedico.Class
{
    public class Articulo
    {
        [DataMember(Order = 0)]
        public int IdArticulo { get; set; } 

        [DataMember(Order = 2)]
        public string Descripcion { get; set; }


        [DataMember(Order = 3)]
        public int IdMarca { get; set; }

        [DataMember(Order = 4)]
        public string Sku { get; set; }

    }
}