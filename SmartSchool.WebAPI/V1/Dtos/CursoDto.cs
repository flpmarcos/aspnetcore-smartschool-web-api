using System.Collections.Generic;
using SmartSchool.WebAPI.Model.V1.Dto;

namespace SmartSchool.WebAPI.Model.V1.Dto
{
    public class CursoDto
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<DisciplinaDto> Disciplinas { get; set; }
    }
}
