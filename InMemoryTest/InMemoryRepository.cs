using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InMemoryTest
{
    internal class InMemoryRepository<T>
        where T : class
    {
        private readonly InMemoryContext _context;

        public InMemoryRepository(InMemoryContext context)
        {
            _context = context;
        }

        public Task<T?> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefaultAsync();
        }
    }
}
