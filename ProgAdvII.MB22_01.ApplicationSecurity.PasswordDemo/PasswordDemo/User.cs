using System.Security.Cryptography;
using System.Text;

namespace PasswordDemo {
    // === Domain ===
    public sealed class User {
        public int Id { get; }
        public string Username { get; }
        public string Password { get; private set; } 
        public byte[] Salt { get; private set; }

        public User(int id, string username, string password) {
            Id = id;
            Username = username ?? throw new ArgumentNullException(nameof(username));
            SetPasswordHashedSalted(password);
        }

        public void SetPasswordPlaintext(string newPassword) {
            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
        }
        public void SetPasswordHashed(string newPassword)
        {
            var hashedPwd = SHA512.HashData(Encoding.ASCII.GetBytes(newPassword));
            var hashedPwdString = Convert.ToBase64String(hashedPwd);
            
            Password = hashedPwdString;
        }
        public void SetPasswordHashedSalted(string newPassword)
        {
            var hmacSha = new HMACSHA512();
            var hashedPwd = hmacSha.ComputeHash(Encoding.ASCII.GetBytes(newPassword));
            var hashedPwdString = Convert.ToBase64String(hashedPwd);


            Salt = hmacSha.Key;
            Password = hashedPwdString;
        }
        public bool VerifyPassword(string password)
        {
            var hmacSha = new HMACSHA512(Salt);
            var hashedPwd = hmacSha.ComputeHash(Encoding.ASCII.GetBytes(password));

            return Convert.ToBase64String(hashedPwd) == this.Password;
        }

        public override string ToString() {
            return $"{Id,2} | {Username,-15} | {Password}";
        }
    }
}
