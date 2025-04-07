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
    /// 스웨거 문서의 메타 정보 지정
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MemoryMan LGM API", Version = "v1" });

    // 스웨거에서 
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT 토큰을 'Bearer {token}' 형식으로 입력하세요.\n예: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6..."
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
builder.Services.AddSingleton<JWT>();

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)) // 서명 검증하기 위한 키
        };
    });

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region 인증 미들웨어

app.UseAuthentication(); // 누구인지 확인
app.UseAuthorization(); // 권한이 있는지 확인

#endregion

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
