using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project_4_CampusLearn.ViewModels
{
    internal class AuthVms
    {
        public class LoginVm
        {
            [Required, EmailAddress] public string Email { get; set; } = "";
            [Required, DataType(DataType.Password)] public string Password { get; set; } = "";
        }

        public class RegisterVm
        {
            [Required] public string FullName { get; set; } = "";
            [Required, EmailAddress] public string Email { get; set; } = "";
            [Required, DataType(DataType.Password)] public string Password { get; set; } = "";
            public bool IsTutor { get; set; }
        }
    }
}
