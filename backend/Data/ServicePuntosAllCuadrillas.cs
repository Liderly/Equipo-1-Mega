using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Backend_HackathonMega.Models;


 public class ServicePuntosAllCuadrillas
    {
        private readonly AppDBContext _context;

        public ServicePuntosAllCuadrillas(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<PuntosCuadrilla>> EjecutarProcedimientoAllCuadrillasAsync()
        {
            var resultado = await _context.Set<PuntosCuadrilla>()
                .FromSqlRaw("EXEC sp_CalcularPuntosPagoCuadrillas")
                .ToListAsync();

            return resultado;
        }

        public async Task<List<CuadrillaGrupo>> EjecutarProcedimientoAllCuadrillasAsync2()
        {
            var resultados = await _context.Set<PuntosCuadrilla>()
                .FromSqlRaw("EXEC sp_CalcularPuntosPagoCuadrillas")
                .ToListAsync();

            var grupos = resultados
                .GroupBy(p => p.Cuadrilla)
                .Select(g => new CuadrillaGrupo
                {
                    Cuadrilla = g.Key,
                    puntosCuadrillas = g.ToList()
                })
                .ToList();

            return grupos;
        }
        
    }