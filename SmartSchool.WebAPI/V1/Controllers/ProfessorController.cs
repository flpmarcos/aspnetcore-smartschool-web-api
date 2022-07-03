using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Model;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.WebAPI.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
           _repo = repo;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistrarDto());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id,true);
            if (professor == null) return BadRequest("Professor não foi encontrado!");

            var professorDto = _mapper.Map<AlunoDto>(professor);

            return Ok(professorDto);

        }


        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Houve uma falha ao salvar o Professor!");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado!");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(prof));
            }
            return BadRequest("Houve uma falha ao atualizar o Professor!");
            
        }

        [HttpPatch("{id}")]
        public IActionResult Path(int id, ProfessorRegistrarDto model)
        {
            var prof = _repo.GetProfessorById(id);
            if (prof == null) return BadRequest("Professor nao encontrado!");

            _mapper.Map(model, prof);

            _repo.Update(prof);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<ProfessorDto>(prof));
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