
namespace Lab3.Parsers
{
    public delegate bool CheckerDelegate(string str);

    public class Checker
    {
        public static readonly Dictionary<TypeCode, CheckerDelegate> Checkers = new Dictionary<TypeCode, CheckerDelegate>()
        {
            [TypeCode.Int32] = Checker.IsInt,
            [TypeCode.String] = Checker.IsString,
            [TypeCode.Double] = Checker.IsDouble,
            [TypeCode.Boolean] = Checker.IsBool,
        };

        public static bool IsInt(string str)
        {
            return Int32.TryParse(str, out _);
        }
        public static bool IsString(string str)
        {
            return true;
        }
        public static bool IsDouble(string str)
        {
            return Double.TryParse(str, out _);
        }
        public static bool IsBool(string str)
        {
            return (str == "yes" || str == "no");
        }
    }
}