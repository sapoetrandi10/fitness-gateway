namespace fitness_gateway.Model
{
    public class Progress
    {
        public int progressID { get; set; }
        public int userID { get; set; }
        public DateTime progressDate { get; set; }
        public float weight { get; set; }
        public float caloriesConsumed { get; set; }
        public float caloriesBurned { get; set; }
    }
}
