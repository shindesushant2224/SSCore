using Microsoft.EntityFrameworkCore;
using SSCore.API.Data;
using SSCore.API.Mappings;
using SSCore.API.Repositories.RegionRepository;
using SSCore.API.Repositories.WalksRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SSWalksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SSWalksCon"));
});

builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IWalksRepository, WalksRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapping));

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
