using System.Linq.Expressions;

namespace LinqExpressionTree {
    internal class Program {
        static void Main() {

            Samples();

            Expression<Func<Customer, bool>> expr = c => c.Name.StartsWith("Kehl") && c.City == "Au";

            // TODO: Diese Query korrekt übersetzen
            //Expression<Func<Customer, bool>> expr = c => c.Name.StartsWith("Kehl") && c.City == "Au" && c.Age >= 18 && !c.IsDeleted;

            string queryCondition = GenerateQueryCondition(expr);
            Console.WriteLine(queryCondition); 
        }

        static void Samples() {
            Func<int, bool> f = n => n < 5;

            var res = f(4);



            Expression<Func<int, bool>> e = n => n < 5;

            //Expression<Func<int, bool>> e = n => { 
            //    var x = n+2;
            //    return n < 5
            //  };



            var res2 = e.Compile()(40);





            BinaryExpression binary = (BinaryExpression)e.Body;
            Console.WriteLine(binary.Left);
            Console.WriteLine(binary.NodeType);
            Console.WriteLine(binary.Right);
        }

        static string GenerateQueryCondition(Expression<Func<Customer, bool>> expr) {
            return HandleExpression(expr.Body);
        }

        static string HandleExpression(Expression expr) {

            if (expr is BinaryExpression binaryExpr) {
                if (binaryExpr.NodeType == ExpressionType.AndAlso) {
                    // Behandeln der linken Seite des binären Ausdrucks
                    var left = HandleExpression(binaryExpr.Left);
                    // Behandeln der rechten Seite des binären Ausdrucks
                    var right = HandleExpression(binaryExpr.Right);
                    // Generieren der gesamten Bedingung
                    return $"{left} AND {right}";
                }

                if (binaryExpr.NodeType == ExpressionType.Equal) {
                    if (binaryExpr.Left is MemberExpression memberExpr && binaryExpr.Right is ConstantExpression constantExpr) {
                        var columnName = memberExpr.Member.Name;
                        var value = constantExpr.Value.ToString();
                        Console.WriteLine($"Handling: {expr.NodeType}, {expr.GetType().Name}");
                        return $"{columnName} = '{value}'";
                    }
                }
            }

            if (expr is MethodCallExpression callExpr) {
                // Prüfen, ob es sich um eine "StartsWith"-Methode handelt
                if (callExpr.Method.Name == "StartsWith" && callExpr.Object != null && callExpr.Arguments.Count == 1) {
                    if (callExpr.Arguments[0] is ConstantExpression constantExpr) {
                        var value = constantExpr.Value.ToString();
                        Console.WriteLine($"Handling: {expr.NodeType}, {expr.GetType().Name}");
                        return $"{GetColumnName(callExpr.Object)} LIKE '{value}%'";
                    }
                }
            } 
            return "[UNSUPPORTED]";
        }

        static string GetColumnName(Expression expr) {
            if (expr is MemberExpression memberExpr) {
                return memberExpr.Member.Name;  // Gibt den Namen der Eigenschaft zurück, z.B. 'Name' oder 'City'
            }
            return "undefinedColumn";  // Standardwert, falls keine passende Spalte gefunden wird
        }
    }

    public class Customer {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; }
    }
}
