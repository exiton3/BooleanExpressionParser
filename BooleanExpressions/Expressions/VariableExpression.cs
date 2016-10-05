using System;
using BooleanExpressions.Visitors;

namespace BooleanExpressions.Expressions
{
	public sealed class VariableExpression : IBooleanExpression
	{
		private readonly string name;

		public VariableExpression(string name)
		{
			this.name = name;
		}

		public bool Evaluate(IContext context)
		{
			return context.Lookup(name);
		}

		public IBooleanExpression Replace(string s, IBooleanExpression exp)
		{
			if (s == name)
			{
				return exp.Copy();
			}
			return Copy();
		}

		public IBooleanExpression Copy()
		{
			return new VariableExpression(name);
		}

		public void Accept(IVisitor visitor)
		{
			visitor.Visit(this);
		}

		public string Name { get { return name; } }
	}
}