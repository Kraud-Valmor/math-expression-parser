using System;

namespace Task.MathParserRethinking
{
    public class NodeBinary : Node
    {
        public Node Left;
        public Node Right;
        public string Op;

        public NodeBinary(Node left, Node right, string op)
        {
            Left = left;
            Right = right;
            Op = op;
        }

        public override double Eval()
        {
            var left = Left.Eval();
            var right = Right.Eval();

            return Op switch
            {
                "^" => Math.Pow(left, right),
                "*" => left * right,
                "/" => left / right,
                "+" => left + right,
                "-" => left - right,
                _ => throw new Exception("invalid oper"),
            };
        }
    }
}