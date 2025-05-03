public abstract class ExpNode { }
public class NumberNode : ExpNode
{
    public Token NumberToken {  get; }
        
    public NumberNode(Token NumberToken) => this.NumberToken = NumberToken;
}
public class BinaryNode : ExpNode
{
    public Token BinaryToken { get; }
    public ExpNode Left;
    public ExpNode Right;
    public BinaryNode(Token BinaryToken, ExpNode Left, ExpNode Right)
    {
        this.BinaryToken = BinaryToken;
        this.Left = Left;
        this.Right = Right;
    }
}

public static class TreeBuilder
{
    public static ExpNode BuildFromRPN(List<Token> tokens)
    {
        var stack = new Stack<ExpNode>();

        foreach (var token in tokens)
        {
            if (token.type == TokenType.NUMBER)
            {
                stack.Push(new NumberNode(token));
            }
            else if (token.type == TokenType.LEX_PLUS || 
                token.type == TokenType.LEX_MINUS || 
                token.type == TokenType.LEX_DIV ||
                token.type == TokenType.LEX_MUL)
            {
                var right = stack.Pop();
                var left = stack.Pop();

                stack.Push(new BinaryNode(token, left, right));
            }
        }

        return stack.Pop();
    }
}
static class TreePrinter
{
    public static void Print(ExpNode node, string indent = "", bool isLast = true)
    {
        switch (node)
        {
            case NumberNode n:
                Console.WriteLine(indent + (isLast ? "└─ " : "├─ ") + n.NumberToken.value);
                break;
            case BinaryNode b:
                Console.WriteLine(indent + (isLast ? "└─ " : "├─ ") + b.BinaryToken.value);
                indent += isLast ? "   " : "│  ";
                Print(b.Left, indent, false);
                Print(b.Right, indent, true);
                break;
        }
    }
}

static class Evalutetor
{
    public static double Evaluate(ExpNode node)
    {
        return node switch
        {
            NumberNode n => Convert.ToDouble(n.NumberToken.value),

            BinaryNode b => b.BinaryToken.value switch
            {
                "+" => Evaluate(b.Left) + Evaluate(b.Right),
                "-" => Evaluate(b.Left) - Evaluate(b.Right),
                "*" => Evaluate(b.Left) * Evaluate(b.Right),
                "/" => Evaluate(b.Left) / Evaluate(b.Right),
            },

            _ => throw new InvalidOperationException("Unknown node type")
        };
    }
}
