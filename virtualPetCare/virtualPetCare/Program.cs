using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivity;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet;
using virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById;
using virtualPetCare.Application.FoodOperations.Commands.CreateFoodForPets;
using virtualPetCare.Application.FoodOperations.Queries.GetFoods;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;
using virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery;
using virtualPetCare.Application.PetOperations.Commands.CreatePet;
using virtualPetCare.Application.PetOperations.Commands.UpdatePet;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.Application.PetOperations.Queries.GetPets;
using virtualPetCare.Application.PetOperations.Queries.GetPetStatisticsById;
using virtualPetCare.Application.SocialInteractionOperations.Command.CreateSocialInteractionForPets;
using virtualPetCare.Application.SocialInteractionOperations.Queries.GetSocialInteractionById;
using virtualPetCare.Application.TrainingOperations.Commands.CreateTrainingForPet;
using virtualPetCare.Application.TrainingOperations.Queries.GetTrainingsForPetById;
using virtualPetCare.Application.UserOperations.Commands.CreateUser;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;
using virtualPetCare.Application.UserOperations.Queries.GetUserPetStatisticsById;
using virtualPetCare.DBOperations;
using virtualPetCare.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddFluentValidation(f =>
                {
                    f.RegisterValidatorsFromAssemblyContaining<CreateActivityCommandValidator>();
                });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VirtualPetCareDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<CreateUserCommand>();
builder.Services.AddScoped<GetUserByIdQuery>();
builder.Services.AddScoped<CreatePetCommand>();
builder.Services.AddScoped<GetPetByIdQuery>();
builder.Services.AddScoped<GetPetsQuery>();
builder.Services.AddScoped<UpdatePetCommand>();
builder.Services.AddScoped<GetHealthStatusByIdQuery>();
builder.Services.AddScoped<PatchHealthStatusCommand>();
builder.Services.AddScoped<CreateActivityCommand>();
builder.Services.AddScoped<GetActivitiesByIdQuery>();
builder.Services.AddScoped<CreateActivityForPetCommand>();
builder.Services.AddScoped<GetFoodsQuery>();
builder.Services.AddScoped<CreateFoodForPetCommand>();
builder.Services.AddScoped<GetPetStatisticsByIdQuery>();
builder.Services.AddScoped<GetUserPetStatisticsByIdQuery>();
builder.Services.AddScoped<CreateTrainingForPetCommand>();
builder.Services.AddScoped<GetTrainingsForPetByIdQuery>();
builder.Services.AddScoped<CreateSocialInteractionForPetCommand>();
builder.Services.AddScoped<GetSocialInteractionByIdQuery>();    


var app = builder.Build();

app.ConfigureExceptionHandler();

 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
