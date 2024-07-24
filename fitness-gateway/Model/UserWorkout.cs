namespace fitness_gateway.Model
{
    public class UserWorkout
    {
        public int userWorkoutID { get; set; }
        public int userID { get; set; }
        public int workoutID { get; set; }
        public int workoutDuration { get; set; }
        public DateTime userWorkoutDate { get; set; }
    }
}
