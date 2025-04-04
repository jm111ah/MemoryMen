using LGM.Dto;
using LGM.Interface;
using LGM.Service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region config setting

var config = builder.Configuration;

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

var jwtSettings = config.GetSection("JwtSettings");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!))
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

app.UseAuthentication();

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
