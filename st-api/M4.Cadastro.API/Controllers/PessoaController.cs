using M4.Cadastro.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace M4.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaApplication _pessoaApplication;

        public PessoaController(IPessoaApplication pessoaApplication)
        {
            _pessoaApplication = pessoaApplication;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pessoas = _pessoaApplication.ListarPessoas();

            return Ok(pessoas);
        }

        [HttpGet]
        [Route("getId")]
        public IActionResult GetId(int id)
        {
            var pessoa = _pessoaApplication.BuscarPorId(id);

            return Ok(pessoa);
        }

        [HttpPost]
        public IActionResult Post(PessoaInsert pessoa)
        {
            _pessoaApplication.Inserir(pessoa);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _pessoaApplication.Delete(id);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar(int id, PessoaUpdate pessoa)
        {
            _pessoaApplication.Atualizar(id, pessoa);

            return NoContent();
        }
    }
}
