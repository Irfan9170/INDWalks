using INDWalks.API.Data;
using INDWalks.API.Mapping;
using INDWalks.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<INDWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("INDWalksConnectionString")));
builder.Services.AddScoped<IRegionRepository,SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository,SQLWalkRepository>();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

var app = builder.Build();
////
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
