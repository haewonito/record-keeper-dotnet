global using record_keeper_dotnet.Services.RecordService;
global using record_keeper_dotnet.Models;
global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRecordService, RecordService>();
// depending on what you need, you can use AddTransient or AddSingle here, which will instantiate a new REcordService everytime it's called, etc etc
builder.Services.AddAutoMapper(typeof(Program).Assembly);  //Program is the name of the file you are in right now


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
