using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {

        public int Id { get; set; }


        //because it's nullable by convention 
        [Required]
        public ApplicationUser Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)] //limit length instead of MAX by convention
        public string Venue { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }

    
}