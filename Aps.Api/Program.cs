using Aps.Api.ContextApp;
using Aps.Api.Model;
using Aps.Api.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("aps_db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Dev", 
        builder =>
            builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/information", async (InformationRequest informationRequest, Context db) =>
{
    var information = Information.CreateInformation(informationRequest.Title, informationRequest.Local, informationRequest.Local, informationRequest.Image);
    db.Information.Add(information);
    await db.SaveChangesAsync();

    return Results.Created($"/information/{information.Id}", information);
})
.Produces<InformationRequest>()
.WithOpenApi();

app.MapGet("/information", async(Context db) =>
{
    var informations = await db.Information.ToListAsync();

    if (informations is null) return Results.NotFound();

    return Results.Ok(informations);
});

app.MapDelete("/information/{id:guid}", async (Guid id, Context db) =>
{
    var information = await db.Information.FirstOrDefaultAsync(x => x.Id.Equals(id));

    if (information is null) return Results.NotFound();

    db.Information.Remove(information);
    await db.SaveChangesAsync();

    return Results.NoContent();
});


app.UseCors("Dev");

app.Run();
