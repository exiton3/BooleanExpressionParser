using BooleanExpressions.Expressions;

namespace BooleanExpressions.Visitors
{
	public interface IVisitor
	{
		void Visit(NotExpression expression);
		void Visit(OrExpression expression);
		void Visit(AndExpression expression);
		void Visit(ConstantExpression expression);
		void Visit(VariableExpression expression);
	}
}