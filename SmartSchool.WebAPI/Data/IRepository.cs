using SmartSchool.WebAPI.Model;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByDisciplinaId();
        Aluno[] GetAlunoById();

        // Professor
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplinaId();
        Professor[] GetProfessorById();

    }
}
