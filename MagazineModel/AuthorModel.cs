using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MagazineModel
{
    [DataContract]
    [Serializable]
    public class AuthorModel
    {
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string AuthorName { get; set; }

        [DataMember]
        [Required]
        public DateTime Birthday { get; set; }

        [DataMember]
        [Required]
        public string Email { get; set; }

        [DataMember]
        [Required]
        public string WorkShop { get; set; }
       
        public int ArticleId { get; set; }

        public virtual ArticleModel Article { get; set; }
    }
}
