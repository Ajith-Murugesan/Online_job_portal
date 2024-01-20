using Business_Logic_Layer.IServices;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositories;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IUserAccount, UserAccountRepo>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IJobTypeRepository, JobTypeRepository>();
builder.Services.AddScoped<IJobTypeService, JobTypeService>();
builder.Services.AddScoped<IBusinessStreamRepository, BusinessStreamRepository>();
builder.Services.AddScoped<IBusinessStreamService, BusinessStreamService>();
builder.Services.AddScoped<IJobLocationRepository, JobLocationRepository>();
builder.Services.AddScoped<IJobLocationService, JobLocationService>();
builder.Services.AddScoped<IExperienceDetailsRepository, ExperienceDetailsRepository>();
builder.Services.AddScoped<IExperienceDetailsService, ExperienceDetailsService>();
builder.Services.AddScoped<ISeekerProfileRepository, SeekerProfileRepository>();
builder.Services.AddScoped<ISeekerProfileService, SeekerProfileService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEducationalDetails, EducationDetailsRepo>();
builder.Services.AddScoped<IEducationalDetailService,EducationalDetailService>();
builder.Services.AddScoped<IJobPostRepository, JobPostRepository>();
builder.Services.AddScoped<IJobPostService, JobPostService>();
builder.Services.AddScoped<ISkillsetRepository, SkillsetRepository>();
builder.Services.AddScoped<ISkillsetService, SkillsetService>();
builder.Services.AddScoped<IJobPostActivityRepository, JobPostActivityRepository>();
builder.Services.AddScoped<IJobPostActivityService, JobPostActivityService>();
builder.Services.AddScoped<IAuth, AuthRepo>();
builder.Services.AddTransient<IMailService, MailService>();

builder.Services.AddCors(op =>
{
    op.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();


    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.UseCors("MyCorsPolicy");
app.Run();
