using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab.MVC.Models
{
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
        public string[] Films { get; set; }
        public string Gender { get; set; }
        public string Hair_Color { get; set; }
        public string Height { get; set; }
        public string Homeworld { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string Skin_Color { get; set; }
        public string Created { get; set; }
        public string Edited { get; set; }
        public string[] Species { get; set; }
        public string[] Starships { get; set; }
        public string Url { get; set; }
        public string[] Vehicles { get; set; }
    }
}
