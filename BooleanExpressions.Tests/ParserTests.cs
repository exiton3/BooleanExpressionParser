using BooleanExpressions.Expressions;
using BooleanExpressions.Lex;
using NUnit.Framework;

namespace BooleanExpressions.Tests
{
	[TestFixture]
	public class ParserTests
	{
		private Parser parser;

		[SetUp]
		public void SetUp()
		{
			parser = new Parser(new Tokenizer());
		}

		[Test]
		public void Parse_AndOperation_ReturnAndExpression()
		{
			//Arrange
			string input = "x and false or ";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression,Is.InstanceOf<AndExpression>());
		}


		[Test]
		public void Parse_NotOperation_ReturnNotExpression()
		{
			//Arrange
			string input = "not y";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression, Is.InstanceOf<NotExpression>());
		}

		[Test]
		public void Parse_OrOperation_ReturnOrExpression()
		{
			//Arrange
			string input = "x and true or x and not y";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression, Is.InstanceOf<OrExpression>());
		}

		[Test]
		public void Parse_BraketsOperation_ReturnAndExpression()
		{
			//Arrange
			string input = "z and (true or x) and y";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression, Is.InstanceOf<AndExpression>());
		}
		[Test]
		public void Parse_ManyAndOperation_ReturnAndExpression()
		{
			//Arrange
			string input = "x and y and z";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression, Is.InstanceOf<AndExpression>());
		}

		[Test]
		public void Parse_ManyOrOperation_ReturnOrExpression()
		{
			//Arrange
			string input = "x or y or z";
			//Act
			var expression = parser.Parse(input);
			//Assert
			Assert.That(expression, Is.InstanceOf<OrExpression>());
		}
	}
}