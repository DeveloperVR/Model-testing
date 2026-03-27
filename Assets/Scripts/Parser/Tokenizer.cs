using System;
using System.Text.RegularExpressions;

public class Tokenizer
{
    private string input;
    private int pos;

    public Tokenizer(string input)
    {
        // Elimina todos los espacios en blanco
        this.input = Regex.Replace(input, @"\s+", "");
        this.pos = 0;
    }

    public Token GetNextToken()
    {
        if (pos >= input.Length)
        {
            return new Token(TokenType.EOF, "");
        }

        char currentChar = input[pos];

        if (char.IsDigit(currentChar))
        {
            return Number();
        }

        if (char.IsLetter(currentChar))
        {
            return Identifier();
        }

        switch (currentChar)
        {
            case '+':
                pos++;
                return new Token(TokenType.PLUS, "+");
            case '-':
                pos++;
                return new Token(TokenType.MINUS, "-");
            case '*':
                pos++;
                return new Token(TokenType.MULTIPLY, "*");
            case '/':
                pos++;
                return new Token(TokenType.DIVIDE, "/");
            case '^':
                pos++;
                return new Token(TokenType.POWER, "^");
            case '(':
                pos++;
                return new Token(TokenType.LPAREN, "(");
            case ')':
                pos++;
                return new Token(TokenType.RPAREN, ")");
            default:
                throw new Exception("Invalid character: " + currentChar);
        }
    }

    private Token Number()
    {
        int start = pos;
        while (pos < input.Length && (char.IsDigit(input[pos]) || input[pos] == '.'))
        {
            pos++;
        }
        string value = input.Substring(start, pos - start);
        return new Token(TokenType.NUMBER, value);
    }

    private Token Identifier()
    {
        int start = pos;
        while (pos < input.Length && char.IsLetter(input[pos]))
        {
            pos++;
        }
        string name = input.Substring(start, pos - start);

        if (name == "sin") return new Token(TokenType.SIN, name);
        if (name == "cos") return new Token(TokenType.COS, name);

        return new Token(TokenType.VARIABLE, name);
    }
}