using System.Collections.Generic;
using System.Linq;
using BooleanExpressions.Expressions;

namespace BooleanExpressions.Visitors
{
	class VariableVisitor : Visitor
	{
		private readonly List<string> variables;

		public VariableVisitor()
		{
			variables = new List<string>();
		}
		public override void Visit(VariableExpression expression)
		{
			variables.Add(expression.Name);
		}

		public IEnumerable<string> Variables { get { return variables.Distinct(); } }
	}
}