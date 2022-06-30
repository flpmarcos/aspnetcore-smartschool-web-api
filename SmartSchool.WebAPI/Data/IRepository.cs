namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add();
        void Update();
        void Delete();
        bool SaveChanges();
    }
}
