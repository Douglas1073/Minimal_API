using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

String connectionString = "Server=DOUGLAS\\SQLEXPRESS;DATABASE=CadastroDeArmas;Integrated Security=True;TrustServerCertificate=True;";

              // Get = Listar Todas As Armas

app.MapGet("/armas", async (HttpContext context) =>
{
    List<Armas> armas = new List<Armas>();

    using SqlConnection connection = new SqlConnection(connectionString);

    string query = "SELECT IdArmas, NomeArmas, CalibreArmas, ComprimentoTotalArmas, CapacidadeDoCarregadorArmas, PesoArmas, DataDeFabricacaoArmas, FabricanteArmas, TipoArmas FROM armas";
    using SqlCommand command = new SqlCommand(query, connection);

    await connection.OpenAsync();

    using SqlDataReader reader = await command.ExecuteReaderAsync();

    while (await reader.ReadAsync())
    {
        armas.Add(new Armas
        {
            IdArmas = reader.GetInt32(0),
            NomeArmas = reader.GetString(1),
            CalibreArmas = reader.GetDecimal(2),
            ComprimentoTotalArmas = reader.GetDecimal(3),
            CapacidadeDoCarregadorArmas = reader.GetDecimal(4),
            PesoArmas = reader.GetDecimal(5),
            DataDeFabricacaoArmas = reader.GetInt32(6),
            FabricanteArmas = reader.GetString(7),
            TipoArmas = reader.GetString(8)
        });
    }

    return Results.Ok(armas);

});

                // Filtrar o Id De Armas

app.MapGet("/armas/{id:int}", async (int id) =>

{

    using SqlConnection connection = new SqlConnection(connectionString);

    string query = "SELECT IdArmas, NomeArmas, CalibreArmas, ComprimentoTotalArmas, CapacidadeDoCarregadorArmas, PesoArmas, DataDeFabricacaoArmas, FabricanteArmas, TipoArmas FROM armas WHERE IdArmas = @Id";
    
    using SqlCommand command = new SqlCommand(query, connection);


    command.Parameters.AddWithValue("@Id", id);

    await connection.OpenAsync();

    using SqlDataReader reader = await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        Armas armas = new Armas
        {
            IdArmas = reader.GetInt32(0),
            NomeArmas = reader.GetString(1),
            CalibreArmas = reader.GetDecimal(2),
            ComprimentoTotalArmas = reader.GetDecimal(3),
            CapacidadeDoCarregadorArmas = reader.GetDecimal(4),
            PesoArmas = reader.GetDecimal(5),
            DataDeFabricacaoArmas = reader.GetInt32(6),
            FabricanteArmas = reader.GetString(7),
            TipoArmas = reader.GetString(8)
        };
        return Results.Ok(armas);
    }
    return Results.NotFound();

});

                //POST = Addc uma Nova Arma
 
 app.MapPost("/armas", async (Armas armas) =>

 {
        using SqlConnection connection = new SqlConnection(connectionString);

    string query = " INSERT INTO armas (NomeArmas, CalibreArmas, ComprimentoTotalArmas, CapacidadeDoCarregadorArmas, PesoArmas, DataDeFabricacaoArmas, FabricanteArmas, TipoArmas) VALUES (@NomeArmas, @CalibreArmas, @ComprimentoTotalArmas, @CapacidadeDoCarregadorArmas, @PesoArmas, @DataDeFabricacaoArmas, @FabricanteArmas, @TipoArmas)";
    
    using SqlCommand command = new SqlCommand(query, connection);

    command.Parameters.AddWithValue("@NomeArmas", armas.NomeArmas);
    command.Parameters.AddWithValue("@CalibreArmas", armas.CalibreArmas);
    command.Parameters.AddWithValue("@ComprimentoTotalArmas", armas.ComprimentoTotalArmas);
    command.Parameters.AddWithValue("@CapacidadeDoCarregadorArmas", armas.CapacidadeDoCarregadorArmas);
    command.Parameters.AddWithValue("@PesoArmas", armas.PesoArmas);
    command.Parameters.AddWithValue("@DataDeFabricacaoArmas", armas.DataDeFabricacaoArmas);
    command.Parameters.AddWithValue("@FabricanteArmas", armas.FabricanteArmas);
    command.Parameters.AddWithValue("@TipoArmas", armas.TipoArmas);

    await connection.OpenAsync();

    int id = Convert.ToInt32(await command.ExecuteScalarAsync());

    return Results.Created($"/armas/{id}", armas);
 });

                //PUT = atualizar

 app.MapPut("/armas/{id:int}", async (int id, Armas armas) =>

 {
        using SqlConnection connection = new SqlConnection(connectionString);

    string query = "UPDATE armas SET NomeArmas=@NomeArmas, CalibreArmas=@CalibreArmas, ComprimentoTotalArmas=@ComprimentoTotalArmas, CapacidadeDoCarregadorArmas=@CapacidadeDoCarregadorArmas, PesoArmas=@PesoArmas, DataDeFabricacaoArmas=@DataDeFabricacaoArmas, FabricanteArmas=@FabricanteArmas, TipoArmas=@TipoArmas WHERE IdArmas=@Id";
    
    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);
    command.Parameters.AddWithValue("@NomeArmas", armas.NomeArmas);
    command.Parameters.AddWithValue("@CalibreArmas", armas.CalibreArmas);
    command.Parameters.AddWithValue("@ComprimentoTotalArmas", armas.ComprimentoTotalArmas);
    command.Parameters.AddWithValue("@CapacidadeDoCarregadorArmas", armas.CapacidadeDoCarregadorArmas);
    command.Parameters.AddWithValue("@PesoArmas", armas.PesoArmas);
    command.Parameters.AddWithValue("@DataDeFabricacaoArmas", armas.DataDeFabricacaoArmas);
    command.Parameters.AddWithValue("@FabricanteArmas", armas.FabricanteArmas);
    command.Parameters.AddWithValue("@TipoArmas", armas.TipoArmas);

    await connection.OpenAsync();

    int rowAffected = await command.ExecuteNonQueryAsync();

    return rowAffected > 0 ? Results.NoContent() : Results.NotFound();
 });

                // DELETE = Remover arma

 app.MapDelete("/armas/{id:int}", async (int id) =>

 {
        using SqlConnection connection = new SqlConnection(connectionString);

    string query = "DELETE FROM  armas WHERE IdArmas=@Id";
    
    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Id", id);

    await connection.OpenAsync();

    int rowAffected = await command.ExecuteNonQueryAsync();

    return rowAffected > 0 ? Results.NoContent() : Results.NotFound();
 });

app.Run();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

app.UseCors();

public class Armas 
{
   public int IdArmas { get; set; }
   public  string NomeArmas { get; set; }
   public decimal CalibreArmas { get; set; }
   public decimal ComprimentoTotalArmas { get; set; }
   public decimal CapacidadeDoCarregadorArmas { get; set; }
   public  decimal PesoArmas { get; set; }
   public int DataDeFabricacaoArmas { get; set; }
   public  string FabricanteArmas { get; set; }
   public string TipoArmas { get; set; }
}