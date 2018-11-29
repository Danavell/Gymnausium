using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Layer
{
    public class Filters
    {
        public int? Min_Age { get; set; }
        public int? Max_age { get; set; }
        public int? Min_Weight { get; set; }
        public int? Max_weight { get; set; }
        public string Gender { get; set; }
        public Filters() { }
        public Filters(int min_age, int max_age, int min_weight, int max_weight, string gender)
        {
            Min_Age = min_age;
            Max_age = max_age;
            Min_Weight = min_weight;
            Max_weight = max_weight;
            Gender = gender;
        }
    }
}
