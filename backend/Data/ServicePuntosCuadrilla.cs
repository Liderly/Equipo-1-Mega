using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Backend_HackathonMega.Models;


 public class ServicePuntosCuadrilla
    {
        private readonly AppDBContext _context;

        public ServicePuntosCuadrilla(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<PuntosCuadrilla>> EjecutarProcedimientoAsync(int parametro1)
        {
            var resultado = await _context.Set<PuntosCuadrilla>()
                .FromSqlRaw("EXEC sp_CalcularPuntosPago @param1", 
                    new SqlParameter("@param1", parametro1))
                .ToListAsync();

            return resultado;
        }
    }