using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    /// <summary>
    /// Bản MenuGroups chứa thông tin của nhóm các menu của trang web
    /// Created by : NVSON (6/1/2019)
    /// </summary>
    [Table("MenuGroups")]
    public class MenuGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        // Trường này trỏ tới toàn bộ menu thuộc 1 nhóm group ở bảng menugroup này
        public virtual IEnumerable<Menu> Menus { get; set; }
    }
}