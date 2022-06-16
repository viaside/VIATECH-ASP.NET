using System;
using System.ComponentModel.DataAnnotations;

namespace VIATECH.Domain.Entities
{
    public abstract class EntityBase
    {
        public virtual Guid? Id { get;set; }


        [Display(Name = "Название (заголовок)")]
        public virtual string? Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string? Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string? Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public virtual string? TitleImagePath { get; set; }
        
        [Display(Name = "Метатег")]
        public virtual string? MetaTitle { get; set; }
        
    }
}
