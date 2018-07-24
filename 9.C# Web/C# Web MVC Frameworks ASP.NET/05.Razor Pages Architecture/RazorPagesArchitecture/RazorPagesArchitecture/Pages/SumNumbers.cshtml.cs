
namespace RazorPagesArchitecture.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class SumNumbersModel : PageModel
    {
        [BindProperty]
        public int FirstNumber { get; set; }

        [BindProperty]
        public int SecondNumber { get; set; }

        public int Sum { get; set; }
        
        public void OnGet()
        {
        }
        
        public void OnPostSumNumbers(string NumberOne, string NumberTwo) {
            
            this.Sum = this.FirstNumber + this.SecondNumber;
            
            //We dont have to use the ViewData[""], insted we can use the Model itself in the View !!!
        }

        public void OnPostIncrementSum() {
            //It does not work tht easy we need to save the current sum somewhrere, in a separate class
            this.Sum++;
        }

    }
}