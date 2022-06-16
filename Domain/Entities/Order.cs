using System.ComponentModel.DataAnnotations;

namespace VIATECH.Models
{
    public abstract class Order
    {
        public virtual Guid id { get; set; }

        [Required]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Message { get; set; }

    }
}
