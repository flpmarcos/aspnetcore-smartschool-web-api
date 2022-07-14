using System.Collections.Generic;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.Model.V1.Dto
{
    public class DisciplinaDto
    {
        public int Id { get; set; }   
        public string Nome { get; set; }

        public int CargaHorario { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        // Cria relacionamento de pre-requisito com disciplina
        public int? PrerequisitoId { get; set; } = null;
        
        public int CursoId { get; set; }
        
        public CursoDto Curso { get; set; }

        public IEnumerable<AlunoDto> Alunos { get; set; }

    }
}