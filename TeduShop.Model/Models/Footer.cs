using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeduShop.Model.Models
{
    /// <summary>
    /// Bảng Footer chứa các thông tin trên footer
    /// </summary>
    [Table("Footers")]
    public class Footer
    {
        /// <summary>
        /// Trường ID của nội dung, thuộc tính key cho biết trường này sẽ được sinh ra tự động khi tạo bản ghi
        /// </summary>
        [Key]
        [MaxLength(50)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        /// <summary>
        /// Trường Content, thuộc tính Require chỉ rằng trường này là bắt buộc
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}