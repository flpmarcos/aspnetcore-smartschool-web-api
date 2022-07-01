using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Model;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {   

        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        
        [HttpGet]
        public IActionResult Get(){

            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));  
        }
        
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Houve uma falha ao salvar o Aluno!");
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Houve uma falha ao atualizar o Aluno!");
        }

        [HttpPatch("{id}")]
        public IActionResult Path(int id,Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Houve uma falha ao atualizar o Aluno!");
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alu = _repo.GetAlunoById(id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");

            _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
                return Ok(alu);
            }
            return BadRequest("Houve uma falha ao remover o Aluno!");
        }
    }
}