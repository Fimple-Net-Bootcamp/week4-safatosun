namespace virtualPetCare.Entities
{
     
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
