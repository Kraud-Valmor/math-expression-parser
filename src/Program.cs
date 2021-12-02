using System;

namespace Task.MathParserRethinking
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var tokens = Tokenizer.Tokens(input);
            var tree = Parser.Tree(tokens);

            Console.WriteLine(tree.Eval());
            
            Console.ReadKey();
        }
    }
}