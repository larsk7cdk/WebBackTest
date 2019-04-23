using System;
using System.ComponentModel.DataAnnotations;

namespace WebBackTest.web.ApplicationCore.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}