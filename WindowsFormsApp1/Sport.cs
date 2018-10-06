using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Sport
    {
        public int Id { get; set; }
        public string SportName { get; set; }
        public string SportInfo { get; set; }
        public int SportPersonCount { get; set; }

        public int OlympiadId { get; set; }
        public List<Person> Persons { get; set; }
    }
}
