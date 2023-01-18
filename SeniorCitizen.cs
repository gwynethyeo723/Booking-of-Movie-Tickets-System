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
    class SeniorCitizen : Ticket
    {
        private int yearOfBirth;

        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set { yearOfBirth = value; }
        }

        public SeniorCitizen() { }

        public SeniorCitizen(Screening s, int year)
        {
            Screening = s;
            YearOfBirth = year;
        }
        public override double CalculatePrice()
        {
            string day = Screening.ScreeningDateTime.ToString("dddd");
            List<string> weekdayList = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday" };
            bool contains = weekdayList.Contains(day);

            double price = 0.00;
            if (Screening.ScreeningType == "3D")
            {
                if ((Screening.ScreeningDateTime - Screening.Movie.OpeningDate).Days < 7)
                {
                    if (contains == true)
                    {
                        price = 11.00;
                    }
                    else
                    {
                        price = 14.00;
                    }
                }
                else
                {
                    if (contains == true)
                    {
                        price = 6.00;
                    }
                    else
                    {
                        price = 14.00;
                    }                  
                }
            }
            else if (Screening.ScreeningType == "2D")
            {
                if ((Screening.ScreeningDateTime - Screening.Movie.OpeningDate).Days < 7)
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
                else
                {
                    if (contains == true)
                    {
                        price = 5.00;
                    }
                    else
                    {
                        price = 12.50;
                    }                 
                }
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString() + "\tYear Of Birth: " + YearOfBirth;
        }

    }
}
