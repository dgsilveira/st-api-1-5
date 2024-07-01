using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace M2.Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly Contexto contexto;

        public PessoaController()
        {
            contexto = new Contexto();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(contexto.Pessoas.ToList());
        }

        [HttpGet]
        [Route("getId")]
        public IActionResult GetId(int id)
        {
            return Ok(contexto.Pessoas.First(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Post(PessoaInsert pessoaInsert)
        {
            Pessoa pessoa = new Pessoa()
            {
                Ativo = true,
                DataModificacao = DateTime.Now,
                DataNascimento = pessoaInsert.DataNascimento,
                Genero = pessoaInsert.Genero,
                Nome = pessoaInsert.Nome
            };

            contexto.Pessoas.Add(pessoa);
            contexto.SaveChanges();

            return NoContent();
        }

        [HttpPut]
        public IActionResult Put(int id, PessoaUpdate pessoaUpdate)
        {
            Pessoa pessoa = contexto.Pessoas.First(p => p.Id == id);

            if (pessoaUpdate.Ativo != null)
                pessoa.Ativo = (bool)pessoaUpdate.Ativo;

            if (pessoaUpdate.DataNascimento != null)
                pessoa.DataNascimento = (DateTime)pessoaUpdate.DataNascimento;

            if (pessoaUpdate.Genero != null)
                pessoa.Genero = pessoaUpdate.Genero;

            if (pessoaUpdate.Nome != null)
                pessoa.Nome = pessoaUpdate.Nome;

            pessoa.DataModificacao = DateTime.Now;

            contexto.Update(pessoa);
            contexto.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Pessoa pessoa = contexto.Pessoas.First(p => p.Id == id);

            contexto.Pessoas.Remove(pessoa);
            contexto.SaveChanges();

            return NoContent();
        }
    }
}
