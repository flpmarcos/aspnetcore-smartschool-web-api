using System;

namespace SmartSchool.WebAPI.Dtos
{
    /// <summary>
    /// Este é o DTO de Aluno para Registrar.
    /// </summary>
    public class AlunoRegistrarDto
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
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }

        public DateTime DataIni { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;

        public bool Ativo { get; set; } = true;

    }
}
