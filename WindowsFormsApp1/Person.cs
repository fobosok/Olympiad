using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonCountry { get; set; }
        public DateTime PersonDateOfBirthday { get; set; }

        public int SportId { get; set; }
        public List<Result> Results { get; set; }
    }
}
