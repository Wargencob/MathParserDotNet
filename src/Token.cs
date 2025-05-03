public class Token
{
    public TokenType type {  get; private set; }
    public string value { get; private set; }

    public Token(TokenType type, string value)
    {
        this.type = type;
        this.value = value;
    }
    public Token(TokenType type, char[] value)
    {
        this.type = type;
        this.value = value.ToString();
    }
}