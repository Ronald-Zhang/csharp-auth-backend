using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;

        }

        public User Register(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Password = dto.Password
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User Login(LoginDto dto)
        {
            return _context.Users
                .FirstOrDefault(x => x.Username == dto.Username && x.Password == dto.Password);
        }
    }
}