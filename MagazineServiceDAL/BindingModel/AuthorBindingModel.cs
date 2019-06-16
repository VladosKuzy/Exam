using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.BindingModel
{
    public class AuthorBindingModel
    {
        public int Id { get; set; }

        public int ArticleId { get; set; }

        public string AuthorName { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string WorkShop { get; set; }
    }
}
