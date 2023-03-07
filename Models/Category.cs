using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork_4.Models
{
    [Table("categories")]
    public class Category
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("parentid")]
        public int? ParentId { get; set; }

        [Column("shortname")]
        public string? ShortName { get; set; }

        public override string ToString()
        {
            string parentIdStr = ParentId == 0 ? "Отсутствует родительскаяч категория" : $"Принадлежит к категории с ID:{ParentId}";
            return @$"ID:{Id} || {ShortName} , {parentIdStr}";
        }
    }
}
