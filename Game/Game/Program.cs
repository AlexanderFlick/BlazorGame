using Game.Data.Dinosaurs.DinosaurMoves;
using Game.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IPlayerDinosaurService, PlayerDinosaurService>();
builder.Services.AddSingleton<IDinosaurService, DinosaurService>();
builder.Services.AddSingleton<IAmberService, AmberService>();
builder.Services.AddSingleton<IBattleService, BattleService>();
builder.Services.AddSingleton<IPlayerFossilService, PlayerFossilService>();
builder.Services.AddSingleton<IFusionService, FusionService>();
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddSingleton<ISaveService, SaveService>();
builder.Services.AddSingleton<IRarityService, RarityService>();
builder.Services.AddSingleton<IDinosaurMoveRepository, DinosaurMoveRepository>();
builder.Services.AddSingleton<IAccessService, AccessService>();

var app = builder.Build();

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
