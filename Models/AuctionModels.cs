using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionPortal.Models
{
    public class AuctionModels
    {
        [Required]
        [Display(Name = "PropertyId")]
        public int PropertyId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }



        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }
    public class EditAuctionModel
    {
        [Required]
        [Display(Name = "AuctionId")]
        public int AuctionId { get; set; }

        [Required]
        [Display(Name = "PropertyId")]
        public int PropertyId { get; set; }

     
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }



     
        [DataType(DataType.DateTime)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
    }


}