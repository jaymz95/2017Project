using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Microsoft.VisualBasic;

// j,/using System.Windows.Forms.dll;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    //user input
    class Scanner : System.IO.StringReader
    {
        string currentWord;

        public Scanner(string source) : base(source)
        {
            readNextWord();
        }

        private void readNextWord()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            char nextChar;
            int next;
            do
            {
                next = this.Read();
                if (next < 0)
                    break;
                nextChar = (char)next;
                if (char.IsWhiteSpace(nextChar))
                    break;
                sb.Append(nextChar);
            } while (true);
            while ((this.Peek() >= 0) && (char.IsWhiteSpace((char)this.Peek())))
                this.Read();
            if (sb.Length > 0)
                currentWord = sb.ToString();
            else
                currentWord = null;
        }

        public bool hasNextInt()
        {
            if (currentWord == null)
                return false;
            int dummy;
            return int.TryParse(currentWord, out dummy);
        }

        public int nextInt()
        {
            try
            {
                return int.Parse(currentWord);
            }
            finally
            {
                readNextWord();
            }
        }

        public bool hasNextDouble()
        {
            if (currentWord == null)
                return false;
            double dummy;
            return double.TryParse(currentWord, out dummy);
        }

        public double nextDouble()
        {
            try
            {
                return double.Parse(currentWord);
            }
            finally
            {
                readNextWord();
            }
        }

        public bool hasNext()
        {
            return currentWord != null;
        }
    }
//user input

    public sealed partial class MainPage : Page
    {
        private int _Rows;

        public MainPage()
        {
            this.InitializeComponent();
        }
        

        public void Nnn()
        {
           // string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt", "Title", "Default", -1, -1);

            String message, title, defaultValue;
            String myValue;

            message = "Enter a value between 1 and 3";

            title = "InputBox Demo";
            defaultValue = "1";

            //myValue = Microsoft.VisualBasic.Interaction.InputBox(message, title, defaultValue);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //the sender parameter hols the radio btton object theat got checked
            //need to cast it to 
            RadioButton current = (RadioButton)sender;
            //find which number from the content
            _Rows = Convert.ToInt32(current.Tag);
            Nnn();
            //setupThePieces();
            //#endregion
        }
    }
}
