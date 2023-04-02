using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// App user
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        public int? GenderId { get; set; }
        /// <summary>
        /// User Gender
        /// </summary>
        public virtual Gender Gender { get; set; }
        /// <summary>
        /// User Date of Birth
        /// </summary>
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        /// <summary>
        /// User Weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User Height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// User Age
        /// </summary>
        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                int age = now.Year - DateOfBirth.Year;
                if (DateOfBirth > now.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        #endregion

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name"> user name</param>
        /// <param name="gender">user gender</param>
        /// <param name="dateOfBirhday">user date of birthday</param>
        /// <param name="weight">user weight</param>
        /// <param name="height">user height</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public User(string name, Gender gender, DateTime dateOfBirth, double weight, double height)
        {
            #region Conditions Check

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty ot null ", nameof(name));
            }

            if (gender ==  null)
            {
                throw new ArgumentNullException("Gender can not be empty ot null ", nameof(gender));
            }

            if (dateOfBirth < DateTime.Parse("01.01.1900") || dateOfBirth >= DateTime.Now)
            {
                throw new ArgumentException("Wrong date of birthday", nameof(dateOfBirth));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight can not be less or equal to zero", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height can not be less or equal to zero", nameof(height));
            }

            #endregion
           
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty ot null ", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}