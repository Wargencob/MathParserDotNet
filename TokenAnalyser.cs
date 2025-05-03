using System.Text;

public static class TokenAnalyser
{
    internal static List<Token> Analys(string text)
    {
        List<Token> tokens = new List<Token>();
        Console.WriteLine(text.Length);
        int pos = 0;

        while (pos < text.Length)
        {
            char c = text[pos];
            switch (c)
            {
                case '(':
                    {
                        tokens.Add(new Token(TokenType.LEFT_BRACKET, c.ToString()));
                        pos++;
                        break;
                    }
                case ')':
                    {
                        tokens.Add(new Token(TokenType.RIGHT_BRACKET, c.ToString()));
                        pos++;
                        break;
                    }
                case '+':
                    {
                        tokens.Add(new Token(TokenType.LEX_PLUS, c.ToString()));
                        pos++;
                        break;
                    }
                case '-':
                    {
                        tokens.Add(new Token(TokenType.LEX_MINUS, c.ToString()));
                        pos++;
                        break;
                    }
                case '*':
                    {
                        tokens.Add(new Token(TokenType.LEX_MUL, c.ToString()));
                        pos++;
                        break;
                    }
                case '/':
                    {
                        tokens.Add(new Token(TokenType.LEX_DIV, c.ToString()));
                        pos++;
                        break;
                    }
                default:
                    {
                        if (text[pos] >= '0' && text[pos] <= '9')
                        {
                            StringBuilder stringBuilder = new StringBuilder();

                            do
                            {
                               stringBuilder.Append(text[pos]);
                                pos++;
                            }
                            while (pos < text.Length  && text[pos] >= '0' && text[pos] <= '9');

                            tokens.Add(new Token(TokenType.NUMBER, stringBuilder.ToString())); 

                            break;
                        }
                        else
                        {
                            pos++;
                            break;
                        }
                    }
            }
        }

        tokens.Add(new Token(TokenType.EOF, ""));

        return tokens;
    }
}