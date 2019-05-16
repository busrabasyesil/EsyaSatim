using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EsyaSatim.ViewModels
{
    public class AuthLogin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email alanı için bilgi giriniz")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }


    }
}