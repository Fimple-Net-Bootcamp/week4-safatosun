﻿namespace virtualPetCare.Entities
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
