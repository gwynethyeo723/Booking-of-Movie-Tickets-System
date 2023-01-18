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
    class Cinema
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int hallNo;
        public int HallNo
        {
            get { return hallNo; }
            set { hallNo = value; }
        }
        private int capacity;
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public Cinema() { }
        public Cinema (string n, int hNo, int cap)
        {
            Name = n;
            HallNo = hNo;
            Capacity = cap;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\tHall No: " + HallNo + "\tCapacity: " + Capacity;
        }
    }
}
