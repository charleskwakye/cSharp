using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroExercise
{
    internal class Mymovie
    {
        public int Year { get; set; }
        public string Title { get; set; }

        private int oscars;

        public int MyProperty
        {
            get { return oscars; }
            set { oscars = value; }
        }

        public Mymovie()
        {

        }

        

    }


}
