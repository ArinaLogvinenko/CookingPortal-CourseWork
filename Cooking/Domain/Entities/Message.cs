using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public virtual User Sender { get; set; }
    }
}
