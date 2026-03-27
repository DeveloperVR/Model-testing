using System;
using System.Collections.Generic;

public class VarNode : Node
{
    private string name;

    public VarNode(string name)
    {
        this.name = name;
    }

    public override double Evaluate(Dictionary<string, double> variables)
    {
        if (!variables.ContainsKey(name))
        {
            throw new Exception($"Variable '{name}' is not defined.");
        }
        return variables[name];
    }
}
