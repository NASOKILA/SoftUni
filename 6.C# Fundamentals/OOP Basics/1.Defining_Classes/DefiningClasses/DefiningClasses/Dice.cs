namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Dice
    {

        //Tova ni e poleto
        private int sizes;

        public Dice()
        {

        }

        public Dice(int sizes)
        {
            this.sizes = sizes;
        }

        

        public int Sizes
        {
         
            get
            {

                return sizes;
            }
            set
            {

                sizes = value;
                if (sizes < 6 ||sizes > 6)
                {
                    throw new ArgumentException($"A dice cannot have {sizes} sizes!");
                }
                
                this.sizes = value;
            }
        }


    }
}
