namespace PasswordDemo {
    public sealed class AuthService {
        private readonly IUserStore _store;

        public AuthService(IUserStore store) {
            _store = store;
        }

        public bool Register(string username, string password) {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {
                return false;
            }

            if (_store.FindByUsername(username) != null) {
                return false;
            }

            var user = new User(_store.NextId(), username, password);
            _store.Add(user);
            return true;
        }

        public bool Login(string username, string password) {
            var user = _store.FindByUsername(username);
            if (user == null) {
                return false;
            }

            return user.VerifyPassword(password);
        }
    }
}
