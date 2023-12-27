using Job.Application.Modules;
using Job.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationModules();
builder.Services.AddDbContext<JobDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("JobConnect")));
//Add Authentication Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopApi", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [Space] then your token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Co kiem tra Issuer(Nguoi tao ra token)
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //Co kiem tra Audience(Noi tiep nhan token)
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            //Co yeu cau thoi gian het han cua token
            RequireExpirationTime = true,
            ValidateLifetime = true,
            //Lay ra khoa bi mat
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            RequireSignedTokens = true,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("MyPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
