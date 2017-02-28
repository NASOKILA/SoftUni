using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nakov.TurtleGraphics;


namespace Chertane_na_spiralen_triugulnik_s_kostenurka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            Turtle.PenColor = Color.Red;
            var lenght = 5;
            for (var i = 0; i < 22; i++){

                Turtle.Forward(lenght);
                Turtle.Rotate(120);
                lenght += 10;

            }
        }
    }
}
