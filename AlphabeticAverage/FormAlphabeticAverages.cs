using System;
using System.IO;
using System.Windows.Forms;

namespace AlphabeticAverage
{
    public partial class FormAlphabeticAverages : Form
    {
        public FormAlphabeticAverages()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\alpha.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    TxtResult.Text += CalculateAlphabeticAverage(line) + Environment.NewLine;
                }
            }
        }

        private string CalculateAlphabeticAverage(string word)
        {
            string result = "";
            string alphabet = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string letter;
            int letterValue;
            int totalLetterValue = 0;
            double average;

            for (int i = 0; i < word.Length; i++)
            {
                letter = word.Substring(i, 1);
                letterValue = alphabet.IndexOf(letter);
                totalLetterValue += letterValue;
            }

            average = (double)totalLetterValue / word.Length;

            if (average % 1 == 0)
            {
                average = Math.Ceiling(average);
            }
            else if (average % 1 >= 0.5)
            {
                average = Math.Ceiling(average);
            }
            else if (average % 1 < 0.5)
            {
                average = Math.Floor(average);
            }

            result = alphabet.Substring(Convert.ToInt32(average), 1);

            return result;
        }
    }
}
