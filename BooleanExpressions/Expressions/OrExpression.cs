using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public sealed class OrExpression : BinaryExpression
	{
		public OrExpression(IBooleanExpression left, IBooleanExpression right)
			: base(left, right)
		{
		}

		public override bool Evaluate(IContext context)
		{
			return Left.Evaluate(context) || Right.Evaluate(context);
		}

		public override void Accept(IVisitor visitor)
		{
			Left.Accept(visitor);
			visitor.Visit(this);
			Right.Accept(visitor);

		}
	}
}