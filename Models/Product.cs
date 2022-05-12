using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiProjectTest.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string img { get; set; }

        [ForeignKey("category")]
        public int CategoryID { get; set; }

        [JsonIgnore]
        public virtual Category category { get; set; }
    }
}
