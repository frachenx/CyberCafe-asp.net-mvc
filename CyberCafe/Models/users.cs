//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CyberCafe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        public int user_id { get; set; }
        public string computer_id { get; set; }
        public string user_name { get; set; }
        public string user_address { get; set; }
        public string user_number { get; set; }
        public string user_email { get; set; }
        public string user_id_proof { get; set; }
        public Nullable<System.DateTime> user_in_time { get; set; }
        public Nullable<System.DateTime> user_out_time { get; set; }
        public string user_status { get; set; }
        public Nullable<double> user_fee { get; set; }
        public string user_remark { get; set; }
    }
}
