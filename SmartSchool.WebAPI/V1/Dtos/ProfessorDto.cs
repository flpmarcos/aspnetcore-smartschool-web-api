using System;
using System.Collections.Generic;
using SmartSchool.WebAPI.Model.V1.Dto;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorDto
    {

        public int Id { get; set; }

        public int Registro { get; set; }

        public string Nome { get; set; }

        public DateTime DataIni { get; set; } 

        public bool Ativo { get; set; } = true;

        public IEnumerable<DisciplinaDto> Disciplinas { get; set; }

    }
}
