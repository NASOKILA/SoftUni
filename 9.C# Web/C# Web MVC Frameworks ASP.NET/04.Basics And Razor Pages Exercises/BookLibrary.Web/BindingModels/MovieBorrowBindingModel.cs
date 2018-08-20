using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Web.BindingModels
{
    public class MovieBorrowBindingModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 symbols.")]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Address is required.")]
        [MinLength(3, ErrorMessage = "Address must be atleast 3 symbols.")]
        public string Address { get; set; }

        [BindProperty]
        [DataType(DataType.Date, ErrorMessage = "The type of StartDate has to be a date.")]
        [Required(ErrorMessage = "StartDate is required.")]
        public DateTime StartDate { get; set; }

        [BindProperty]
        [DataType(DataType.Date, ErrorMessage = "The type of EndDate has to be a date.")]
        [Required(ErrorMessage = "EndDate is required.")]
        public DateTime? EndDate { get; set; }
    }
}
