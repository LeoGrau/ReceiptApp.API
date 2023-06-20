using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Mapping;
using ReceiptApp.API.Security.Repositories;
using ReceiptApp.API.Security.Services;
using ReceiptApp.API.Shared;
using ReceiptApp.API.Shared.Domain.Repository;
using ReceiptApp.API.Shared.Persistence.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Open API Configuration
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v0", new OpenApiInfo
        {
            Version = "v0",
            Title = "ReceiptApp API",
            Description = "Receipt App just for fun and recruiting."
        });
        options.EnableAnnotations();
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new List<string>()
            }
        });
    }
);

// Connection String
var connectionString = builder.Configuration.GetConnectionString("MySqlConnectionForReceiptApp");

// Adding DbContext with Connection String
builder.Services.AddDbContext<AppDbContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    });

// Lowercase url configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// CORS Service Addition
builder.Services.AddCors();

// RecruiterApp Services and Repositories
// -- User -- 
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Repository
builder.Services.AddScoped<IUserService, UserService>(); // Service
// -- Receipt --
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>(); // Repository
builder.Services.AddScoped<IReceiptService, ReceiptService>(); // Service

// -- Inheritance
// -- User --
builder.Services.AddScoped<IBaseRepository<User, Guid>, BaseRepository<User, Guid>>();
builder.Services.AddScoped<IBaseRepository<Receipt, Guid>, BaseRepository<Receipt, Guid>>();

// Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Services
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile),
    typeof(ReceiptApp.API.ReceiptApp.Mapping.ModelToResourceProfile),
    typeof(ReceiptApp.API.ReceiptApp.Mapping.ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring database tables were created.
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v0/swagger.json", "v0");
        options.RoutePrefix = "swagger";
    });
}

// Use CORS Service
app.UseCors(policyBuilder => 
    policyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();