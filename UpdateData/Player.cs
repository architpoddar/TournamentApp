using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateData
{
    public class Player
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Building { get; set; }
        public string FlatNo { get; set; }
        public string MobileNo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ShirtSize { get; set; }
        public string ShirtName { get; set; }
        public string ShirtNumber { get; set; }
        public string PictureUrl { get; set; }
        public string Expertise { get; set; }

        public List<string> Sports { get; set; }

        public bool IsMensCricket { get; set; }
        public bool IsBoxCricket { get; set; }
        public bool IsLadiesCricket { get; set; }
        public bool IsTeensCricket { get; set; }
        public bool IsU12BoysCricket { get; set; }
        public bool IsU13GirlsCricket { get; set; }
        public bool IsFootball { get; set; }
        public bool IsVolleyball { get; set; }
        public bool IsBadminton { get; set; }

        public int ExpectedPayment { get; set; }
        public int AmountPaid { get; set; }

        public string PaidTo { get; set; }
    }
}
