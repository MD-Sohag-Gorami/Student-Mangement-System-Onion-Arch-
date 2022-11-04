using Microsoft.EntityFrameworkCore;
using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefalutConnection")));

//builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddScoped<ITeacherModelFactory, TeacherModelFactory>();
builder.Services.AddScoped<ICourseModelFactory, CourseModelFactory>();
builder.Services.AddScoped<IStudentModelFactory, StudentModelFactory>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
