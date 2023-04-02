using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Meal
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        [NotMapped]
        public Dictionary<Food, double> Foods { get; set;}
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User can't be empty.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
             Foods.Add(food, weight);   
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}