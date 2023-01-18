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
    class Screening: IComparable<Screening>
    {
        private int screeningNo;
        private DateTime screeningDateTime;
        private string screeningType;
        private int seatsRemaining;
        private Cinema cinema;
        private Movie movie;

        public int ScreeningNo
        {
            get { return screeningNo; }
            set { screeningNo = value; }
        }
        public DateTime ScreeningDateTime
        {
            get { return screeningDateTime; }
            set { screeningDateTime = value; }
        }
        public string ScreeningType
        {
            get { return screeningType; }
            set { screeningType = value; }
        }
        public int SeatsRemaining
        {
            get { return seatsRemaining; }
            set { seatsRemaining = value; }
        }
        public Cinema Cinema
        {
            get { return cinema; }
            set { cinema = value; }
        }
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }
        public Screening() { }
        public Screening(int sno, DateTime sdate, string stype, Cinema c, Movie m )
        {
            ScreeningNo = sno;
            ScreeningDateTime = sdate;
            ScreeningType = stype;
            Cinema = c;
            Movie = m;
        }
        public int CompareTo(Screening s)
        {
            if (SeatsRemaining < s.SeatsRemaining)
            {
                return 1;
            }

            else if (SeatsRemaining == s.SeatsRemaining)
            {
                return 0;
            }

            else
            {
                return -1;
            }

        }
        public override string ToString()
        {
            return "Screening No: " + ScreeningNo + "\tScreening Date Time: " + ScreeningDateTime + "\tScreening Type: " + ScreeningType + "\tSeats Remaining: " + SeatsRemaining + "\tCinema: " + Cinema + "\tMovie: " + Movie;
        }
    }
}
