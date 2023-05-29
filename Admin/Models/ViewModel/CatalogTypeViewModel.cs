using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models.ViewModel
{
    public class CatalogTypeViewModel
    {
       public int Id { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required]
        [MaxLength(100, ErrorMessage = "حداکثر باید 100 کاراکتر باشد")]
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }

//        public List<String> Message { get; set; } = new List<string>();
    }
}
