using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Model;
using System.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
           
            _repo = repo;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        // api/Professor/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id,true);
            if (professor == null) return BadRequest("Professor não foi encontrado!");

            return Ok(professor);
        }


        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Houve uma falha ao salvar o Professor!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado!");

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Ok(prof);
            }
            return BadRequest("Houve uma falha ao atualizar o Professor!");
            
        }

        [HttpPatch("{id}")]
        public IActionResult Path(int id, Professor professor)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado!");


            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Ok(prof);
            }
            return BadRequest("Houve uma falha ao atualizar o Professor!");

        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado!");

            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok(prof);
            }
            return BadRequest("Houve uma falha ao remover o Professor!");

        }
    }
}