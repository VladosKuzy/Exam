using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        [DisplayName("Имя автора")]
        public string AuthorName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime Birthday { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Издательство")]
        public string WorkShop { get; set; }
    }
}
