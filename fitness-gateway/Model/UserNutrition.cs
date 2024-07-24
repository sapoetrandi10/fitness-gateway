namespace fitness_gateway.Model
{
    public class UserNutrition
    {
        public int userNutritionID { get; set; }
        public int userID { get; set; }
        public int nutritionID { get; set; }
        public int qty { get; set; }
        public DateTime userNutritionDate { get; set; }
    }
}
