public interface IExpression
{
    int Interpret();
}

public class Number : IExpression
{
    private readonly int _value;

    public Number(int value)
    {
        _value = value;
    }

    public int Interpret()
    {
        return _value;
    }
}

public class AddExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public AddExpression(IExpression left, IExpression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }

    public int Interpret()
    {
        return _leftExpression.Interpret() + _rightExpression.Interpret();
    }
}

public class MultiplyExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public MultiplyExpression(IExpression left, IExpression right)
    {
        _leftExpression = left;
        _rightExpression = right;
    }

    public int Interpret()
    {
        return _leftExpression.Interpret() * _rightExpression.Interpret();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Xây dựng biểu thức: 1 + (2 * 3)
        IExpression expression = new AddExpression(
            new Number(1),
            new MultiplyExpression(
                new Number(2),
                new Number(3)
            )
        );

        // Tính toán kết quả
        int result = expression.Interpret();

        // In kết quả: 1 + (2 * 3) = 7
        Console.WriteLine($"Result: {result}");
    }
}
