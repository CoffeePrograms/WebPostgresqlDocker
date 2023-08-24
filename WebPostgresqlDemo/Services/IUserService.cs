namespace WebPostgresqlDemo.Services
{
    public interface IUserService
    {
        public Task<bool> VerifyEmail(Models.DataContext _context, string email);
    }
}
