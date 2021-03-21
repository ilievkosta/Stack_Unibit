using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Stack_Unibit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string selectedItem = listBox1.Items[listBox1.SelectedIndex].ToString();
            switch (selectedItem)
            {
                case "()":


                    if (FirstBrackets(richTextBoxEx.Text))
                    {
                        textBoxAnswer.Text = "Израза е верен";
                    }
                    else
                    {
                        textBoxAnswer.Text = "Израза е грешен";
                    }
                    break;

                case "{}":


                    if (SecondBrackets(richTextBoxEx.Text))
                    {
                        textBoxAnswer.Text = "Израза е верен";
                    }
                    else
                    {
                        textBoxAnswer.Text = "Израза е грешен";
                    }
                    break;

                case "(),{}":


                    if (FirstBrackets(richTextBoxEx.Text) & SecondBrackets(richTextBoxEx.Text))
                    {
                        textBoxAnswer.Text = "Израза е верен";
                    }
                    else
                    {
                        textBoxAnswer.Text = "Израза е грешен";
                    }
                    break;
            }
        }

        private Boolean FirstBrackets(string expr)
        {

            string expression = expr;


            Stack<int> stack = new Stack<int>();

            bool correctBrackets = true;



            for (int index = 0; index < expression.Length; index++)

            {

                char ch = expression[index];

                if (ch == '(')

                {

                    stack.Push(index);

                }

                else if (ch == ')')

                {

                    if (stack.Count == 0)

                    {

                        correctBrackets = false;

                        break;

                    }

                    stack.Pop();

                }

            }

            if (stack.Count != 0)

            {

                correctBrackets = false;

            }
            if (correctBrackets)
            {
                return true;
            }

            return false;
        }


        private Boolean SecondBrackets(string expr)
        {

            string expression = expr;


            Stack<int> stack = new Stack<int>();

            bool correctBrackets = true;



            for (int index = 0; index < expression.Length; index++)

            {

                char ch = expression[index];

                if (ch == '{')

                {

                    stack.Push(index);

                }

                else if (ch == '}')

                {

                    if (stack.Count == 0)

                    {

                        correctBrackets = false;

                        break;

                    }

                    stack.Pop();

                }

            }

            if (stack.Count != 0)

            {

                correctBrackets = false;

            }
            if (correctBrackets)
            {
                return true;
            }

            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Помощ при използване на програмата";
            popup.ContentText = "Моля въведете израза и след това изберете" +
                "за кой тип скоби искате да проверите" +
                " Избор едно - (),Избор две - {}, Избор три -" +
                " и за двата вида скоби едновременно." +
                " Натиснете бутона Провери";
            popup.Popup();
        }

        private void btnExample_Click(object sender, EventArgs e)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = "Примерен израз";
            popup.ContentText = "{((4+5)+(7*4))/(2+3)}";
            popup.Popup();
        }
    }
}
