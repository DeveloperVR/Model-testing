using System;

public class Parser
{
    private Tokenizer tokenizer;
    private Token currentToken;

    public Parser(Tokenizer tokenizer)
    {
        this.tokenizer = tokenizer;
        this.currentToken = tokenizer.GetNextToken();
    }

    private void Eat(TokenType type)
    {
        if (currentToken.Type == type)
        {
            currentToken = tokenizer.GetNextToken();
        }
        else
        {
            throw new Exception("Unexpected token: " + currentToken.Type);
        }
    }

    public Node Parse()
    {
        return Expr();
    }

    private Node Expr()
    {
        Node node = Term();

        while (currentToken.Type == TokenType.PLUS || currentToken.Type == TokenType.MINUS)
        {
            Token token = currentToken;
            Eat(token.Type);
            node = new BinOpNode(node, token, Term());
        }

        return node;
    }

    private Node Term()
    {
        Node node = Factor();

        while (currentToken.Type == TokenType.MULTIPLY || currentToken.Type == TokenType.DIVIDE)
        {
            Token token = currentToken;
            Eat(token.Type);
            node = new BinOpNode(node, token, Factor());
        }

        return node;
    }

    private Node Factor()
    {
        Token token = currentToken;

        if (token.Type == TokenType.PLUS || token.Type == TokenType.MINUS)
        {
            Eat(token.Type);
            return new UnaryOpNode(token, Factor());
        }

        return FunctionOrPower();
    }

    private Node FunctionOrPower()
    {
        Node node = Atom();

        if (currentToken.Type == TokenType.POWER)
        {
            Token token = currentToken;
            Eat(TokenType.POWER);
            node = new BinOpNode(node, token, Factor());
        }

        return node;
    }

    private Node Atom()
    {
        Token token = currentToken;

        if (token.Type == TokenType.NUMBER)
        {
            Eat(TokenType.NUMBER);
            return new NumNode(double.Parse(token.Text));
        }
        else if (token.Type == TokenType.VARIABLE)
        {
            Eat(TokenType.VARIABLE);
            return new VarNode(token.Text);
        }
        else if (token.Type == TokenType.SIN || token.Type == TokenType.COS)
        {
            Eat(token.Type);
            Eat(TokenType.LPAREN);
            Node argument = Expr();
            Eat(TokenType.RPAREN);
            return new FunctionNode(token, argument);
        }
        else if (token.Type == TokenType.LPAREN)
        {
            Eat(TokenType.LPAREN);
            Node node = Expr();
            Eat(TokenType.RPAREN);
            return node;
        }

        throw new Exception("Unexpected token: " + token.Type);
    }
}