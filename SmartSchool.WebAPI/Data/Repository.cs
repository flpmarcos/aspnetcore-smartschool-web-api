using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Model;
using System.Linq;
using System.Threading.Tasks;

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
        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                // Aqui estou fazendo leftjoin inicialmente com a disciplina do aluno e depois com o professor.
                query = query.Include(a => a.AlunosDisciplinas)
                     .ThenInclude(ad => ad.Disciplina)
                     .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();

        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                // Aqui estou fazendo leftjoin inicialmente com a disciplina do aluno e depois com o professor.
                query = query.Include(a => a.AlunosDisciplinas)
                     .ThenInclude(ad => ad.Disciplina)
                     .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();

        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor) 
            {   
                // left join com disciplina e professor
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            // asnotrancking para não ficar bloqueado
            // order by e where baseado no id da disciplina
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        // É Aluno e nao Aluno[] porque ele vai retornar um 
        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor) 
            {
                // Leftjoin com disciplina e professor baseado no parametro
                query = query.Include(a => a.AlunosDisciplinas)
                           .ThenInclude(ad => ad.Disciplina)
                           .ThenInclude(d => d.Professor);
            }

            // where baseado no id aluno
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id == alunoId);

            // FirstorDefault -> funcao do entity para pegar o primeiro
            return query.FirstOrDefault();
           
        }

        // Professores
        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                     .ThenInclude(d => d.AlunosDisciplinas)
                     .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();

        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                        .OrderBy(aluno => aluno.Id)
                        .Where(aluno => aluno.Disciplinas.Any(
                            d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)
                        ));

            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAluno)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunosDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            // where baseado no id aluno
            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(professor => professor.Id == professorId);

            // FirstorDefault -> funcao do entity para pegar o primeiro
            return query.FirstOrDefault();
        }
    }
}
