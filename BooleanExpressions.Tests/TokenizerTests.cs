using System;
using System.Linq;
using BooleanExpressions.Lex;
using NUnit.Framework;

namespace BooleanExpressions.Tests
{
	[TestFixture]
	public class TokenizerTests
	{
		private Tokenizer tokenizer;

		[SetUp]
		public void SetUp()
		{
			tokenizer = new Tokenizer();
		}

		[Test]
		public void TokenizeShouldParse()
		{
			//Arrange
			string input = "true and x or (y and not x)";
			//Act
			var tokens = tokenizer.Tokenize(input);
			//Assert
			foreach (var token in tokens)
			{
				Console.WriteLine("{0} - {1}", token.Name, token.Value);
			}
			
		}

		[Test]
		public void TokinizeStringWithBrakets_ReturnLParenAndRParenToken()
		{
			//Arrange 
			string input = "x and (y)";
			//Act
			var tokens = tokenizer.Tokenize(input).Select(x=>x.Name);
			//Assert
			Assert.That(tokens,Has.Some.EqualTo(TokenKind.LParen));
			Assert.That(tokens,Has.Some.EqualTo(TokenKind.RParen));
		}


	}

}