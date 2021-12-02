namespace Task.MathParserRethinking
{
    public class NodeNumber : Node
    {
        private readonly double _number;

        public NodeNumber(double number) =>
            _number = number;

        public override double Eval() =>
            _number;
    }
}