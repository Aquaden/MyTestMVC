using System.ComponentModel.DataAnnotations;

namespace MyTestMVC.Datas.Entities
{
    public class Events
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime LastDate { get; set;}
    }
}
