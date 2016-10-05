using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public abstract class BinaryExpression : IBooleanExpression
	{
		protected IBooleanExpression Left;
		protected IBooleanExpression Right;

		protected BinaryExpression(IBooleanExpression left, IBooleanExpression right)
		{
			Left = left;
			Right = right;
		}

		#region IBooleanExpression Members

		public abstract bool Evaluate(IContext context);

		public IBooleanExpression Replace(string s, IBooleanExpression exp)
		{
			return new AndExpression(Left.Replace(s, exp), Right.Replace(s, exp));
		}

		public IBooleanExpression Copy()
		{
			return new AndExpression(Left.Copy(), Right.Copy());
		}

		public abstract void Accept(IVisitor visitor);

		#endregion
	}
}