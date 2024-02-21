using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using LaunchCodeCapstone.Data;
using LaunchCodeCapstone.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using LaunchCodeCapstone.Services;
using LaunchCodeCapstone.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//this is for the movie application db context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//this is for the identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MovieDbContext>();
builder.Services.AddControllersWithViews();

//this is for the movie review db context
builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

////this is for the watchlist db context
builder.Services.AddDbContext<WatchListDbContext>(options =>
   options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//this is for the review repository (interface, it's implementation)
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
//this is for the image repository (uploading images in a review)
builder.Services.AddScoped<IImageRepository, CloudinaryImagesRepository>();
//likes repository
builder.Services.AddScoped<ILikeReviewRepository, LikeReviewRepository>();
//comments repository
builder.Services.AddScoped<IReviewCommentsRepository, ReviewCommentsRepository>();
//users repository
builder.Services.AddScoped<IUserRepository, UserRepository>();
//watchlist repository
builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

//this sets the inactivity timeout to 2 days
builder.Services.ConfigureApplicationCookie(o => {
    o.ExpireTimeSpan = TimeSpan.FromDays(2);
    o.SlidingExpiration = true;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});


services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});

var app = builder.Build();

string bearerToken = ("eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJmZjkyOWMxY2Q5MTgzOWNkYWU5MzZhNjEzMmNmNGUyNyIsInN1YiI6IjY1YWMwMjliYWQ1OWI1MDBlYjc4NTFkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.TKw26QnxggH6qX2MFMraVlrRetVSCODmGMBX_L6WTJw");

MovieDbFactory.RegisterSettings(bearerToken);

// as the factory returns a Lazy<T> instance, just grab the Value from the Lazy<T>
// and assign to a local variable.
IApiMovieRequest movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;

// Configure the HTTP request pipeline.w

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
