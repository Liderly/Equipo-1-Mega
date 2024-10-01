using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


[ApiController]
    [Route("api/PuntosAllCuadrillas")]
    public class PuntosAllCuadrillasController : ControllerBase
    {
        private readonly ServicePuntosAllCuadrillas _servicio;

        public PuntosAllCuadrillasController(ServicePuntosAllCuadrillas servicio)
        {
            _servicio = servicio;
        }

        /// <summary>
        ///     Devuelve lista de todas las cuadrillas con puntos y bono correspondiente
        /// </summary>
        /// <returns>Lista de cuadrillas</returns>
        [HttpGet]
        public async Task<ActionResult<List<PuntosCuadrilla>>> ObtenerResultados()
        {
            var resultados = await _servicio.EjecutarProcedimientoAllCuadrillasAsync2();
            if (resultados == null || !resultados.Any())
            {
                return NotFound(new { message = "No se encontraron cuadrillas registradas" });
            }
            return Ok(resultados);
        }
    }