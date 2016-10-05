using System;
using BooleanExpressions.Expressions;

namespace BooleanExpressions.Visitors
{
	public class PrintVisitor : IVisitor
	{
		public void Visit(NotExpression expression)
		{
			Console.Write("Not ");
		}

		public void Visit(OrExpression expression)
		{
			Console.Write("Or ");

		}

		public void Visit(AndExpression expression)
		{
			Console.Write("And ");

		}

		public void Visit(ConstantExpression expression)
		{
			Console.Write("{0} ", expression.Value);

		}

		public void Visit(VariableExpression expression)
		{
			Console.Write("{0} ", expression.Name);

		}
	}
}