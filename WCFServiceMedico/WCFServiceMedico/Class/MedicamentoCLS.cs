using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceMedico.Class
{
    [DataContract]
    public class MedicamentoCLS
    {
        [DataMember(Order = 0)]
        public int IIdMedicamento { get; set; }
        [DataMember(Order = 1)]
        public string nombre { get; set; }
        [DataMember(Order = 2)]
        public string concentracion { get; set; }
        [DataMember(Order = 3)]
        public decimal  Precio { get; set; }
        [DataMember(Order =4)]
        public int stock { get; set; }
        [DataMember(Order =5)]
        public string presentacion { get; set; }
        [DataMember(Order =6)]
        public int habilitado { get; set; }
        [DataMember(Order =7)]
        public int iidFormaFarmaceutica { get; set; }
        [DataMember(Order = 8)]
        public string nombreFormaFarmaceutica { get; set; }
    }
}   