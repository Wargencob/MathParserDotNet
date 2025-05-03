namespace MathParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            string expressionText = "5 + ((1 + 2) * 4) - 3";

            var list = TokenAnalyser.Analys(expressionText);

            Shunting_Yard_Algorithm shunting_Yard_Algorithm = new Shunting_Yard_Algorithm();
            var result = shunting_Yard_Algorithm.Algorithm(list);

            Console.WriteLine(result);
        }
    }
}
