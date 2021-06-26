using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//used to compile files
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;

//used to modify files (read,write)
using System.IO;


namespace NotepadApplication
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove all text from file dialogue
            fastColoredTextBox1.Text = "";
        }

        //method to open file 
        private void OpenDlg()
        {
            //create new open file dialogue
            OpenFileDialog of = new OpenFileDialog();



            //open file dialogue files extension filter
            if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
            {
                of.Filter = "C# File|*.cs|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
            {
                of.Filter = "VB File|*.vb|Any File|*.*";
            }

            else if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
            {
                of.Filter = "PHP File|*.php|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
            {
                of.Filter = "HTML File|*.html|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
            {
                of.Filter = "JS File|*.js|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
            {
                of.Filter = "XML File|*.xml|Any File|*.*";     
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
            {
                of.Filter = "Lua File|*.lua|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.SQL)
            {
                of.Filter = "SQL File|*.sql|Any File|*.*";
            }

            else
            {
                of.Filter = "Any File|*.*";
            }



            //if after show dialogue clicked ok 
            if (of.ShowDialog() == DialogResult.OK)
            {
                //open file
                StreamReader sr = new StreamReader(of.FileName);

                //place file text to textbox
                fastColoredTextBox1.Text = sr.ReadToEnd();

                //close file
                sr.Close();

                //text of this window  = path of currently opened file
                this.Text = of.FileName;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDlg();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //save File
                StreamWriter sw = new StreamWriter(this.Text);

                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }

            catch
            {
                SaveDlg();
            }
        }

        //save file method
        private void SaveDlg()
        {
            //new save file dialogue
            SaveFileDialog of = new SaveFileDialog();


            //filter
            //open file dialogue files extension filter
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
            {
                of.Filter = "C# File|*.cs|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.VB)
            {
                of.Filter = "VB File|*.vb|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
            {
                of.Filter = "PHP File|*.php|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
            {
                of.Filter = "HTML File|*.html|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
            {
                of.Filter = "JS File|*.js|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.XML)
            {
                of.Filter = "XML File|*.xml|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Lua)
            {
                of.Filter = "Lua File|*.lua|Any File|*.*";
            }

            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.SQL)
            {
                of.Filter = "SQL File|*.sql|Any File|*.*";
            }

            else
            {
                of.Filter = "Any File|*.*";
            }



            //if after showing dialogue user clicked ok
            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(of.FileName);
                sr.Write(fastColoredTextBox1.Text);
                sr.Close();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveDlg();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close Application
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new color choosing Dialogue
            ColorDialog cd = new ColorDialog();

            //if after showing dialogue, user clicked ok 
            if(cd.ShowDialog() == DialogResult.OK)
            {
                //set background color to text box
                fastColoredTextBox1.BackColor = cd.Color;
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new color choosing Dialogue
            ColorDialog cd = new ColorDialog();

            //if after showing dialogue, user clicked ok 
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //set text color to text box
                fastColoredTextBox1.ForeColor = cd.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new font choosing Dialogue
            FontDialog cd = new FontDialog();

            //if after showing dialogue, user clicked ok 
            if (cd.ShowDialog() == DialogResult.OK)
            {
                //set font to text box
                fastColoredTextBox1.Font = cd.Font;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowGoToDialog();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void vBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void jSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void lUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
            {
                HTMLPreview h = new HTMLPreview(fastColoredTextBox1.Text);
                h.Show();
            }

            else if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Executable File|*.exe";
                string OutPath = "?.exe";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    OutPath = sf.FileName;
                }


                //compile code:
                //create c# code compiler
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();

                //create new parameters for compilation and add references(libs) to compiled app
                CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });

                //is compiled code will be executable?(.exe)
                parameters.GenerateExecutable = true;

                //output path
                parameters.OutputAssembly = OutPath;

                //code sources to compile
                string[] sources = { fastColoredTextBox1.Text };

                //results of compilation
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);

                //if has errors
                if (results.Errors.Count > 0)
                {
                    string errsText = "";
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        errsText = "(" + CompErr.ErrorNumber +
                                    ")Line " + CompErr.Line +
                                    ",Column " + CompErr.Column +
                                    ":" + CompErr.ErrorText + "" +
                                    Environment.NewLine;
                    }

                    //show error message
                    MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //run compiled app
                    System.Diagnostics.Process.Start(OutPath);
                }

            }

            else
            {
                MessageBox.Show("Cannot run this file");
            }
        }
    }
}
