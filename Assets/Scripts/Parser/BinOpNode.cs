using System;
using System.Collections.Generic;

public class BinOpNode : Node
{
    private Node left;
    private Node right;
    private Token op;

    public BinOpNode(Node left, Token operatorType, Node right)
    {
        this.left = left;
        this.op = operatorType;
        this.right = right;
    }

    public override double Evaluate(Dictionary<string, double> variables)
    {
        double l = left.Evaluate(variables);
        double r = right.Evaluate(variables);

        switch (op.Type)
        {
            case TokenType.PLUS:
                return l + r;
            case TokenType.MINUS:
                return l - r;
            case TokenType.MULTIPLY:
                return l * r;
            case TokenType.DIVIDE:
                return l / r;
            case TokenType.POWER:
                return Math.Pow(l, r);
            default:
                throw new Exception($"Unknown binary operator: {op}");
        }
    }
}
