using System;
using System.ComponentModel.DataAnnotations;

namespace VIATECH.Domain.Entities
{
    public class Order
    {
        public Guid id { get; set; }

        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Display(Name = "Почта")]
        public string? Email { get; set; }

        [Display(Name = "Сообщения")]
        public string? Message { get; set; }
    }
}
