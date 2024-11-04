using _Nexus.Services.CepService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Nexus.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Tags("Consulta de CEP")]
    public class CEPController : ControllerBase
    {
        private readonly ICEP cepService;

        public CEPController(ICEP _cepService)
        {
            cepService = _cepService;
        }

        /// <summary>
        /// Retorna um endereço baseado no cep
        /// </summary>
        /// <remarks>
        /// Exemplo de Solicitação
        /// 
        ///     GET /cep/GetCEP/00000-000
        /// 
        /// </remarks>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(AddressResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public Task<AddressResponse> GetCEP(string cep)
        {
            //int registro = 351435;
            //string rm = registro.ToRM();    
            //RM351435
            return cepService.FindCEP(cep);
        }

    }
}