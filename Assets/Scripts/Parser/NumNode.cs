using System.Collections.Generic;

public class NumNode : Node
{
    private double value;

    public NumNode(double value)
    {
        this.value = value;
    }

    public override double Evaluate(Dictionary<string, double> variables)
    {
        return value;
    }
}
