using Microsoft.EntityFrameworkCore;
using Vezeeta.Models;
using Vezeeta.Repository.Interfaces;
using Vezeeta.Repository.Implementation;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vezeeta.TokenModel.JWTRepository.Interfaces;
using Vezeeta.JWTModel.JWTRepository.Implementation;

var builder = WebApplication.CreateBuilder(args);

//Token In Swagger
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Chat API",
        Description = "Chat API Swagger Surface",
        Contact = new OpenApiContact
        {
            Name = "João Victor Ignacio",
            Email = "ignaciojvig@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/ignaciojv/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://github.com/ignaciojvig/ChatAPI/blob/master/LICENSE")
        }

    });

    s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    s.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });

});

//AddJWT

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

builder.Services.AddScoped<IJWTManager, JWTManager>();

//CORS

string CorsPolicyName = "allowAll";

builder.Services.AddCors(options =>

{

    options.AddPolicy(

        name: CorsPolicyName,

        policy =>

        {

            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();

        }

    );

});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VezeetaContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("VesetaDB")));
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IpatientRep, patientRepo>();
builder.Services.AddScoped<ISettingRepo, SettingRepo>();


var app = builder.Build();

app.UseCors(CorsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();   

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
