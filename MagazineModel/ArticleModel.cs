using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MagazineModel
{
    [DataContract]
    [Serializable]
    public class ArticleModel
    {
        public int Id { get; set; }
 
        [DataMember]
        [Required]
        public string ArticleName { get; set; }

        [DataMember]
        [Required]
        public string Theme { get; set; }

        [DataMember]
        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("ArticleId")]
        public virtual List<AuthorModel> Authors { get; set; }
    }
}
