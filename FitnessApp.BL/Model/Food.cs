using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Proteins in 1 grams of meal
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Fats in 1 grams of meal
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Carbohydrates in 1 grams of meal
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Calories in 1 grams of meal
        /// </summary>
        public double Calories { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }

        public Food(string name) : this(name, 0, 0, 0, 0)
        {
        }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates )
        {
            #region Conditions Check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty ot null ", nameof(name));
            }
            if (calories < 0)
            {
                throw new ArgumentException("Calories can't be zero.", nameof(calories));
            }
            if (proteins < 0)
            {
                throw new ArgumentException("Proteins can't be zero.", nameof(proteins));
            }
            if (fats < 0)
            {
                throw new ArgumentException("Fats can't be zero.", nameof(fats));
            }
            if (carbohydrates < 0)
            {
                throw new ArgumentException("Carbohydrates can't be zero.", nameof(carbohydrates));
            }
            #endregion

            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates /100.0;
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}