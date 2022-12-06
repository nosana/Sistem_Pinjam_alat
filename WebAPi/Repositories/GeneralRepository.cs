using WebAPi.Context;
using WebAPi.Repositories.Interface;

namespace WebAPi.Repositories
{
    public class GeneralRepository<Entity> : IRepository<Entity>
       where Entity : class
    {
        MyContext myContext;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Create(Entity Entity)
        {
            myContext.Set<Entity>().Add(Entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var data = GetById(id);
            myContext.Set<Entity>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public IEnumerable<Entity> Get()
        {
            var data = myContext.Set<Entity>().ToList();
            return data;
        }

        public Entity GetById(int id)
        {
            var data = myContext.Set<Entity>().Find(id);
            return data;
        }

        public int Update(Entity Entity)
        {

            myContext.Set<Entity>().Update(Entity);
            var result = myContext.SaveChanges();
            return result;

        }

    }
}
