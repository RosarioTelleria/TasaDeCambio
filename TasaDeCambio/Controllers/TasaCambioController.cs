using Microsoft.AspNetCore.Mvc;
using Modelo.Model;
using Servicios.DataAccess;
using TipoCambio;

namespace TasaDeCambio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasaCambioController : ControllerBase
    {
        [HttpGet("ObtenerTasaCambioDia")]
        public async Task<double> ObtenerTasaCambioDia(int year, int month, int day)
        {
            RecuperaTC_MesResponse response = new RecuperaTC_MesResponse();
            TipoDeCambio tipoCambio = new TipoDeCambio();
            var resultDia = await tipoCambio.ObtenerTipoDeCambioDia(year, month, day);

            return resultDia;
        }

        [HttpGet("ObtenerTasaCambioDiaJson")]
        public async Task<double> ObtenerTasaCambioDiaJson([FromBody] TasaCambioDTO tasaCambio)
        {
            RecuperaTC_MesResponse response = new RecuperaTC_MesResponse();
            TipoDeCambio tipoCambio = new TipoDeCambio();

            var resultDia = await tipoCambio.ObtenerTipoDeCambioDia(tasaCambio.anyo, tasaCambio.mes, tasaCambio.dia);

            return resultDia;
        }

        [HttpGet("ObtenerTasaCambioMes")]
        public async Task<string> ObtenerTasaCambioMes(int year, int month)
        {
            RecuperaTC_MesResponse response = new RecuperaTC_MesResponse();
            TipoDeCambio tipoCambio = new TipoDeCambio();

            var resultMes = await tipoCambio.ObtenerTipoDeCambioMes(year, month);

            return resultMes.Body.RecuperaTC_MesResult.InnerXml.ToString();
        }

        [HttpGet("ObtenerTasaCambioMesJson")]
        public async Task<string> ObtenerTasaCambioMesJson([FromBody] TasaCambioDTO tasaCambio)
        {
            RecuperaTC_MesResponse response = new RecuperaTC_MesResponse();
            TipoDeCambio tipoCambio = new TipoDeCambio();

            var resultMes = await tipoCambio.ObtenerTipoDeCambioMes(tasaCambio.anyo, tasaCambio.mes);

            return resultMes.Body.RecuperaTC_MesResult.InnerXml.ToString();
        }
    }
}