using System;
using System.ComponentModel.DataAnnotations;

namespace VIATECH.Models
{
    public abstract class Order
    {
        public virtual Guid id { get; set; }

        [Display(Name = "Имя")]
        public virtual string? Name { get; set; }

        [Display(Name = "Почта")]
        public virtual string? Email { get; set; }

        [Display(Name = "Сообщения")]
        public virtual string? Message { get; set; }
    }
}
