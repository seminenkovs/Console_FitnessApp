using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercices { get; set; }
        public double CaloriesPerMinute { get; set; }

        public Activity() { }
        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty or null ", nameof(name));
            }
            if (caloriesPerMinute <= 0)
            {
                throw new ArgumentException("Calories can't be zero.", nameof(caloriesPerMinute));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
                    
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
