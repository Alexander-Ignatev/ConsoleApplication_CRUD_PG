using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4.Models
{
    [Table("products")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("userid")]
        public int UserId { get; set; }

        [Column("shortname")]
        public string? ShortName { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("categoriesid")]
        public int CategoriesId { get; set; }
        public override string ToString()
        {
            return @$"ID: {Id + Environment.NewLine}
                    Название: {ShortName + Environment.NewLine}
                    Описание: {Description + Environment.NewLine}
                    Цена: {Price + Environment.NewLine}
                    ID Продавца: {UserId + Environment.NewLine}
                    ID Категории:{CategoriesId}";

        }
    }
}
