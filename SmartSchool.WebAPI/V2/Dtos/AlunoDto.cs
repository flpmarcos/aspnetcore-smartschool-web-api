using System;

namespace SmartSchool.WebAPI.V2.Dtos
{
    public class AlunoDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno matricula do aluno
        /// </summary>
        public int Matricula { get; set; }

        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public int Idade { get; set; }

        public DateTime DataIni { get; set; }

        public bool Ativo { get; set; } = true;


    }
}
