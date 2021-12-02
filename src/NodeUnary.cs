using System;

namespace Task.MathParserRethinking
{
    public class NodeUnary : Node
    {
        private readonly Node _inner;
        private readonly string _sign;

        public NodeUnary(Node inner, string sign)
        {
            _inner = inner;
            _sign = sign;
        }

        public override double Eval() => _sign switch
        {
            "+" => _inner.Eval(),
            "-" => -_inner.Eval(),
            _ => throw new Exception("invalid unary operator"),
        };
    }
}