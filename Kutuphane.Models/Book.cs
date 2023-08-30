using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Models
{
    [Table("Books")]
    public class Book:BaseModel
    {
        public int PageCount { get; set; } = 0;
        public string? ISBM { get; set; }
        public bool IsDigital { get; set; }=false;
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }//senaryo gereği 1 kitabın 1 kategori durumu olması varsayılmıştır.
        public virtual ICollection<Author> Authors { get; set; }=new List<Author>();
        public virtual ICollection<Publisher> Publishers { get; set; }=new List<Publisher>();


    }
}
