//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from MyGrammer.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MyGrammerParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public interface IMyGrammerVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] MyGrammerParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.declarlist"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarlist([NotNull] MyGrammerParser.DeclarlistContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] MyGrammerParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] MyGrammerParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.elseifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseifStatement([NotNull] MyGrammerParser.ElseifStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStatement([NotNull] MyGrammerParser.ElseStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.declar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclar([NotNull] MyGrammerParser.DeclarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.declar2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclar2([NotNull] MyGrammerParser.Declar2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.firstPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFirstPart([NotNull] MyGrammerParser.FirstPartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.lastPart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLastPart([NotNull] MyGrammerParser.LastPartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.condition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCondition([NotNull] MyGrammerParser.ConditionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatements([NotNull] MyGrammerParser.StatementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.prints"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrints([NotNull] MyGrammerParser.PrintsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] MyGrammerParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerm([NotNull] MyGrammerParser.TermContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MyGrammerParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFactor([NotNull] MyGrammerParser.FactorContext context);
}
