using Flunt.Notifications;
using M5.Cadastro.API.Util;

namespace M5.Cadastro.API.Entitys
{
    /// <summary>
    /// Entidade Pessoa
    /// </summary>
    public class Pessoa : Notifiable<Notification>
    {
        /// <summary>
        /// Ativo
        /// </summary>
        public bool Ativo { get; private set; }

        /// <summary>
        /// Data de modificação
        /// </summary>
        public DateTime DataModificacao { get; private set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime DataNascimento { get; private set; }

        /// <summary>
        /// Gênero
        /// "M" ou "F"
        /// </summary>
        public string Genero { get; private set; }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nome
        /// Máximo 100 caracteres
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Construtor para criar Pessoa
        /// </summary>
        /// <param name="ativo">ativo</param>
        /// <param name="dataNascimento">data de nascimento</param>
        /// <param name="genero">genero, "M" ou "F"</param>
        /// <param name="nome">nome, máximo 100 caracteres</param>
        public Pessoa(bool ativo, DateTime dataNascimento, string genero, string nome)
        {
            Ativo = ativo;
            DataNascimento = dataNascimento;
            Genero = genero;
            Nome = nome;

            DataModificacao = DateTime.Now;
            ValidarGenero(genero);
            ValidarNome(nome);
        }


        /// <summary>
        /// Construtor para ler pessoa do banco
        /// </summary>
        /// <param name="ativo">ativo</param>
        /// <param name="dataModificacao">data de modificação</param>
        /// <param name="dataNascimento">data de nascimento</param>
        /// <param name="genero">genero, "M" ou "F"</param>
        /// <param name="id">id</param>
        /// <param name="nome">nome, máximo 100 caracteres</param>
        public Pessoa(bool ativo, DateTime dataModificacao, DateTime dataNascimento, string genero, int id, string nome)
        {
            Ativo = ativo;
            DataModificacao = dataModificacao;
            DataNascimento = dataNascimento;
            Genero = genero;
            Id = id;
            Nome = nome;

            ValidarGenero(genero);
            ValidarId(id);
            ValidarNome(nome);
        }

        private void ValidarGenero(string genero)
        {
            if (string.IsNullOrEmpty(Genero))
            {
                AddNotification(new Notification(nameof(Genero), Constantes.GENERO_VAZIO));
                return;
            }

            if (string.IsNullOrWhiteSpace(Genero))
                AddNotification(new Notification(nameof(Genero), Constantes.GENERO_ESPACO_EM_BRANCO));

            if (Genero.Length > Constantes.GENERO_TAMANHO_MAXIMO)
                AddNotification(new Notification(nameof(Genero), Constantes.GENERO_EXCEDEU_LIMITE_CARACTERES));
        }

        private void ValidarId(int? id)
        {
            if (Id <= 0)
                AddNotification(new Notification(nameof(Id), Constantes.ID_INVALIDO));
        }

        private void ValidarNome(string? nome)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                AddNotification(new Notification(nameof(Nome), Constantes.NOME_VAZIO));
                return;
            }

            if (string.IsNullOrWhiteSpace(Nome))
                AddNotification(new Notification(nameof(Nome), Constantes.NOME_ESPACO_EM_BRANCO));

            if (Nome.Length > Constantes.NOME_TAMANHO_MAXIMO)
                AddNotification(new Notification(nameof(Nome), Constantes.NOME_EXCEDEU_LIMITE_CARACTERES));
        }
    }
}
