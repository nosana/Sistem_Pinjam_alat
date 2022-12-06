namespace WebAPi.Repositories.Interface
{
    public interface IRepository<Entity> where Entity : class
    {
        public IEnumerable<Entity> Get();
        public Entity GetById(int id);
        public int Create(Entity entity);
        public int Update(Entity entity);
        public int Delete(int id);
    }
}
