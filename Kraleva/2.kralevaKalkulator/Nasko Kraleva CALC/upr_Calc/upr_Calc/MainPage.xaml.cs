using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace upr_Calc
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }  

        private void tbFirst_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFirst.SelectAll();
        }

        private void tbSecond_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbSecond.SelectAll();
        }

        private void calcPlus()
        {
            float n1 = float.Parse(tbFirst.Text);
        
            float n2 = float.Parse(tbSecond.Text);

            float result = n1 + n2;

            tbResult.Text = tbFirst.Text + " + " + tbSecond.Text + " = " + result.ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            calcPlus();
        }



        private void calcMinus()
        {
            float n1 = float.Parse(tbFirst.Text);

            float n2 = float.Parse(tbSecond.Text);

            float result = n1 - n2;

            tbResult.Text = tbFirst.Text + " - " + tbSecond.Text + " = " + result.ToString();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            calcMinus();
        }



        private void calcMult()
        {
            float n1 = float.Parse(tbFirst.Text);

            float n2 = float.Parse(tbSecond.Text);

            float result = n1 * n2;

            tbResult.Text = tbFirst.Text + " * " + tbSecond.Text + " = " + result.ToString();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            calcMult();
        }




        private void calcDiv()
        {
            float n1 = float.Parse(tbFirst.Text);

            float n2 = float.Parse(tbSecond.Text);

            if (n2 != 0)
            {
                float result = n1 / n2;
                tbResult.Text = tbFirst.Text + " / " + tbSecond.Text + " = " + result.ToString();
            }
            else
            {
                tbResult.Text = "Division by 0 is impossible!";
                tbSecond.Focus();
            }

           

            
        }
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            calcDiv();
        }


        private void tbFirst_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSecond.SelectAll();
        }


        private void tbSecond_GotFocus(object sender, RoutedEventArgs e)
        {
            tbSecond.SelectAll();
        }


    }
}