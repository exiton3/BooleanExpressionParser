using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public sealed class NotExpression : IBooleanExpression
	{
		private readonly IBooleanExpression expression;

		public NotExpression(IBooleanExpression expression)
		{
			this.expression = expression;
		}

		public bool Evaluate(IContext context)
		{
			return !expression.Evaluate(context);
		}

		public IBooleanExpression Replace(string s, IBooleanExpression exp)
		{
			return new NotExpression(expression.Replace(s, exp));
		}

		public IBooleanExpression Copy()
		{
			return expression.Copy();
		}

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}