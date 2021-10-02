using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
    public class SupplierView
    {
        [Key]
        public int SupplierID { get; set; }
        
        [Required(ErrorMessage ="Company Name is required")]
        [StringLength(40, ErrorMessage = "Company name should be 40 characters maximum")]
        public string CompanyName { get; set; }
        
        [StringLength(60, ErrorMessage = "Address should be 60 characters maximum")]
        public string Address { get; set; }
        
        [StringLength(15, ErrorMessage = "City should be 15 characters maximum")]
        public string City { get; set; }
    }
}