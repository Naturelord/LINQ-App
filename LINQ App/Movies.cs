using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_App
{
    class Movies
    {
        public string Title { get; set; }
        public float Rating { get; set; }

        int year;
        public int Year
        {
            get
            {
                Console.WriteLine($"Returning {year} for {Title}");
                return year;
            }
            set
            {
                year = value;
            }
        }
    }
}
