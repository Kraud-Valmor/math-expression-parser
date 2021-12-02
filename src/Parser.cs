using System;
using System.Collections.Generic;

namespace Task.MathParserRethinking
{
    public static class Parser
    {
        public static Node Tree(List<Token> tokens)
        {
            int index = 0;

            return Tree(tokens, ref index);
        }

        private static Node Tree(List<Token> tokens, ref int index)
        {
            var node = Operand(tokens, ref index);

            while (index < tokens.Count && tokens[index].Symbol != ")")
            {
                if (tokens[index].Type != TokenType.Oper)
                    throw new Exception("Invalid exp build");

                var oper = tokens[index++].Symbol;
                var right = Operand(tokens, ref index);

                if (node is NodeBinary binary && Priority(oper) > Priority(binary.Op))
                    binary.Right = new NodeBinary(binary.Right, right, oper);
                else
                    node = new NodeBinary(node, right, oper);
            }

            index++;
            return node;
        }

        private static Node Operand(List<Token> tokens, ref int index)
        {
            var token = tokens[index];

            if (token.Type == TokenType.Number)
            {
                return Number(tokens, ref index);
            }
            else if (token.Symbol == "(")
            {
                index++;

                return new NodeInBrackets(Tree(tokens, ref index));
            }
            else if (token.Symbol == "+" || token.Symbol == "-")
            {
                return Unary(tokens, ref index);
            }
            else
            {
                throw new Exception("Invalid node starting token");
            }
        }

        private static Node Number(List<Token> tokens, ref int index) =>
            new NodeNumber(double.Parse(tokens[index++].Symbol));

        private static Node Unary(List<Token> tokens, ref int index)
        {
            var sign = tokens[index++].Symbol;
            var node = Operand(tokens, ref index);

            return new NodeUnary(node, sign);
        }

        private static int Priority(string oper) =>
            oper switch
            {
                "^" => 3,
                "*" or "/" => 2,
                "+" or "-" => 1,
                _ => 0,
            };
    }
}