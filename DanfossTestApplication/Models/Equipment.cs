using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DanfossTestApplication.Models
{
    public class Equipment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(6,18,ErrorMessage ="Артикул должен содержать от 6 до 18 символов")]
        [Display(Name = "Артикул оборудования")]
        public string VendorCode { get; set; }
        [StringLength(100)]
        [Display(Name = "Описание оборудования")]
        public string Description { get; set; }

        [Range(0,15000,ErrorMessage = "Цена должна быть в диапазоне от 0 до 15000")]
        [Display(Name = "Цена")]
        [Column(TypeName ="decimal(5,2)")]
        public double Cost { get; set; }
        [Display(Name = "На складе")]
        public bool OnWarehouse { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
