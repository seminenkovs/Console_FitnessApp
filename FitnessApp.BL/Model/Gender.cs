using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// User Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Gender() { }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can not be empty", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}