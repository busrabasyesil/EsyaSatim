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
        [Required, MaxLength(512)]
        public string Ad { get; set; }

        [Required, MaxLength(512)]
        public string Fiyat { get; set; }

        [Required, MaxLength(512)]
        public string Aciklama { get; set; }

        [Required, MaxLength(512)]
        public string Resim { get; set; }

        [Required, MaxLength(512)]
        public string Email { get; set; }
        
        [Required, MaxLength(512)]
        public string Kategori_id { get; set; }

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

        [Required, MaxLength(128)]
        public string Resim { get; set; }

        [Required, MaxLength(128)]
        public string Kategori { get; set; }


    }
}