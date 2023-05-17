﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50), MinLength(2)]
        public string Header { get; set; } = null!;
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; } = new ApplicationUser();
        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
