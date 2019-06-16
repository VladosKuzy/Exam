using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineModel
{
    public class AuthorModel
    {
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string WorkShop { get; set; }
       
        public int ArticleId { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}
