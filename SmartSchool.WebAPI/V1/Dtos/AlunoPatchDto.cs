using System;

namespace SmartSchool.WebAPI.V1.Dtos
{
    /// <summary>
    /// Este é o DTO de Aluno para Registrar.
    /// </summary>
    public class AlunoPatchDto
    {
        /// <summary>
        /// Identificador e chave do banco de dados
        /// </summary>
        public int Id { get; set; }
        

        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        
        public bool Ativo { get; set; }

    }
}
