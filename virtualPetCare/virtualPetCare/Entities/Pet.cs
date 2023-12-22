namespace virtualPetCare.Entities
{
     
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? HealthStatusId { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public List<Activity> Activity { get; set; }
        public List<Food> Foods { get; set; }
        public List<Training> Trainings { get; set; }
        public List<SocialInteraction> SocialInteractions { get; set; }
    }
}
