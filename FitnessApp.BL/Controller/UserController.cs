using System;
using System.Collections.Generic;
using System.Linq;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// App User
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        
        /// <summary>
        /// Create new user controller
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Name can not be empty", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }
        
        /// <summary>
        /// Laad saved list of users
        /// </summary>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime dateOfBirth, double weight = 1, double height = 1)
        {
            //TODO: Check
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.DateOfBirth = dateOfBirth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save user data
        /// </summary>
        public void Save()
        {
            Save(Users);   
        }
    }
}