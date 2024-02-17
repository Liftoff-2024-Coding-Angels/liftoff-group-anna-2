using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//this is for the application db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//this is for the identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//user roles db context
//builder.Services.AddDbContext<UserRolesDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UserRolesDbContext>();

//this is for the movie review db context
builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//this is for the review repository
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
//this is for the image repository (uploading images in a review)
builder.Services.AddScoped<IImageRepository, CloudinaryImagesRepository>();
//likes repository
builder.Services.AddScoped<ILikeReviewRepository, LikeReviewRepository>();
//comments repository
builder.Services.AddScoped<IReviewCommentsRepository, ReviewCommentsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
