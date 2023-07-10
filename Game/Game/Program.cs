using Game.Data.Weapons;
using Game.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IPlayerDinosaurService, PlayerDinosaurService>();
builder.Services.AddSingleton<IDinosaurCreationService, DinosaurCreationService>();
builder.Services.AddSingleton<IAmberService, AmberService>();
builder.Services.AddSingleton<IBattleService, BattleService>();
builder.Services.AddSingleton<IWeaponRepository, WeaponRepository>();
builder.Services.AddSingleton<IPlayerFossilService, PlayerFossilService>();
builder.Services.AddSingleton<IFusionService, FusionService>();
builder.Services.AddSingleton<IItemService, ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
