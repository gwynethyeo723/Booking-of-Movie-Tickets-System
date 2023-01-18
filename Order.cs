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
    class Order
    {
        private int orderNo;
        public int OrderNo
        {
            get { return orderNo; }
            set { orderNo = value; }
        }
        private DateTime orderDateTime;
        public DateTime OrderDateTime
        {
            get { return orderDateTime; }
            set { orderDateTime = value; }
        }
        private double amount;
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public List<Ticket> ticketList { get; set; } = new List<Ticket>();

        public Order() { }
        public Order (int oNo, DateTime odate)
        {
            OrderNo = oNo;
            OrderDateTime = odate;
        }
        public void AddTicket(Ticket t)
        {
            ticketList.Add(t);
        }
        public override string ToString()
        {
            return "Order Number: " + OrderNo + "\tOrder Date Time: " + OrderDateTime + "\tAmount: " + Amount + "\tStatus: " + Status;
        }
    }
}
