using System.Collections.Generic;

public abstract class Node
{
    // Evalúa este nodo dado un valor de x
    public abstract double Evaluate(Dictionary<string, double> variables);
}

