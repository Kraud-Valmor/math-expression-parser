namespace Task.MathParserRethinking
{
    public class NodeInBrackets : Node
    {
        private readonly Node _inner;

        public NodeInBrackets(Node inner) => _inner = inner;

        public override double Eval() => _inner.Eval();
    }
}