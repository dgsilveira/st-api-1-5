using M5.Cadastro.API.Entitys;

namespace M5.Cadastro.API.Util
{
    /// <summary>
    /// Constantes
    /// </summary>
    public static class Constantes
    {
        /// <summary>
        /// Id Inválido
        /// </summary>
        public const string ID_INVALIDO = $"{nameof(Pessoa.Id)} inválido";

        /// <summary>
        /// Nome vazio
        /// </summary>
        public const string NOME_VAZIO = $"{nameof(Pessoa.Nome)} está vazio";

        /// <summary>
        /// Nome espaço em branco
        /// </summary>
        public const string NOME_ESPACO_EM_BRANCO = $"{nameof(Pessoa.Nome)} é espaço em branco";

        /// <summary>
        /// Nome tamanho máximo
        /// </summary>
        public const int NOME_TAMANHO_MAXIMO = 100;

        /// <summary>
        /// Nome excedeu o limite de caracteres
        /// </summary>
        public const string NOME_EXCEDEU_LIMITE_CARACTERES = $"{nameof(Pessoa.Nome)} excedeu o limite de caracteres";

        /// <summary>
        /// Gênero vazio
        /// </summary>
        public const string GENERO_VAZIO = $"{nameof(Pessoa.Genero)} está vazio";

        /// <summary>
        /// Gênero espaço em branco
        /// </summary>
        public const string GENERO_ESPACO_EM_BRANCO = $"{nameof(Pessoa.Genero)} é espaço em branco";

        /// <summary>
        /// Gênero tamanho máximo
        /// </summary>
        public const int GENERO_TAMANHO_MAXIMO = 1;

        /// <summary>
        /// Gênero excedeu limite de caracteres
        /// </summary>
        public const string GENERO_EXCEDEU_LIMITE_CARACTERES = $"{nameof(Pessoa.Genero)} excedeu o limite de caracteres";
    }
}
