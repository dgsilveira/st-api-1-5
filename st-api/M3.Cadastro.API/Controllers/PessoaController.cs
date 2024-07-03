using Microsoft.AspNetCore.Mvc;

namespace M3.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private PessoaApplication pessoaApplication;

        public PessoaController()
        {
            pessoaApplication = new PessoaApplication();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = pessoaApplication.ListarPessoas();

            return Ok(pessoas);
        }

        [HttpGet]
        [Route("getId")]
        public IActionResult GetId(int id)
        {
            var pessoa = pessoaApplication.BuscarPorId(id);

            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post(PessoaInsert pessoa)
        {
            pessoaApplication.Inserir(pessoa);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            pessoaApplication.Delete(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar(int id, PessoaUpdate pessoa)
        {
            pessoaApplication.Atualizar(id, pessoa);

            return NoContent();
        }
    }
}
