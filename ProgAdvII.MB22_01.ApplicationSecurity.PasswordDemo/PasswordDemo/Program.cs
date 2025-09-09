using System.Security.Cryptography;
using System.Text;

namespace PasswordDemo {
    internal static class Program {
        private static void Main() {
            // Seed mit typischen schwachen Passwoertern
            var store = GetUserStore();

            var auth = new AuthService(store);

            while (true) {
                Console.WriteLine();
                Console.WriteLine("=== Password-Demo ===");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Register");
                Console.WriteLine("3) Simuliere Datenleck");
                Console.WriteLine("0) Exit");
                Console.Write("Auswahl: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0") {
                    break;
                }

                switch (choice) {
                    case "1": {
                            Console.Write("Username: ");
                            var user = Console.ReadLine() ?? string.Empty;
                            Console.Write("Passwort: ");
                            var pass = ReadPassword();

                            var ok = auth.Login(user, pass);
                            if (ok) {
                                Console.WriteLine("Login OK.");
                            } else {
                                Console.WriteLine("Login fehlgeschlagen.");
                            }
                            break;
                        }
                    case "2": {
                            Console.Write("Neuer Username: ");
                            var user = Console.ReadLine() ?? string.Empty;
                            Console.Write("Neues Passwort: ");
                            var pass = ReadPassword();

                            var ok = auth.Register(user, pass);
                            if (ok) {
                                Console.WriteLine("User registriert.");
                            } else {
                                Console.WriteLine("Registrierung fehlgeschlagen (User existiert oder Eingabe ungueltig).");
                            }
                            break;
                        }
                    case "3": {
                            // „Angreifer“/Insider-Demo: Dump zeigt sofort alle Klartext-Passwoerter
                            Console.WriteLine("!!!          DATENLECK / DUMP          !!!");
                            Console.WriteLine("ID | Username        | Passwort (Klartext)");
                            Console.WriteLine("-------------------------------------------");
                            foreach (var u in store.GetAll()) {
                                Console.WriteLine(u.ToString());
                            }
                            Console.WriteLine("-------------------------------------------");
                            break;
                        }
                    default: {
                            Console.WriteLine("Unbekannte Auswahl.");
                            break;
                        }
                }
            }
        }

        // Einfache Passwort-Eingabe ohne Echo
        private static string ReadPassword() {
            var pwd = string.Empty;
            ConsoleKeyInfo key;
            while (true) {
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter) {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace) {
                    if (pwd.Length > 0) {
                        pwd = pwd[..^1];
                        Console.Write("\b \b");
                    }
                    continue;
                }
                pwd += key.KeyChar;
                Console.Write("*");
            }
            return pwd;
        }

        private static InMemoryUserStore GetUserStore() {
            return new InMemoryUserStore(new[]
            {
                new User(1, "alice", "123456"),
                new User(2, "bob", "password1"),
                new User(3, "charlie", "password2"),
                new User(4, "dora", "abcdef"),
                new User(5, "erik", "password3"),
                new User(6, "tk", "Thomas1977")
            });
        }
    }
}
