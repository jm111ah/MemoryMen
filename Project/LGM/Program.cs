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

#region 스웨거에 인증 추가

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MemoryMan LGM API", Version = "v1" });
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "발급 받은 토큰을 입력해주세요. (ex : Bearer 발급키)"
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

#region DI (의존성 주입)

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IHome, HomeService>();
builder.Services.AddScoped<IJWT, JWTService>();

#endregion

#region JWT 

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // 토큰 발급자 검증 여부
            ValidateAudience = true, // 토큰 대상 검증 여부
            ValidateLifetime = true, // 토큰 만료시간 검증 여부
            ValidateIssuerSigningKey = true, // 서명키 검증 여부
            ValidIssuer = jwtSettings["Issuer"], // 허용할 발급자
            ValidAudience = jwtSettings["Audience"], // 허용할 대상자
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)) // 보안키 생성
        };
    });

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region 인증 및 권한 추가

app.UseAuthentication(); // 인증 확인
app.UseAuthorization(); // 권한 확인

#endregion

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
