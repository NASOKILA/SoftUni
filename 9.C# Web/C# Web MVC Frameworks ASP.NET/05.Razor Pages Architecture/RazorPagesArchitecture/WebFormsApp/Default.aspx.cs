using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //it creates the properties for us on the backend
        protected void SumNumbers_Click(object sender, EventArgs e)
        {
            int first = int.Parse(this.FirstNumber.Text);
            int second = int.Parse(this.SecondNumber.Text);

            int sum = first + second;
            this.Result.Text = sum.ToString();
        }
    }
}