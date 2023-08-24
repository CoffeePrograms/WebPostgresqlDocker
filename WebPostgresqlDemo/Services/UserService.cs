using Microsoft.EntityFrameworkCore;

namespace WebPostgresqlDemo.Services
{
    public class UserService : IUserService
    {
        public async Task<bool> VerifyEmail(Models.DataContext _context, string email)
        {
            return await _context.Users.AsNoTracking().Where(l => l.Email == email).FirstOrDefaultAsync() == null;
        }
    }
}
