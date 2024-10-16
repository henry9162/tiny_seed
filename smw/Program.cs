using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Asn1.X509.Qualified;
using SMW.Data;
using SMW.Models;
using SMW.Services.AddressService;
using SMW.Services.AuthService;
using SMW.Services.EmailService;
using SMW.Services.FabricCategoryService;
using SMW.Services.FabricService;
using SMW.Services.FabricSubCategoryService;
using SMW.Services.StorageService;
using SMW.Services.StyleAttributeService;
using SMW.Services.StyleCategoryService;
using SMW.Services.StyleService;
using SMW.Services.StyleSubCategoryService;
using SMW.Utilities;
using SMW.Utilities.ModelAbstractions;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddEntityFrameworkStores<DatabaseContext>()
.AddDefaultTokenProviders();

builder.Services.AddIdentityCore<ApplicationUser>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IStyleCategoryService, StyleCategoryService>();
builder.Services.AddScoped<IStyleSubCategoryService, StyleSubCategoryService>();
builder.Services.AddScoped<IStyleAttributeService, StyleAttributService>();
builder.Services.AddScoped<IStyleService, StyleService>();
builder.Services.AddScoped<IFabricCategoryService, FabricCategoryService>();
builder.Services.AddScoped<IFabricSubCategoryService, FabricSubCategoryService>();
builder.Services.AddScoped<IFabricService, FabricService>();
builder.Services.AddScoped(typeof(IModelAbstractions<>), typeof(ModelAbstractions<>));
//builder.Services.AddSingleton<IWebHostEnvironment>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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