﻿using AutoMapper;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.PetOperations.Commands.CreatePet
{   
    public class CreatePetCommand
    {
        public CreatePetModelDto Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PetCreateViewModel Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(pet => pet.Name.ToLower() == Model.Name.ToLower());

            if (pet is not null)
                throw new InvalidOperationException("The Pet already exists.");

            pet = _mapper.Map<Pet>(Model);

            _dbContext.Pets.Add(pet);
            _dbContext.SaveChanges();   

            var result = _mapper.Map<PetCreateViewModel>(pet);
            return result;
        }

    }
     
    public record CreatePetModelDto
    {
        public string Name { get; init; }
        public int? UserId { get; init; }
        
    }
     
    public class PetCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
    }

}
