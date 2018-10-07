﻿//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Collections.Generic;

//namespace Stryker.Core.Mutants.MutationHandlers
//{
//    public class MutationTernaryPlacer
//    {
//        public ExpressionSyntax HandleInsertMutation(ExpressionSyntax original, ExpressionSyntax mutated, int mutantId)
//        {
//            // place the mutated statement inside the if statement
//            IfStatementSyntax mutantIf = SyntaxFactory.ConditionalExpression(
//                condition: SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
//                SyntaxFactory.InvocationExpression(
//                    SyntaxFactory.MemberAccessExpression(
//                        SyntaxKind.SimpleMemberAccessExpression,
//                        SyntaxFactory.MemberAccessExpression(
//                            SyntaxKind.SimpleMemberAccessExpression,
//                            SyntaxFactory.IdentifierName("System"),
//                            SyntaxFactory.IdentifierName("Environment")
//                        ),
//                        SyntaxFactory.IdentifierName("GetEnvironmentVariable")),
//                    SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(
//                        new List<ArgumentSyntax>() {
//                    SyntaxFactory.Argument(SyntaxFactory.ExpressionStatement(
//                        SyntaxFactory.LiteralExpression(
//                            SyntaxKind.StringLiteralExpression,
//                            SyntaxFactory.Literal("ActiveMutation"))).Expression)
//                        }
//                    ))
//                ),
//                SyntaxFactory.LiteralExpression(
//                    SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(mutantId.ToString()))),
//                whenFalse: SyntaxFactory.Block(mutated),
//                whenTrue: SyntaxFactory.ElseClause(SyntaxFactory.Block(original)))
//                // Mark this node as a MutationTernary node. Store the MutantId in the annotation to retrace the mutant later
//                .WithAdditionalAnnotations(new SyntaxAnnotation("MutationTernary", mutantId.ToString()));

//            return mutantIf;
//        }

//        public override SyntaxNode HandleRemoveMutation(SyntaxNode node)
//        {
//            if(!node.HasAnnotation(new SyntaxAnnotation("MutationTernary")))
//            {
//                return _successor.HandleRemoveMutation(node);
//            } else
//            {
//                return (node as ConditionalExpressionSyntax).WhenFalse;
//            }
//        }
//    }
//}