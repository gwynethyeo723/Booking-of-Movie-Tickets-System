//============================================================
// Student Number : S10223760, S10222843
// Student Name : Tay Yuyun Gladys, Yeo Sze Yun Gwyneth
// Module Group : T10
//============================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_T10_Team4
{
    class Adult : Ticket
    {
        private bool popcornOffer;

        public bool PopcornOffer
        {
            get { return popcornOffer; }
            set { popcornOffer = value; }
        }

        public Adult() { }

        public Adult(Screening s, bool offer)
        {
            Screening = s;
            PopcornOffer = offer;
        }
        public override double CalculatePrice()
        {
            string day = Screening.ScreeningDateTime.ToString("dddd");
            List<string> weekdayList = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday" };
            bool contains = weekdayList.Contains(day);
            double price = 0.00;
            if (Screening.ScreeningType == "3D")
            {
                if (contains == true)
                {
                        price = 11.00;
                }
                else //if (contains == false)
                {
                    price = 14.00;
                }

            }
            else if (Screening.ScreeningType == "2D")
            {
                if (contains == true)
                {
                    price = 8.50;
                }
                else
                {
                    price = 12.50;
                }
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString() + "\tPopcorn Offer: " + PopcornOffer;
        }
    }
}
