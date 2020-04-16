using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AuctionPortal.Models
{
    public class ProppertyViewModels
    {
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "File Path")]
        public string Password { get; set; }

        [Display(Name = "Opening Bid")]
        public double RememberMe { get; set; }
    }
    public class AddProppertyViewModel
    {
        [Required]
        [Display(Name = "Address")]       
        public string Address { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Opening Bid")]
        public double OpeningBid { get; set; }


        [Display(Name = "Documents")]
        public string Documents { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        
    }
    public class newAddProppertyViewModel
    {
        [Required]
        public int PropertyID { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Opening Bid")]
        public double OpeningBid { get; set; } 
        
        [Display(Name = "Resurve:")]
        public double Reserve { get; set; } 
        


        [Display(Name = "Documents")]
        public string Documents { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }


    }

    public class deleteProppertyViewModel
    {
        [Required]
        public int PropertyID { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Opening Bid")]
        public double OpeningBid { get; set; }


        [Display(Name = "Documents")]
        public string Documents { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        
    }



}