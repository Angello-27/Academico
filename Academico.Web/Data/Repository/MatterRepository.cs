namespace Academico.Web.Data.Repository
{
    using Entities;

    public class MatterRepository : GenericRepository<Matter>, IMatterRepository
    {
        public MatterRepository(DataContext context) : base(context)
        {
        }
    }
}
