namespace PasswordDemo {
    // === Persistence (Mock) ===
    public interface IUserStore {
        IEnumerable<User> GetAll();
        User? FindByUsername(string username);
        void Add(User user);
        int NextId();
    }

    public sealed class InMemoryUserStore : IUserStore {
        private readonly List<User> _users;

        public InMemoryUserStore(IEnumerable<User>? seed = null) {
            _users = seed?.ToList() ?? new List<User>();
        }

        public IEnumerable<User> GetAll() {
            // V1: keine Privileg-Pruefung -> bewusst unsicher
            return _users;
        }

        public User? FindByUsername(string username) {
            return _users.FirstOrDefault(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(User user) {
            if (FindByUsername(user.Username) != null) {
                throw new InvalidOperationException("User existiert bereits.");
            }
            _users.Add(user);
        }

        public int NextId() {
            if (_users.Count == 0) {
                return 1;
            }
            return _users.Max(u => u.Id) + 1;
        }
    }
}
