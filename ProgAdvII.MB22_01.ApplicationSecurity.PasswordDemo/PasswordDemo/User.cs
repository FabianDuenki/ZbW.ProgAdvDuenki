namespace PasswordDemo {
    // === Domain ===
    public sealed class User {
        public int Id { get; }
        public string Username { get; }
        public string Password { get; private set; } 

        public User(int id, string username, string password) {
            Id = id;
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public void SetPasswordPlaintext(string newPassword) {
            Password = newPassword ?? throw new ArgumentNullException(nameof(newPassword));
        }

        public override string ToString() {
            return $"{Id,2} | {Username,-15} | {Password}";
        }
    }
}
