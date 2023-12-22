namespace virtualPetCare.Entities
{    
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pet> Pets { get; set; }
        
    }
}
 