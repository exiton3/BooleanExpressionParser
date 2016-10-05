namespace BooleanExpressions.Expressions
{
	public interface IBooleanExpression : IVisitable
	{
		bool Evaluate(IContext context);
		IBooleanExpression Replace(string s, IBooleanExpression exp);
		IBooleanExpression Copy();
	}
}
