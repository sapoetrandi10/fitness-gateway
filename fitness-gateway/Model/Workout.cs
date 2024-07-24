namespace fitness_gateway.Model
{
    public class Workout
    {
        public int workoutID { get; set; }
        public string workoutName { get; set; }
        public string description { get; set; }
        public int duration { get; set; }
        public float caloriesBurned { get; set; }
    }
}
