﻿namespace M4.Cadastro.API.Interfaces
{
    public interface IPessoaApplication
    {
        IEnumerable<Pessoa> ListarPessoas();
        Pessoa BuscarPorId(int id);
        void Inserir(PessoaInsert pessoa);
        void Delete(int id);
        void Atualizar(int id, PessoaUpdate pessoa);
    }
}
