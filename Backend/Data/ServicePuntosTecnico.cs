using Backend_HackathonMega.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

 public class ServicePuntosTecnico
    {
        private readonly AppDBContext _context;

        public ServicePuntosTecnico(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<PuntosTecnico>> EjecutarProcedimientoPuntosTecnicoAsync(string NumTecnico)
        {
            var resultado = await _context.Set<PuntosTecnico>()
                .FromSqlRaw("EXEC sp_CalcularPuntosPagoTecnico @NumTec1", 
                    new SqlParameter("@NumTec1", NumTecnico))
                .ToListAsync();

            return resultado;
        }
    }