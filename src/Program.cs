using System.Text;

namespace MathParser
{
    public class Program
    {
        static void Main(string[] args)
        {
            string expressionText = "(1 + 1)^2";

            StringBuilder r = new StringBuilder(); 

            var list = TokenAnalyser.Analys(expressionText);

            Shunting_Yard_Algorithm shunting_Yard_Algorithm = new Shunting_Yard_Algorithm();
            var result = shunting_Yard_Algorithm.Algorithm(list);

            var node = TreeBuilder.BuildFromRPN(result);

            Console.WriteLine(Evalutetor.Evaluate(node)); 
        }
    }
}
