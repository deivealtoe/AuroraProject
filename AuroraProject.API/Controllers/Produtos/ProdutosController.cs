using AuroraProject.Aplicacao;
using AuroraProject.DataTransfer;
using Microsoft.AspNetCore.Mvc;

namespace AuroraProject.API;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    public IProdutosAppServico ProdutosAppServico;

    public ProdutosController(IProdutosAppServico produtosAppServico)
    {
        ProdutosAppServico = produtosAppServico;
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<ProdutoResponse> BuscarPorId(int id)
    {
        ProdutoResponse response = ProdutosAppServico.BuscarPorId(id);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ProdutoResponse>> InserirAsync([FromBody] ProdutoRequest request)
    {
        try
        {
            ProdutoResponse response = await ProdutosAppServico.InserirAsync(request);

            return Ok(response);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
