using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Torri_Hanoi
{
    class palo
    {
        public int top; //n cerchi presenti
        static int t; // tempo di gioco
        public cerchio[] a; //vettore di cerchi
        public PictureBox Immagine;
        static string nick; //nome player 
        List<string> ror= new List<string>();
        
        
        



        public palo(int n,int top,Form campo,int numPalo) //costruttore
        {
            ror.Add("lol");

            string st;

 

            Immagine = new PictureBox();
            Immagine.Size = new Size(campo.ClientSize.Width / ( 4 * n) , campo.ClientSize.Height - campo.ClientSize.Height / 6);
            Immagine.Location = new Point( ( (campo.ClientSize.Width / 3) * numPalo) + (campo.ClientSize.Width / 6) - (Immagine.Size.Width / 2), campo.ClientSize.Height - Immagine.Size.Height); ;
            Immagine.ImageLocation = "piolo.png";
            Immagine.SizeMode = PictureBoxSizeMode.StretchImage;
            campo.Controls.Add(Immagine);
            
            a = new cerchio[n];
            for (int i = 0; i < n; i++)
            {
                if (top > i) //inizializzo n cerchi
                {
                    a[i] = new cerchio(campo, new Size(((campo.ClientSize.Width / 3) / n) * (n - i), (campo.ClientSize.Height / 20)), new Point((Immagine.Location.X + Immagine.Width / 2) - (((campo.ClientSize.Width / 3) / n) * (n - i) / 2), campo.ClientSize.Height - (campo.ClientSize.Height / 20) * i - (campo.ClientSize.Height / 20)));
                }
                else
                {
                    //a[i] = new cerchio(campo, new Size(0, 0), new Point(0, 0));
                }
            }
            Immagine.SendToBack();
            this.top = top;
            
        }

        ~palo() //distruttore
        {
            
        }

        public void set_nickname(string nm)
        {
            nick = nm;
        }

        public void set_tempo(int temp)
        {
            t = temp;
        }

        public void sposta_cerchio(palo Destinazione, ref int mosse, int n, Form campo, Form menu)
        {
            if (top > 0) //ci sono cerchi
            {

                a[top - 1].Immagine.ImageLocation = "cerchio.png"; //texture selezionato --> rosso

                if (Destinazione.top == 0 || Destinazione.a[Destinazione.top - 1].Immagine.Size.Width > a[top - 1].Immagine.Size.Width)
                {

                    a[top - 1].Immagine.Location = new Point((Destinazione.Immagine.Location.X + Destinazione.Immagine.Width / 2) - (a[top - 1].Immagine.Width / 2), campo.ClientSize.Height - (campo.ClientSize.Height / 20) * Destinazione.top - (campo.ClientSize.Height / 20));

                    Destinazione.a[Destinazione.top] = a[top - 1];
                    top--;
                    Destinazione.top++;
                    mosse++;
                    if (Destinazione.Immagine.Location.X > campo.ClientSize.Width / 3) //non sono sul palo 1
                    {
                        if (Destinazione.controllo_vittoria(n)) //vinto
                        {
                            stampa_vittoria(mosse, n);
                            campo.Hide(); //nascondo campo gioco
                            menu.Show(); //mostro menu
                        }
                    }
                }
            }
        }

        private void stampa_vittoria(int mosse, int n)
        {
            float score;
            float min_mosse = (int)Math.Pow(2, n) - 1;
            if (t != 0)
            {
                score = (((min_mosse / t) + (min_mosse / mosse)) * 100) - 100;
            }

            else //usato aiuto
            {
                score = 0;
            }

            scrivisufile(nick, score); //file html scoreboard
            DialogResult mex = MessageBox.Show("Complimmenti hai vinto in " + mosse + " mosse su " + min_mosse + " ! Score: " + (int)score+ " salvato, Giocare di nuovo?", "VITTORIAAA!", MessageBoxButtons.YesNo);
            if (mex == DialogResult.No)
            {
                mex = MessageBox.Show("Sicuro di uscire da questo fantastico gioco, sviluppato con tanto amore?", "CONFERMA SCELTA", MessageBoxButtons.OKCancel);
                if (mex == DialogResult.OK)
                {
                    Application.Exit();

                }

            }
        }
        private bool controllo_vittoria(int n)
        {
            bool controllo_vittoria = false;
            for (int i = 0; i < n - 1; i++) //scorro pila
            {
                if (top == n) { //se ho n dischi sul palo

                    if (a[i].Immagine.Size.Width > a[i + 1].Immagine.Size.Width && a[i + 1] != null)
                    {
                        controllo_vittoria = true;
                    }
                    else
                    {
                        controllo_vittoria = false;
                    }
                }
            }
            return controllo_vittoria;
        }

        public int towerOfHanoi(int p, palo da, palo fino, palo ausilio,ref int mosse, Form a, Form b , int n) //algoritmo ricorsivo
        {
            t = 0; //annulla score
            if (p == 1)
            {
                
                da.sposta_cerchio(fino, ref mosse, n, a, b);

                
                System.Threading.Thread.Sleep(1000);
                a.Refresh();

                return 1;
            }
            else
            {
                
                towerOfHanoi(p - 1, da, ausilio, fino, ref mosse, a, b, n);
                da.sposta_cerchio(fino, ref mosse, n, a, b);
                System.Threading.Thread.Sleep(1000);
                a.Refresh();
                towerOfHanoi(p - 1, ausilio, fino, da, ref mosse, a, b ,n);
                return 1;
            }
          }

        private void scrivisufile(string nome, float score) //file scoreboard
        {
           

            if (!File.Exists("score.html")) //se non esiste, creo
            {
                    //intestazione pagina html da file
                    File.Copy("intestazione.txt", "score.html");
                
            }
            
            
            using (StreamWriter sw = File.AppendText("score.html")) //aggiungo in coda
            {
                    //nuova riga
                    sw.WriteLine("<tr>");
                    sw.WriteLine("<td> {0} </td>", (int)score);
                    sw.WriteLine("<td> {0} </td>", nome);
                    sw.WriteLine("<td> {0} {1} {2} </td>", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year); //data sistema
                    sw.WriteLine("</tr>");
            }
            
        }
    }
}
