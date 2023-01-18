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
    class Movie : IComparable<Movie>
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private int duration;
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        private string classification;
        public string Classification
        {
            get { return classification; }
            set { classification = value; }
        }
        private DateTime openingDate;
        public DateTime OpeningDate
        {
            get { return openingDate; }
            set { openingDate = value; }
        }
        
        public List<string> genreList { get; set; } = new List<string>();
        public List<Screening> screeningList { get; set; } = new List<Screening>();

        private int ticketSold;

        public int TicketSold
        {
            get { return ticketSold; }
            set { ticketSold = value; }
        }


        public Movie() { }
        public Movie(string t, int d, string c, DateTime odate, List<string>gList)
        {
            Title = t;
            Duration = d;
            Classification = c;
            OpeningDate = odate;
            genreList = gList;
        }
        public void AddGenre(string g)
        {
            genreList.Add(g);
        }
        public void AddScreening(Screening screen )
        {
            screeningList.Add(screen);
        }

        public int CompareTo(Movie m)
        {
            if (TicketSold < m.TicketSold)
            {
                return 1;
            }
                
            else if (TicketSold == m.TicketSold)
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
            return "Title: " + Title + "\tDuration: " + Duration + "\tClassification: " + Classification + "\tOpening Date: " + OpeningDate.ToString("MM/dd/yyyy");
        }
    }
}
