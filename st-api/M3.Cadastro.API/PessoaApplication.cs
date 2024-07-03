namespace M3.Cadastro.API
{
    public class PessoaApplication
    {
        private PessoaRepository pessoaRepository;

        public PessoaApplication()
        {
            pessoaRepository = new PessoaRepository();
        }

        public IEnumerable<Pessoa> ListarPessoas()
        {
            var pessoas = pessoaRepository.ListarPessoas();

            return pessoas;
        }

        public Pessoa BuscarPorId(int id)
        {
            var pessoa = pessoaRepository.BuscarPorId(id);

            return pessoa;
        }

        public void Inserir(PessoaInsert pessoa)
        {
            pessoaRepository.Inserir(pessoa);
        }

        public void Delete (int id)
        {
            pessoaRepository.Delete(id);
        }

        public void Atualizar(int id, PessoaUpdate pessoa)
        {
            pessoaRepository.Atualizar(id, pessoa);
        }
    }
}
