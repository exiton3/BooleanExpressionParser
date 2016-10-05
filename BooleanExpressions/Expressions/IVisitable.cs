using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public interface IVisitable
	{
		void Accept(IVisitor visitor);
	}
}