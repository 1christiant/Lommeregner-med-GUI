using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lommeregner_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        decimal Calc(string regnestykkeStr)
        {
            try
            {
                if (regnestykkeStr == "")
                {
                    MessageBox.Show("Indtast venligst et regnestykke!");
                    return 0;
                }
                //Tjek efter parenteser
                bool re = false;
                int start = 0;
                int count = 0;
                int stop = 0;
                //Find de parenteser, der passer med hinanden. Fortæl brugeren, hvis der mangler en start- eller slutparentes
                for (int i = 0; i < regnestykkeStr.Length; i++)
                {
                    char c = regnestykkeStr.ToCharArray()[i];
                    if (c == '(')
                    {
                        if (re != true)
                        {
                            re = true;
                            start = i;
                        }
                        stop++;
                    }
                    else if (c == ')')
                    {
                        stop--;
                        //Hvis stop er under 0, mangler der en startparentes
                        if (stop < 0)
                        {
                            MessageBox.Show("Der mangler en startparentes!");
                            return 0;
                        }
                    }
                    if (re)
                    {
                        count++;
                        if (stop == 0)
                            break;
                    }
                }
                if (re)
                {
                    //Hvis stop ikke er 0, mangler der en slutparentes
                    if (stop != 0)
                    {
                        MessageBox.Show("Der mangler en slutparentes!");
                        return 0;
                    }

                    //Udregn parenteser først
                    string newStr = regnestykkeStr.Substring(start + 1, count - 2);
                    decimal p = Calc(newStr);
                    regnestykkeStr = regnestykkeStr.Remove(start, count);
                    regnestykkeStr = regnestykkeStr.Insert(start, p.ToString());
                    return Calc(regnestykkeStr);
                }

                //Opdel regnestykket i tal og operators
                string[] elementer = regnestykkeStr.Split("+-*/%^qQ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                List<decimal> tal = new List<decimal>();
                for (int i = 0; i < elementer.Length; i++)
                {
                    //Konverter strings imellem operator tegn til tal
                    decimal d;
                    if (!decimal.TryParse(elementer[i], out d))
                    {
                        MessageBox.Show("Ugyldigt tal!");
                        return 0;
                    }
                    tal.Add(d);
                }

                //Find alle operators og tilføj dem til regnestykket
                List<char> operators = new List<char>();
                for (int i = 0; i < regnestykkeStr.Length; i++)
                {
                    char c = regnestykkeStr.ToCharArray()[i];
                    if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^' || c == 'q' || c == 'Q')
                    {
                        operators.Add(c);
                    }
                }

                //En liste af operators, der skal fjernes. Jeg gør det sådan her fordi den giver fejl, hvis man ændrer på listen imens man laver en foreach på den
                List<int> operatorsToBeRemoved = new List<int>();
                while (operators.Count > 0)
                {
                    bool cont = false;

                    //Her fjerner programmet operators fra regnestykket, som er blevet regnet ud
                    foreach (int i in operatorsToBeRemoved)
                    {
                        operators.RemoveAt(i);
                    }
                    operatorsToBeRemoved.Clear();

                    //x bruges til at identificere hvor i regnestykket, programmet er nået til, og hvor den skal fjerne tallene fra
                    int x = 0;
                    foreach (char c in operators)
                    {
                        //Kvadratrod
                        if (c == 'q' || c == 'Q')
                        {
                            decimal tal1 = tal[x];
                            decimal res = (decimal)Math.Sqrt((double)tal1);
                            tal.RemoveAt(x);
                            tal.Insert(x, res);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        x++;
                    }

                    //Fortsæt til næste loop, så operations kan fjernes fra regnestykket
                    if (cont)
                        continue;

                    x = 0;
                    foreach (char c in operators)
                    {
                        //Potens
                        if (c == '^')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            decimal tal3 = 1;
                            for (int i = 0; i < tal2; i++)
                            {
                                tal3 *= tal1;
                            }
                            tal.RemoveAt(x);
                            tal.RemoveAt(x);
                            tal.Insert(x, tal3);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        x++;
                    }

                    if (cont)
                        continue;

                    x = 0;
                    foreach (char c in operators)
                    {
                        //Gange
                        if (c == '*')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            decimal tal3 = tal1 * tal2;
                            tal.RemoveAt(x);
                            tal.RemoveAt(x);
                            tal.Insert(x, tal3);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        //Division
                        else if (c == '/')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            if (tal2 != 0)
                            {
                                decimal tal3 = tal1 / tal2;
                                tal.RemoveAt(x);
                                tal.RemoveAt(x);
                                tal.Insert(x, tal3);
                                operatorsToBeRemoved.Add(x);
                                cont = true;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Kan ikke dividere med 0!");
                                return 0;
                            }
                        }
                        //Modulus
                        else if (c == '%')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            decimal tal3 = tal1 % tal2;
                            tal.RemoveAt(x);
                            tal.RemoveAt(x);
                            tal.Insert(x, tal3);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        x++;
                    }

                    if (cont)
                        continue;

                    x = 0;
                    foreach (char c in operators)
                    {
                        //Plus
                        if (c == '+')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            decimal tal3 = tal1 + tal2;
                            tal.RemoveAt(x);
                            tal.RemoveAt(x);
                            tal.Insert(x, tal3);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        //Minus
                        else if (c == '-')
                        {
                            decimal tal1 = tal[x];
                            decimal tal2 = tal[x + 1];
                            decimal tal3 = tal1 - tal2;
                            tal.RemoveAt(x);
                            tal.RemoveAt(x);
                            tal.Insert(x, tal3);
                            operatorsToBeRemoved.Add(x);
                            cont = true;
                            break;
                        }
                        x++;
                    }
                    if (cont)
                        continue;
                }
                return tal[0];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Der skete en fejl ved udregning af regnestykket:\n" + ex.Message);
                return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Udskriv resultatet af regnestykket
            cResult.Text = Calc(cRegnestykke.Text).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Sørg for at brugeren ikke kan resize vinduet, og sørg for at brugerens cursor er i feltet, hvor regnestykket skal skrives
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.ActiveControl = cRegnestykke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Tilføj reference til Microsoft.VisualBasic under References i solution explorer, før InputBox kan bruges
            decimal r;
            if (!decimal.TryParse(Microsoft.VisualBasic.Interaction.InputBox("Radius:", "Areal af cirkel"), out r))
            {
                MessageBox.Show("Ugyldigt tal!");
                return;
            }

            //Areal af en cirkel: A = PI * r^2
            decimal A = (decimal)Math.PI * Calc(r + "^2");
            MessageBox.Show("Arealet er " + A);
        }

        private void cRegnestykke_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cResult.Text = Calc(cRegnestykke.Text).ToString();
                //Gør så der ikke kommer en irriterende lyd, når brugeren trykker Enter
                e.SuppressKeyPress = true;
            }
        }
    }
}