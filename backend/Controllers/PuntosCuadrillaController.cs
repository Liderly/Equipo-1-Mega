   
using Microsoft.AspNetCore.Mvc;
   
   
    [ApiController]
    [Route("api/[controller]")]
    public class PuntosCuadrillaController : ControllerBase
    {
        private readonly ServicePuntosCuadrilla _servicio;

        public PuntosCuadrillaController(ServicePuntosCuadrilla servicio)
        {
            _servicio = servicio;
        }

        /// <summary>
        ///     Devuelve resultados de una cuadrilla en específico por su 'NumCuadrilla'.
        /// </summary>
        /// <param name="numCuadrilla"></param>
        /// <returns>Cuadrilla en especifico por su numCuadrilla</returns>
        [HttpGet("{parametro1}")]
        public async Task<ActionResult<List<PuntosCuadrilla>>> ObtenerResultados(int parametro1)
        {
            var resultados = await _servicio.EjecutarProcedimientoAsync(parametro1);
            if (resultados == null || !resultados.Any())
            {
                return NotFound(new { message = "No se encontro cuadrilla con número: " + parametro1 });
            }
            return Ok(resultados);
        }
    }