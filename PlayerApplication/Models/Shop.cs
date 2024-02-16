using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerApplication.Models
{
    [Table("shops")]
    public class Shop
    {
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]    
        public string Name { get; set; }


        [Column("inventory_id")]
        public string InventoryId { get; set; }
        public Inventory Inventory { get; set; }
    }
}
