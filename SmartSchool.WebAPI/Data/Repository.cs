using SmartSchool.WebAPI.Model;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        // Alunos
        public Aluno[] GetAllAlunos()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] GetAllAlunosByDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Aluno[] GetAlunoById()
        {
            throw new System.NotImplementedException();
        }

        // Professores
        public Professor[] GetAllProfessores()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetAllProfessoresByDisciplinaId()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetProfessorById()
        {
            throw new System.NotImplementedException();
        }
    }
}
