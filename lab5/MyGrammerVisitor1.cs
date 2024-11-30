using Antlr4.Runtime.Misc;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace lab5
{

    class MyGrammerVisitor : MyGrammerBaseVisitor<string>
    {
        private Dictionary<string, int?> variables = new Dictionary<string, int?>();

        // تخزين الكود المولد
        private StringBuilder generatedCode = new StringBuilder();

        public void SaveCodeToFile(string filePath)
        {
            File.WriteAllText(filePath, generatedCode.ToString());
        }

        RichTextBox _text;

        public MyGrammerVisitor(RichTextBox text)
        {

            _text = text;
        }

        public Dictionary<string, int?> GetVariables()
        {
            return variables;
        }

        public override string VisitProgram(MyGrammerParser.ProgramContext context)
        {
            generatedCode.AppendLine("#include <iostream>");
            generatedCode.AppendLine("#include <cstdlib>");

            generatedCode.AppendLine("using namespace std;");
            generatedCode.AppendLine("int main() {");

            if (context.statements() != null)
            {
                for (int i = 0; i < context.statements().Length; i++)
                {
                    generatedCode.AppendLine( Visit(context.statements()[i]));
                }
            }

            generatedCode.AppendLine("     system(\"pause\");");

            generatedCode.AppendLine("    return 0;");
            generatedCode.AppendLine("}");

            return null;
        }
        public override string VisitDeclarlist([NotNull] MyGrammerParser.DeclarlistContext context)
        {
            string declist = "";
            if(context.declar()!=null)
            {
                declist += Visit(context.declar());
            }
            if(context.declar2()!=null) {
                for (int i = 0;i < context.declar2().Length;i++)
                {
                    declist += " , " + Visit(context.declar2()[i]);
                }
            }
            declist += " ; ";
      
            return declist;
        }

        public override string VisitDeclar(MyGrammerParser.DeclarContext context)
        {
            string dec = "";
            dec += " int " + context.ID().GetText();

            
            if (context.expr() != null)
            {
                dec += " = " + Visit(context.expr()); 
            }
            else
            {    
                dec += " int " + context.ID().GetText();
            }
          
            return dec;
        }

        public override string VisitDeclar2(MyGrammerParser.Declar2Context context)
        {
            string dec = "";
             dec += context.ID().GetText();

            if (context.expr() != null)
            {
                dec += " = " + Visit(context.expr());
               
            }
            
            return dec;
        }

       
        public override string VisitForStatement(MyGrammerParser.ForStatementContext context)
        {
           string forStatement = "for ( ";
            if (context.firstPart() != null)
                forStatement+= Visit(context.firstPart())+" ; ";
          
            if (context.condition() != null)
               forStatement+= Visit(context.condition())+" ; ";
            
            if (context.lastPart() != null)
                forStatement += Visit(context.lastPart())+") { ";

            if (context.statements() != null)
                forStatement += Visit(context.statements())+" } ";
          
            return forStatement;
        }
        public override string VisitFirstPart([NotNull] MyGrammerParser.FirstPartContext context)
        {
            string fordecl="";
           
            if(context.INT() != null)
            {
                if (context.expr() != null)
                    fordecl += "int " + context.ID().GetText() + " = " + Visit(context.expr()); 
            }
            else
            {
                 if (context.expr() != null)
                    fordecl +=  context.ID().GetText() + " = " + Visit(context.expr());
            }

            return fordecl;
        }
        public override string VisitLastPart([NotNull] MyGrammerParser.LastPartContext context)
        {
            string lastpart = "";
            if (context.ID() != null)
            {
                 lastpart += context.ID().GetText();
               
                 
                    if (context.INCREASE() != null)
                    lastpart+= context.INCREASE().GetText();
             
                    if (context.DECREASE() != null)
                    lastpart+= context.DECREASE().GetText();
                  
            }

            return lastpart;
        }
        public override string VisitCondition(MyGrammerParser.ConditionContext context)
        {
            
            string left = Visit(context.expr(0));
            string right = Visit(context.expr(1));

            if (context.GT() != null)
            {
                return left+" > " + right ; // Return 1 for true, 0 for false
            }
            else if (context.GTORE() != null)
            {
                return left + " >= "+ right ;
            }
            else if (context.LT() != null)
            {
                return left + " < " + right ;
            }
            else if (context.LTORE() != null)
            {
                return left + " <= " + right ;
            }
            else if (context.EQUAL() != null)
            {
                return left + " == " + right ;
            }
            else if (context.NOTEQUAL() != null)
            {
                return left + " != " + right ;
            }

            throw new Exception("Invalid factor encountered");
            //return ""; // Default case
        }
       
        public override string VisitIfStatement([NotNull] MyGrammerParser.IfStatementContext context)
        {
            string ifstatement = "";
            if (context.condition() != null)
            {
                ifstatement += " if( " + Visit(context.condition()) +" ) { ";
                ifstatement += Visit(context.statements())+ " } ";
           
                if (context.elseifStatement() != null)
                {
                    for (int i = 0; i < context.elseifStatement().Length; i++)
                    {  
                        ifstatement += Visit(context.elseifStatement()[i]);
                    }
                }
                if (context.elseStatement() != null)
                {
                   ifstatement +=  Visit(context.elseStatement());
                }
            }
            return ifstatement;

        }

        public override string VisitElseifStatement([NotNull] MyGrammerParser.ElseifStatementContext context)
        {
            string elseifstate = " else if ( ";
            if (context.condition() != null)
            {
                elseifstate += Visit(context.condition()) + " ) { ";
                elseifstate+= Visit(context.statements()) +" } ";
               
            return elseifstate;
            }
            throw new Exception("Invalid factor encountered");
        }

        public override string VisitElseStatement([NotNull] MyGrammerParser.ElseStatementContext context)
        {
            string elsestat = " else { ";
            if (context.statements() != null)
            {
              elsestat+=  Visit(context.statements()) +" } ";
            return elsestat;
            }
            throw new Exception("Invalid factor encountered");
        }
        public override string VisitStatements(MyGrammerParser.StatementsContext context)
        {
            string statement = " ";

            if (context.declarlist() != null)
            {
                statement+= Visit(context.declarlist()) +" \n ";
            }

            else if (context.forStatement() != null)
            {
                statement += Visit(context.forStatement()) +" \n ";
            }
            else if (context.ifStatement() != null)
            {
                statement += Visit(context.ifStatement())+" \n ";
            }
            else if (context.prints() != null)
            {
                statement += Visit(context.prints())+" \n ";
            }

            return statement;
        }

        public override string VisitPrints(MyGrammerParser.PrintsContext context)
        {
            string print = "";
            string str = "";
            if (context.STRING() != null )
            {
                str = context.STRING().GetText();
                str = str.Substring(1);
                str = str.Remove(str.Length - 1);
                print+= $"\"{str} \"";
            }
            else if(context.expr()[0] != null)
            {
                print += Visit(context.expr()[0]);
            }


            if (str.Trim() !="" && context.expr()[0] != null)
            {
                print +=   " <<" + Visit(context.expr()[0]);
            }
            if (context.expr(1) != null) {
               print += " << " + Visit(context.expr(1));
            }
            print += " <<endl;";
               
            return "cout<<" + print;
        }

        public override string VisitExpr(MyGrammerParser.ExprContext context)
        {
            if (context.PLUS() != null)
            {
                return Visit(context.expr()) + " + " + Visit(context.term());
            }
            else if (context.MINUS() != null)
            {
                return Visit(context.expr()) + " - " + Visit(context.term());

            }

            return Visit(context.term());
        }

        public override string VisitTerm(MyGrammerParser.TermContext context)
        {
            if (context.MUL() != null)
            {
                return Visit(context.term()) + " * " + Visit(context.factor());
            }
            else if (context.DIV() != null)
            {
                return Visit(context.term()) + " / " + Visit(context.factor());
            }
            else if (context.MOD() != null)
            {
                return Visit(context.term()) + " % " + Visit(context.factor());
            }

            return Visit(context.factor());
        }

        public override string VisitFactor(MyGrammerParser.FactorContext context)
        {
            if (context.NUMBER() != null)
            {
                return context.NUMBER().GetText();
            }
            else if (context.LIFT() != null)
            {
                return "("+Visit(context.expr())+")";
            }
            else if (context.ID() != null)
            {
                return context.ID().GetText();
            }

            throw new Exception("Invalid factor encountered");
        }
    }


}

