using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.V2.Dtos;
using SmartSchool.WebAPI.Model;

namespace SmartSchool.WebAPI.V2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {   

        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        public AlunoController(IRepository repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Metodo reponsavel para retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(){

            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));  
        }

        /// <summary>
        /// Metodo reponsavel por retornar apenas um único AlunoDTO.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {

            return Ok(new AlunoRegistrarDto());
        }

        /// <summary>
        /// Metodo reponsavel por retornar apenas um aluno por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id,AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno nao encontrado!");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Houve uma falha ao atualizar o Aluno!");
        }

  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno nao encontrado!");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Houve uma falha ao remover o Aluno!");
        }
    }
}