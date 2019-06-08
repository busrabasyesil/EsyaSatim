using EsyaSatim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsyaSatim.ViewModels
{
    
        public class MesajlarIndex
        {
            public IEnumerable<Mesajlar> Mesajlar { get; set; }
        }

        public class MesajlarYeni
        {
            public string Gonderen_id { get; set; }
            public string Alici_id { get; set; }
            public string Mesaj { get; set; }
            [Required, DataType(DataType.Date)]
            public string Tarih { get; set; }

    }
    
}