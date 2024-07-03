using M4.Cadastro.API.Interfaces;

namespace M4.Cadastro.API
{
    public class PessoaApplication : IPessoaApplication
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaApplication(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> ListarPessoas()
        {
            var pessoas = _pessoaRepository.ListarPessoas();

            return pessoas;
        }

        public Pessoa BuscarPorId(int id)
        {
            var pessoa = _pessoaRepository.BuscarPorId(id);

            return pessoa;
        }

        public void Inserir(PessoaInsert pessoa)
        {
            _pessoaRepository.Inserir(pessoa);
        }

        public void Delete(int id)
        {
            _pessoaRepository.Delete(id);
        }

        public void Atualizar(int id, PessoaUpdate pessoa)
        {
            _pessoaRepository.Atualizar(id, pessoa);
        }
    }
}
