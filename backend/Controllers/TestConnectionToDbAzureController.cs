using Backend_HackathonMega.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

[ApiController]
[Route("api")]
public class TestConnectionToDbAzureController : ControllerBase
{
    private readonly AppDBContext _dbContext;
    private readonly IConfiguration _configuration;

    public TestConnectionToDbAzureController(AppDBContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration; // Se inyecta IConfiguration
    }

    [HttpGet("test-connection")]
    public async Task<IActionResult> TestDatabaseConnection()
    {
        try
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                return Ok("Conexión exitosa a la base de datos.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al conectar con la base de datos: {ex.Message}");
        }
    }

}
