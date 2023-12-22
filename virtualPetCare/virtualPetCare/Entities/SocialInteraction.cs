namespace virtualPetCare.Entities
{

    public class SocialInteraction
    {
        public int Id { get; set; }
        public int FriendPetId { get; set; }
        public List<Pet> Pets { get; set; }
    }

}
