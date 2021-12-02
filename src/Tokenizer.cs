using System;
using System.Collections.Generic;

namespace Task.MathParserRethinking
{
    public static class Tokenizer
    {
        public static List<Token> Tokens(string text)
        {
            var tokens = new List<Token>();
            int index = 0;

            while (index < text.Length)
                Add(tokens, text, ref index);

            return tokens;
        }

        private static void Add(List<Token> tokens, string text, ref int index)
        {
            if (IsBracket(text[index]))
                tokens.Add(Token(text, ref index, TokenType.Bracket));
            else if (IsOper(text[index]))
                tokens.Add(Token(text, ref index, TokenType.Oper));
            else if (char.IsDigit(text[index]))
                tokens.Add(Number(text, ref index));
            else if (text[index] == ' ')
                index++;
            else
                throw new Exception("Invalid character");
        }

        private static Token Token(string text, ref int index, TokenType type) =>
            new Token(text[index++].ToString(), type);

        private static Token Number(string text, ref int index)
        {
            var start = index;

            Digits(text, ref index);

            if (index < text.Length && text[index] == ',')
            {
                index++;

                Digits(text, ref index);
            }

            return new Token(text.Substring(start, index - start), TokenType.Number);

            static void Digits(string text, ref int index)
            {
                var start = index;

                while (index < text.Length && char.IsDigit(text[index]))
                    index++;

                if (start == index)
                    throw new Exception("Invalid character");
            }
        }

        private static bool IsBracket(char c) => "()".Contains(c);
        private static bool IsOper(char c) => "+-*/^".Contains(c);
    }
}