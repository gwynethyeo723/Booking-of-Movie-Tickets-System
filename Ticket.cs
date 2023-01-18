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
    abstract class Ticket 
    {
        private Screening screening;

        public Screening Screening
        {
            get { return screening; }
            set { screening = value; }
        }

        public Ticket() { }

        public Ticket(Screening s)
        {
            Screening = s;
        }
        public abstract double CalculatePrice();

        public override string ToString()
        {
            return "Screening: " + Screening;
        }

    }
}
