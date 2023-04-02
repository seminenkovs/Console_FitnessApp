using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            if (finish < start)
            {
                throw new ArgumentException("Finish time can't be less then start time.", nameof(activity));
            }
            Finish = finish;
            Activity = activity ?? throw new ArgumentNullException("Activity can't be empty.", nameof(activity));
            User = user ?? throw new ArgumentNullException("User can't be empty.", nameof(user));
        }
    }
}
