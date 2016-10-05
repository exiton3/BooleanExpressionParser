using BooleanExpressions.Expressions;
using BooleanExpressions.Lex;
using BooleanExpressions.Visitors;
using Moq;
using NUnit.Framework;

namespace BooleanExpressions.Tests
{
	[TestFixture]
	public class BooleanExpressionsTests
	{
		private ITokenizer tokenizer;
		private Mock<IContext> context;

		[SetUp]
		public void SetUp()
		{
			context = new Mock<IContext>();
			context.Setup(x => x.Lookup("x")).Returns(true);
			context.Setup(x => x.Lookup("y")).Returns(false);
		}

		[Test]
		public void EvaluateSimpleExpression()
		{
			// true and x or  y and not x
			//Arrange
			var x = new VariableExpression("x");
			var y = new VariableExpression("y");

			var orExpression = new OrExpression(new AndExpression(new ConstantExpression(true), x),
												new AndExpression(y, new NotExpression(x)));

			//Act
			bool result = orExpression.Evaluate(context.Object);
			//Assert
			Assert.That(result, Is.EqualTo(true));
		}

		[Test]
		public void ParseExpressions()
		{
			//Arrange
			const string input = "true and x or y";
			tokenizer = new Tokenizer();
			var parser = new Parser(tokenizer);
			//Act
			var expression = parser.Parse(input);
			//Assert
			var result = expression.Evaluate(context.Object);
			expression.Accept(new PrintVisitor());
			Assert.That(result, Is.EqualTo(true));
		}

	}
}