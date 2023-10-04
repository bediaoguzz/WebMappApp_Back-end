using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMappApplication.Model
{
    [Table ("door")]
    public class Door
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

       
    }
}
