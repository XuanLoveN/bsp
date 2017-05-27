using System;
using System.ComponentModel.DataAnnotations;

namespace BSP.Model
{
    [MetadataType(typeof(BookMetaData))]
    public partial class Book
    {
        public class BookMetaData
        {
            [Display(Name = "图书编号")]
            public int Id { get; set; }
            [Display(Name = "书名"), Required(ErrorMessage = "{0}不能为空")]
            public string Title { get; set; }
            [Display(Name = "作者"), Required(ErrorMessage = "{0}不能为空")]
            public string Author { get; set; }
            [Display(Name = "出版社")]
            public int PublisherId { get; set; }
            [Display(Name = "出版日期"), Required(ErrorMessage = "{0}不能为空")]
            public DateTime PublishDate { get; set; }
            [Display(Name = "图书封面")]
            public string ISBN { get; set; }
            [Display(Name = "价格"), Required(ErrorMessage = "{0}不能为空"), Range(0, 10000, ErrorMessage = "{0}不能小于{1}")]
            public decimal UnitPrice { get; set; }
            [Display(Name = "内容描述")]
            public string ContentDescription { get; set; }
            [Display(Name = "目录")]
            public string TOC { get; set; }
            [Display(Name = "图书分类")]
            public int CategoryId { get; set; }
        }
    }
}
