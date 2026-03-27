using System;
using System.Collections.Generic;

public class FunctionNode : Node
{
    private Token function;
    private Node argument;

    public FunctionNode(Token function, Node argument)
    {
        this.function = function;
        this.argument = argument;
    }

    public override double Evaluate(Dictionary<string, double> variables)
    {
        double argVal = argument.Evaluate(variables);

        if (function.Type == TokenType.SIN)
        {
            return Math.Sin(argVal);
        }
        else if (function.Type == TokenType.COS)
        {
            return Math.Cos(argVal);
        }
        else
        {
            throw new Exception($"Unexpected function: {function.Type}");
        }
    }
}
