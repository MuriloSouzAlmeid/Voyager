using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoyagerWebApi.Utils.GeminiAI;

namespace VoyagerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PlaceSearchController : ControllerBase
    {
        private readonly IPlaceSearchService _placeSearchService;

        public PlaceSearchController()
        {
            _placeSearchService = new PlaceSearchService();
        }

        [HttpPost]
        public async Task<IActionResult> Post(string local)
        {
            try
            {
                List<PlaceSettings> listaDePontosTuristicos = await _placeSearchService.BuscarPontosTuristicos(local);

                return Ok(listaDePontosTuristicos);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
