using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Olympiad
    {
        public int Id { get; set; }
        public int OlympiadYear { get; set; }
        public bool OlympiadSeason { get; set; }
        public string OlympiadCountry { get; set; }
        public string OlympiadCity { get; set; }
        public List<Sport> Sports { get; set; }
	}
}
