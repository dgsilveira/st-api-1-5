namespace M1.Cadastro.API
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
