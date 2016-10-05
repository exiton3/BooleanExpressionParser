using BooleanExpressions.Expressions;

namespace BooleanExpressions.Visitors
{
	public class Visitor : IVisitor
	{
		public virtual void Visit(NotExpression expression)
		{
			
		}

		public virtual void Visit(OrExpression expression)
		{
			
		}

		public virtual void Visit(AndExpression expression)
		{
		}

		public virtual void Visit(ConstantExpression expression)
		{
		}

		public virtual void Visit(VariableExpression expression)
		{
		}
	}
}