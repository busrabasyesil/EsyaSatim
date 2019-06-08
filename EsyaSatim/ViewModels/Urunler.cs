using EsyaSatim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsyaSatim.ViewModels
{
    public class UrunlerIndex
    {
        public IEnumerable<Urunler> urunler { get; set; }
    }

    public class UrunlerYeni
    {
        public string Ad { get; set; }

        public string Fiyat { get; set; }

        public string Aciklama { get; set; }

        public string ResimYolu { get; set; }

        public string Email { get; set; }
        
        public int Kategori { get; set; }

        [Required, DataType(DataType.Date)]
        public string Tarih { get; set; }
        
    }


    public class UrunDuzenle
    {

        [Required, MaxLength(128)]
        public string Ad { get; set; }


        [Required, MaxLength(128)]
        public string Fiyat { get; set; }


        [Required, MaxLength(1024)]
        public string Aciklama { get; set; }

        public string ResimYolu { get; set; }

        [Required, MaxLength(128)]
        public int Kategori { get; set; }


    }
}