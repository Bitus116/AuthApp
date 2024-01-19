using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Models
{
    public class User : DataBase
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }    
    }
}
