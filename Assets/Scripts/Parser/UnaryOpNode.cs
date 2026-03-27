using System;
using System.Collections.Generic;

public class UnaryOpNode : Node
{
    private Token op;
    private Node expr;

    public UnaryOpNode(Token op, Node expr)
    {
        this.op = op;
        this.expr = expr;
    }

    public override double Evaluate(Dictionary<string, double> variables)
    {
        double val = expr.Evaluate(variables);
        return op.Type == TokenType.MINUS ? -val : val;
    }
}
