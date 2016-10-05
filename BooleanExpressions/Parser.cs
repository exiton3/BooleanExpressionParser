using BooleanExpressions.Expressions;
using BooleanExpressions.Lex;

namespace BooleanExpressions
{
	//Grammar for boolean expressions
	//E  -> ReT
	//Re -> or T Re | e
	//T  -> RtF
	//Rt -> and F Rt | e
	//F -> not F | (E) | var | const

	public sealed class Parser
	{
		private readonly ITokenizer tokenizer;
		private Token currentToken;

		public Parser(ITokenizer tokenizer)
		{
			this.tokenizer = tokenizer;
		}

		public IBooleanExpression Parse(string input)
		{
			tokenizer.Tokenize(input);
			return Expression();
		}

		IBooleanExpression Expression()
		{
			return RestExpr(Term());
		}

		private IBooleanExpression RestExpr(IBooleanExpression exp)
		{
			var token = GetNextToken();
			if (token == null)
			{
				return exp;
			}

			if (token.Name == TokenKind.Or)
			{
				return RestExpr(new OrExpression(exp, Term()));
			}

			tokenizer.PushBack(token);
			return exp;
		}

		IBooleanExpression Term()
		{
			return RestTerm(Factor());
		}

		private IBooleanExpression RestTerm(IBooleanExpression exp)
		{
			var token = GetNextToken();
			if (token == null)
			{
				return exp;
			}

			if (token.Name == TokenKind.And)
			{
				return RestTerm(new AndExpression(exp, Factor()));
			}

			tokenizer.PushBack(token);
			return exp;
		}

		IBooleanExpression Factor()
		{
			IBooleanExpression expression = null;
			GetNextToken();
			switch (currentToken.Name)
			{
				case TokenKind.Constant:
					expression = new ConstantExpression(bool.Parse(currentToken.Value));
					break;
				case TokenKind.Variable:
					expression = new VariableExpression(currentToken.Value);
					break;
				case TokenKind.Not:
					expression = new NotExpression(Factor());
					break;
				case TokenKind.LParen:
					expression = Expression();
					GetNextToken();
					break;
			}
			return expression;
		}

		private Token GetNextToken()
		{
			return currentToken = tokenizer.GetNextToken();
		}
	}
}