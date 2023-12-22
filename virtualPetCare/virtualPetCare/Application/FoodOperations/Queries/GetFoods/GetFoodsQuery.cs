using AutoMapper;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.FoodOperations.Queries.GetFoods
{ 
    public class GetFoodsQuery
    {

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFoodsQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<FoodViewModel> Handle()
        {
           var foods = _dbContext.Foods.ToList();

           var foodViewModel = _mapper.Map<List<FoodViewModel>>(foods);
            return foodViewModel;

        }
    
    }
    
    public class FoodViewModel
    {
        public string Name { get; set; }
    }

}
