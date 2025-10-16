using Clinic.Application;
using Clinic.Domain;
using Clinic.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR...\""
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDomain();
builder.Services.AddApplication();


//Thêm middleware authentication
var privateKey = builder.Configuration["jwt:Key"];
var Issuer = builder.Configuration["jwt:Issuer"];
var Audience = builder.Configuration["jwt:Audience"];
// Thêm dịch vụ Authentication vào ứng dụng, sử dụng JWT Bearer làm phương thức xác thực
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // Thiết lập các tham số xác thực token
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        // Kiểm tra và xác nhận Issuer (nguồn phát hành token)
        ValidateIssuer = true,
        ValidIssuer = Issuer, // Biến `Issuer` chứa giá trị của Issuer hợp lệ
                              // Kiểm tra và xác nhận Audience (đối tượng nhận token)
        ValidateAudience = true,
        ValidAudience = Audience, // Biến `Audience` chứa giá trị của Audience hợp lệ
                                  // Kiểm tra và xác nhận khóa bí mật được sử dụng để ký token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
        // Sử dụng khóa bí mật (`privateKey`) để tạo SymmetricSecurityKey nhằm xác thực chữ ký của token
        // Giảm độ trễ (skew time) của token xuống 0, đảm bảo token hết hạn chính xác
        ClockSkew = TimeSpan.Zero,
        // Xác định claim chứa vai trò của user (để phân quyền)
        RoleClaimType = ClaimTypes.Role,
        // Xác định claim chứa tên của user
        NameClaimType = ClaimTypes.Name,
        // Kiểm tra thời gian hết hạn của token, không cho phép sử dụng token hết hạn
        ValidateLifetime = true
    };
});
// Thêm dịch vụ Authorization để hỗ trợ phân quyền người dùng
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDev",
        policy => policy
            .WithOrigins("https://localhost:7097")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.MigrateDatabase();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowBlazorDev");

app.MapControllers();

app.Run();  
