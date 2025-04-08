using LGM.Dto;
using LGM.Interface;
using LGM.Service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region config setting

var config = builder.Configuration;
var jwtSettings = config.GetSection("JwtSettings");

#endregion

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region 

builder.Services.AddSwaggerGen(options =>
{
    /// ������ ������ ��Ÿ ���� ����
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MemoryMan LGM API", Version = "v1" });

    // �����ſ��� 
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "�߱� ���� ��ū�� Bearer MemoryToken12345.......... �������� �Է����ּ���."
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
            Array.Empty<string>()
        }
    });
});

#endregion

#region DI (������ ����)

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IHome, HomeService>();
builder.Services.AddScoped<IJWT, Jwt>

#endregion

#region JWT 

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // ��ū �߱��� ���� ����
            ValidateAudience = true, // ��ū ��� ���� ����
            ValidateLifetime = true, // ��ū ����ð� ���� ����
            ValidateIssuerSigningKey = true, // ����Ű ���� ����
            ValidIssuer = jwtSettings["Issuer"], // ����� �߱���
            ValidAudience = jwtSettings["Audience"], // ����� �����
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)) // ����Ű ����
        };
    });

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region ���� �̵����

app.UseAuthentication(); // ���� ���� Ȯ��
app.UseAuthorization(); // ���� Ȯ��

#endregion

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
