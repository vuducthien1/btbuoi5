using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btbuoi5
{
    public partial class DINHDANG : Form
    {
        public DINHDANG()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                FontStyle currentStyle = richText.SelectionFont.Style;
                if (richText.SelectionFont.Bold)
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle & ~FontStyle.Bold);
                }
                else
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle | FontStyle.Bold);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                FontStyle currentStyle = richText.SelectionFont.Style;
                if (richText.SelectionFont.Italic)
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle & ~FontStyle.Italic);
                }
                else
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle | FontStyle.Italic);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                FontStyle currentStyle = richText.SelectionFont.Style;
                if (richText.SelectionFont.Underline)
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle & ~FontStyle.Underline);
                }
                else
                {
                    richText.SelectionFont = new Font(richText.SelectionFont, currentStyle | FontStyle.Underline);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                FontStyle currentStyle = richText.SelectionFont.Style;
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();
                richText.SelectionFont = new Font(selectedFont, richText.SelectionFont.Size, currentStyle);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                FontStyle currentStyle = richText.SelectionFont.Style;
                float selectedSize = Convert.ToSingle(toolStripComboBox2.SelectedItem);
                richText.SelectionFont = new Font(richText.SelectionFont.FontFamily, selectedSize, currentStyle);
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        
        private void mởTậpTinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richText.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void lưuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richText.Text);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }


}

