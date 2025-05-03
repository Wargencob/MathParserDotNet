using System;
using System.Collections.Generic;
using System.Text;

public class Shunting_Yard_Algorithm
{
    private Stack<Token> stack;

    public Shunting_Yard_Algorithm()
    {
        stack = new Stack<Token>();
    }

    public string Algorithm(List<Token> inputTokens)
    {
        List<Token> output = new List<Token>();
        StringBuilder result = new StringBuilder();

        foreach (var token in inputTokens)
        {
            switch (token.type)
            {
                case TokenType.NUMBER:
                    output.Add(token);
                    break;

                case TokenType.LEFT_BRACKET:
                    stack.Push(token);
                    break;

                case TokenType.RIGHT_BRACKET:
                    while (stack.Count > 0 && stack.Peek().type != TokenType.LEFT_BRACKET)
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Pop();
                    break;

                case TokenType.LEX_PLUS:
                case TokenType.LEX_MINUS:
                case TokenType.LEX_MUL:
                case TokenType.LEX_DIV:
                    while (stack.Count > 0 &&
                           stack.Peek().type != TokenType.LEFT_BRACKET &&
                           GetPrecedence(stack.Peek()) >= GetPrecedence(token))
                    {
                        output.Add(stack.Pop());
                    }
                    stack.Push(token);
                    break;

                case TokenType.EOF:
                    while (stack.Count > 0)
                    {
                        if (stack.Peek().type == TokenType.LEFT_BRACKET)
                            throw new InvalidOperationException("Mismatched parentheses");
                        output.Add(stack.Pop());
                    }
                    break;
            }
        }

        foreach (var t in output)
        {
            result.Append(t.value);
        }

        return result.ToString().Trim();
    }

    private int GetPrecedence(Token token)
    {
        return token.type switch
        {
            TokenType.LEX_PLUS => 1,
            TokenType.LEX_MINUS => 1,
            TokenType.LEX_MUL => 2,
            TokenType.LEX_DIV => 2,
            _ => 0
        };
    }
}