using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams,bool includeProfessor = false);

        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        // Professor
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);
        Professor GetProfessorById(int professorId, bool includeAluno = false);

        Professor[] GetProfessorByAlunoId(int alunoId, bool includeAluno = true);
    }
}
