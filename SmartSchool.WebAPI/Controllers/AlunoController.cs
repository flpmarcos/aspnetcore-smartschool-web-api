using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Model;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos= new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Felipe",
                Sobrenome = "Eufranio",
                Telefone = "1234fadsf56"
            },
            new Aluno(){
                Id = 2,
                Nome = "Thais",
                Sobrenome = "Eufranio",
                Telefone = "12345fad6"
            },
            new Aluno(){
                Id = 3,
                Nome = "Gustavo",
                Sobrenome = "Eufranio",
                Telefone = "12fad3456"
            }
        };

        public AlunoController(){}

        [HttpGet]
        public IActionResult Get(){
            return Ok(Alunos);
        }
        
        // api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
            );

            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Path(int id,Aluno aluno)
        {
            return Ok(aluno);
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}