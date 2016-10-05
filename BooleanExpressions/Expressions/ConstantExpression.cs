using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public sealed class ConstantExpression : IBooleanExpression
	{
		private readonly bool value;

		public ConstantExpression(bool value)
		{
			this.value = value;
		}

		public bool Value
		{
			get { return value; }
		}

		#region IBooleanExpression Members

		public bool Evaluate(IContext context)
		{
			return value;
		}

		public IBooleanExpression Replace(string s, IBooleanExpression exp)
		{
			return null;
		}

		public IBooleanExpression Copy()
		{
			return new ConstantExpression(value);
		}

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		#endregion
	}
}