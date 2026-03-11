using DepuData.Application.UseCases.Deputados.GetRankingGastos;
using Microsoft.AspNetCore.Mvc;

namespace DepuData.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeputadoController : ControllerBase {
    [HttpGet]
    public async Task<IActionResult> GetRankingGastos([FromServices] IGetRankingGastosUseCase useCase) {
        var response = await useCase.Execute();
        return Ok(response);
    }
}
