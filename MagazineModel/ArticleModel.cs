using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineModel
{
    public class ArticleModel
    {
        public int Id { get; set; }

        [Required]
        public string ArticleName { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("ArticleId")]
        public virtual List<AuthorModel> Authors { get; set; }
    }
}
