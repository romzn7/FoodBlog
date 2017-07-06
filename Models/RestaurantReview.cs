using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace blog.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Range(1,5)]
        [Required]
        public int Rating { get; set; }
        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        [Display(Name = "User name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string  ReviewerName { get; set; }
        public int RestuarantId { get; set; }
    }
}