namespace Task.MathParserRethinking
{
    public class Token
    {
        public readonly string Symbol;
        public readonly TokenType Type;

        public Token(string symbol, TokenType type)
        {
            Symbol = symbol;
            Type = type;
        }
    }
}