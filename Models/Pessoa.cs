namespace webapi.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }

        public bool Tipo_pessoa { get; set; }
        public string Cnpj { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public string CEP { get; set; }

        public string Email { get; set; }

        public string Classificacao { get; set; }

        public string Telefone { get; set; }
    }
}