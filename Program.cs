using BlazorApi.Repository;
using BlazorApi.Service;
using BlazorApi.Service.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add controllers in the project
builder.Services.AddSingleton<IProductRepository, ProductService>();
builder.Services.AddSingleton<IActivityRepository, ActivityService>();


// Implement connection the database
SQLiteHandler.ConnectionString = builder.Configuration.GetConnectionString("defaultConnection");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

// Configure cors in the project
app.UseCors(builder =>
{
    builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("https://localhost:4200", "http://localhost:4200");
});

app.Run();
