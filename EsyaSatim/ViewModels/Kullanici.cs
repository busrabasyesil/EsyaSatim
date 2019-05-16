using EsyaSatim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsyaSatim.ViewModels
{
    public class KullaniciIndex
    {
        public IEnumerable<Kullanici> Kullanicis { get; set; }
    }

    public class KullaniciYeni
    {
        [Required, MaxLength(512)]
        public string Ad { get; set; }

        [Required, MaxLength(512)]
        public string Soyad { get; set; }

        [Required, DataType(DataType.Password)]
        public string Sifre { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(512)]
        public string Email { get; set; }
    }


}