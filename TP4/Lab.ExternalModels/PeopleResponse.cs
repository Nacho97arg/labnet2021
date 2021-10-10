using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.External.Models
{
    /// <summary>
    /// Represents the people response from the StarWars API
    /// </summary>
    public class PeopleResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public People[] Results { get; set; }
    }
    public class People
    {
        public string Birth_Year { get; set; }
        public string Eye_Color { get; set; }
        public string Gender { get; set; }
        public string Hair_Color { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string Skin_Color { get; set; }
        }
}
