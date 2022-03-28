using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Dto.auth
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını düzgün giriniz!!!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen harf,sayı ve özel karakterlerden oluşan bir şifre oluşturunuz!!!")]
        public string Password { get; set; }

    }
}
