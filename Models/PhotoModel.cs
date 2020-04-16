using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuctionPortal.Models
{
    public class PhotoModel
    {

        [Required]
        public int ImageID { get; set; }

        [Required]
        public int PropertyID { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string Path { get; set; }
    }
    public class Photo
    {

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string Path { get; set; }
    }
}