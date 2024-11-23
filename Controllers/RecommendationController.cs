using Microsoft.AspNetCore.Mvc;
using SustenAI.API.Services.Recommendation;

namespace SustenAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;

        public RecommendationController(RecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpPost("treinar")]
        public IActionResult Treinar([FromBody] List<DispositivoRating> avaliacoes)
        {
            _recommendationService.TrainModel(avaliacoes);
            return Ok("Modelo treinado com sucesso!");
        }

        [HttpGet("calcular Gastos")]
        public IActionResult Prever(string idUsuario, string idDispositivo)
        {
            var pontuacao = _recommendationService.PreverPontuacao(idUsuario, idDispositivo);
            return Ok(new { idUsuario, idDispositivo, pontuacao });
        }
    }
}