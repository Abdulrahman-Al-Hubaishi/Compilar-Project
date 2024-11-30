using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


using System.IO;
using static System.Windows.Forms.AxHost;

namespace lab1
{
    using Antlr4.Runtime.Misc;
    using lab5;
    using System.Diagnostics;
    using System.Drawing.Text;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string input = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            input = "";
        }
        AntlrInputStream inputStreem;
        MyGrammerLexer lexer;
        CommonTokenStream lTS;
        MyGrammerParser parser;


        Dictionary<string, int> doc = new Dictionary<string, int>();

        private void RunCode()
        {

            if (richTextBox1.Text.Length > 0)
            {

                input = ""; // richTextBox1.Text.ToString();
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    input += richTextBox1.Lines[i];
                }


                string cppFilePath = "C:\\Users\\Computer\\Desktop\\رابع تقنية\\مترجمات عملي\\Project Compilar\\lab5\\codeOut.cpp";
                string exeFilePath = "C:\\Users\\Computer\\Desktop\\رابع تقنية\\مترجمات عملي\\Project Compilar\\lab5\\generated_code.exe";


                inputStreem = new AntlrInputStream(input);

                lexer = new MyGrammerLexer(inputStreem);

                lTS = new CommonTokenStream(lexer);

                parser = new MyGrammerParser(lTS);

                richTextBox3.Clear();
                richTextBox2.Clear();
                parser.RemoveErrorListeners();

                parser.AddErrorListener(new MyErrorListener(richTextBox3));

                parser.BuildParseTree = true;
                IParseTree tree = parser.program();

                if (!tree.GetText().Contains("missing"))
                {
                    MyGrammerVisitor visitor = new MyGrammerVisitor(richTextBox2);
                    visitor.Visit(tree);
                    visitor.SaveCodeToFile(cppFilePath);

                    CompileCppToExe(cppFilePath, exeFilePath);
                }
            }

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            RunCode();  
        }

        private void CompileCppToExe(string cppFilePath, string exeFilePath)
        {

            Process compileProcess = new Process();
            compileProcess.StartInfo.FileName = "g++";
            compileProcess.StartInfo.Arguments = "-o \"" + exeFilePath + "\" \"" + cppFilePath + "\"";
            compileProcess.StartInfo.RedirectStandardOutput = true;
            compileProcess.StartInfo.RedirectStandardError = true;
            compileProcess.StartInfo.UseShellExecute = false;
            compileProcess.StartInfo.CreateNoWindow = true;

            try
            {

                compileProcess.Start();
                string output = compileProcess.StandardOutput.ReadToEnd();
                string errors = compileProcess.StandardError.ReadToEnd();
                compileProcess.WaitForExit();


                if (compileProcess.ExitCode == 0)
                {
                    richTextBox2.AppendText("Compilation succeeded! Executable created: " + exeFilePath);
                    Process.Start(exeFilePath);

                }
                else
                {
                    richTextBox2.AppendText("Compilation failed:\n" + errors);
                }
            }
            catch (Exception ex)
            {
                richTextBox2.AppendText("Error while compiling:\n" + ex.Message);
            }
            finally
            {
                compileProcess.Close();
            }
        }

        string[] _LiteralNames = {
         "StartP", "EndP", "int", "if", "elseif", "else", "for","print"
        //"++", "--", "print", "=", "(", ")", "{", "+",
       // "-", "/", "*", "%", "}", ";", ",", ">", "<",
        //">=", "<=", "=="
    };
       
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void ChangeTextColor(RichTextBox richTextBox, string textToColor, Color color,int indline=0, int index = 0)
        {
            // احتفظ بالموقع الحالي للمؤشر
            int originalSelectionStart = richTextBox.SelectionStart;
            int originalSelectionLength = richTextBox.SelectionLength;

            // البحث عن النص المحدد وتلوينه
            int startIndex = 0;
            int length = richTextBox.Text.Length;
                while ((startIndex = richTextBox.Text.IndexOf(textToColor, startIndex)) != -1)
                {
                    richTextBox.Select(startIndex, textToColor.Length);
                    // تغيير اللون
                    richTextBox.SelectionColor = color;
                    startIndex = startIndex+3;
                if (startIndex > length)
                    break;
                }
          
            richTextBox.SelectionStart = originalSelectionStart;
            richTextBox.SelectionLength = originalSelectionLength;
            richTextBox.SelectionColor = richTextBox.ForeColor; // إعادة ضبط اللون إلى الافتراضي

        }

        string strRichBox = "",inputs="";
          private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((e.KeyChar == ' '  || e.KeyChar == '(') && _LiteralNames.Contains(inputs))
            {
                ChangeTextColor(richTextBox1, inputs, Color.Blue);
                inputs = "";
            }
           else if (e.KeyChar == ' ' || e.KeyChar == '(' || e.KeyChar==13)
            {
                char[] sp = new char[3];
                sp[0] = ' ';
                sp[1] = '(';
                sp[2] = '\n';
                string[] text = richTextBox1.Text.Split(sp);
                int indexline = 0, indexpos = 0, numberline, numberpos;
                string d, d2;
                for (int i = 0; i < text.Length; i++)
                {
                    if (_LiteralNames.Contains(text[i]))
                    {
                       
                            
                        ChangeTextColor(richTextBox1, text[i], Color.Blue);
                        inputs = "";
                    }
                    else
                        ChangeTextColor(richTextBox1, text[i], Color.Black);
                    indexpos += 2;
                }
                inputs += e.KeyChar;
                strRichBox = richTextBox1.Text + e.KeyChar;
                inputStreem = new AntlrInputStream(strRichBox);

                lexer = new MyGrammerLexer(inputStreem);

                lTS = new CommonTokenStream(lexer);

                parser = new MyGrammerParser(lTS);

                richTextBox3.Clear();
               
                parser.RemoveErrorListeners();

                parser.AddErrorListener(new MyErrorListener(richTextBox3));

                parser.BuildParseTree = true;
                IParseTree tree = parser.program();
            }

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                
                RichTextBox clipboardText = richTextBox1;
                clipboardText.Text = Clipboard.GetText();
            
                for (int i = 0; i < _LiteralNames.Length; i++)
                {
                    if (clipboardText.Text.Contains(_LiteralNames[i]))
                    {
                        ChangeTextColor(clipboardText, _LiteralNames[i], Color.Blue);
                    }
                }

                if (richTextBox1.Text.Length > 0)
                {
                    input = richTextBox1.Text.ToString();

                    inputStreem = new AntlrInputStream(input);

                    lexer = new MyGrammerLexer(inputStreem);

                    lTS = new CommonTokenStream(lexer);

                    parser = new MyGrammerParser(lTS);

                    richTextBox3.Clear();
                    
                    parser.RemoveErrorListeners();

                    parser.AddErrorListener(new MyErrorListener(richTextBox3));

                    parser.BuildParseTree = true;
                    IParseTree tree = parser.program();

              
                }

            }
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }


   
    public class MyErrorListener : BaseErrorListener
    {

         RichTextBox errorRichTextBox;

        public MyErrorListener(RichTextBox _texteRichTextBox)
        {
            errorRichTextBox = _texteRichTextBox;
           
        }
       
        public override void SyntaxError(TextWriter text,IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {

            errorRichTextBox.AppendText(msg + " line : " + line + " possotisn : " + charPositionInLine + " \n");

        }
    }
}


