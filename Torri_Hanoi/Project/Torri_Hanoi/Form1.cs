using System;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Wave;



namespace Torri_Hanoi
{
    public partial class Form1 : Form
    {
       //pacchetto Naudio per musica
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        bool inizio = false; //partita non iniziata
        bool mc = false; //musica off
        int n, larg = 600, alt = 600, mosse; // numero pali, larg/alt def 600
        int m = 0, s = 0, stot; //minuti e secondi per il timer di gioco e seconditotali

        palo p1, p2, p3,src ,dst; 
        Form form2 = new Form(); //form di gioco
        Button Aiuto = new Button(); //help
        TextBox mossanumero = new TextBox(); //conta mosse
        Label t = new Label(); //tempo passato
        Label nom = new Label(); //nick per score
        Timer tempo = new Timer(); 
        TextBox nickname = new TextBox(); //inserisci nome
        CheckBox musica = new CheckBox(); //attiva musica
        




        public Form1() //form menu
        {
            
            
            Text = "MENU DI GIOCO";
            n = 3;
            stot = 0;

            InitializeComponent();
            set_bt_inizio();
            get_dischi();
            set_bt_info_menu();
            get_dim_gioco();
            set_nick();

        }

    

        

        private void Inizio_Click(object sender, EventArgs e) //inizia il gioco
        {
            if (nickname.Text != "") //nome valido
            {
                inizio = true; //partita iniziata
                
                Hide(); //nascondi menu

               
                //campo gioco
                set_form_gioco();

                //costruttore
                p1 = new palo(n, n, form2, 0);
                p2 = new palo(n, 0, form2, 1);
                p3 = new palo(n, 0, form2, 2);

                set_tempo();
                set_conta_tempo();
                set_conta_mosse();
                set_bt_musica();
                set_bt_aiuto();

                

                //nome player
                string nm = nickname.Text;
                p1.set_nickname(nm);

                //aggiungo evento click su ogni palo
                p1.Immagine.MouseClick += p1_Click;
                p2.Immagine.MouseClick += p2_Click;
                p3.Immagine.MouseClick += p3_Click;
            }
            else
            {
                MessageBox.Show("Inserire un nome valido!", "ATTENZIONE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Musica_Click(object sender, MouseEventArgs e) //switch musica
        {
            mc = !mc;

            if (mc)
            {
                avvio_musica(sender, e);
            }
            else
            {
                StoppedEventArgs s = new StoppedEventArgs();
                stop_musica(sender ,  s);
            }
        }

        private void avvio_musica(object sender, EventArgs args) //attiva musica
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += stop_musica;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader("Hanoi.mp3");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void stop_musica(object sender, StoppedEventArgs args) //disattiva
        {
            outputDevice?.Stop();
            outputDevice = null;
            audioFile = null;
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            s++; //incremento secondi

            if (s >= 60) //cambio minuto
            {
                m++;
                s = 0;
            }

            //per visualizzare: 02:01 e non 2:1

            string time = "";

            if(m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }

            t.Text = time;  //testo del conta tempo

            stot = s + (m * 60); //aggiorno tempo totale passato

        }

        private void Scoreboard_Click(object sender, EventArgs e) //pagina html con gli score ordinati
        {
            System.Diagnostics.Process.Start("score.html");
        }

        private void Storia_Click(object sender, EventArgs e) //storia gioco
        {
            MessageBox.Show("La Torre di Hanoi(anche conosciuta come Torre di Lucas dal nome del suo inventore) è un rompicapo matematico composto da tre paletti e un certo numero di dischi di grandezza decrescente, che possono essere infilati in uno qualsiasi dei paletti.", "Storia del Gioco", MessageBoxButtons.OK);
        }

        private void Istruzioni_Click(object sender, EventArgs e) //come giocare
        {
            MessageBox.Show("Ciao, per giocare seleziona il numero di dischi e poi clicca su inizio. Utilizza quindi il mouse, cliccando sopra / su un palo per selezionare un disco da muovere (cambia colore se selezionato) e clicca ancora sopra il palo di destinazione per spostarlo. Buona fortuna......sviluppato da A.Verdi!", "Come si gioca?");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //dischi
        {
            n = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e) //altezza
        {
            alt = (int)numericUpDown2.Value;

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e) //larghezza
        {
            larg = (int)numericUpDown3.Value;
        }

        private void Aiuto_Click(object sender, EventArgs e) //vincita automatica
        {
            p1.towerOfHanoi(n, p1, p3, p2,ref mosse, form2, this ,n);
        }

        

        private void Form1_MouseUp(object sender, MouseEventArgs e) //rileva posizione mouse sopra palo
        {
            if (inizio) //partita attiva
            {
                //capire se click sopra p1 o p2 o p3

                if (e.X > p1.Immagine.Location.X && e.X < p1.Immagine.Location.X + p1.Immagine.Size.Width && (p1.top != 0 || src != null) )
                {
                    if (src == null) { src = p1; p1.a[p1.top - 1].Immagine.ImageLocation = "selezionato.png"; } //set immagine rossa

                    else dst = p1;
                }
                else
                {
                    if (e.X > p2.Immagine.Location.X && e.X < p2.Immagine.Location.X + p2.Immagine.Size.Width && (p2.top != 0 || src != null))
                    {
                        if (src == null) { src = p2; p2.a[p2.top - 1].Immagine.ImageLocation = "selezionato.png"; }
                        else dst = p2;
                    }
                    else
                    {
                        if (e.X > p3.Immagine.Location.X && e.X < p3.Immagine.Location.X + p3.Immagine.Size.Width && (p3.top != 0 || src != null))
                        {
                            if (src == null) { src = p3; p3.a[p3.top - 1].Immagine.ImageLocation = "selezionato.png"; }
                            else dst = p3;
                        }
                    }
                }
                check_scambio();
            }

        }

        private void p1_Click(object sender, MouseEventArgs e) //click palo 1
        {
            if ((p1.top != 0 || src != null))
            {
                if (src == null)
                {
                    src = p1;
                    p1.a[p1.top - 1].Immagine.ImageLocation = "selezionato.png";
                }

                else
                {
                    dst = p1;
                }
            }

            check_scambio();
        }

        private void p2_Click(object sender, MouseEventArgs e) //click palo 2
        {

            if ((p2.top != 0 || src != null))
            {
                if (src == null)
                {
                    src = p2;
                    p2.a[p2.top - 1].Immagine.ImageLocation = "selezionato.png";
                }

                else
                {
                    dst = p2;
                }
            }

            check_scambio();
        }

        private void p3_Click(object sender, MouseEventArgs e) //click palo 3
        {

            if ((p3.top != 0 || src != null))
            {
                if (src == null)
                {
                    src = p3;
                    p3.a[p3.top - 1].Immagine.ImageLocation = "selezionato.png";
                }

                else
                {
                    dst = p3;
                }
            }

            check_scambio();
        }

        private void check_scambio()
        {

            if (src != null && dst != null)
            {
                dst.set_tempo(stot);
                src.sposta_cerchio(dst, ref mosse, n, form2, this);
                mossanumero.Text = mosse.ToString();

                if (mosse == 1)
                {
                    Aiuto.Hide();
                }


                src = null;
                dst = null;


            }


        }

        private void set_form_gioco()
        {

            form2 = new Form();
            form2.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form2.Size = new Size(larg, alt);
            form2.Text = "GIOCHIAMO!";
            form2.Location = this.Location;
            Image myimage = new Bitmap("gioco.png");
            form2.BackgroundImage = myimage;
            form2.MouseClick += Form1_MouseUp;
            form2.Show();


        }


        private void set_conta_tempo()
        {

            t.Text = "00:00";
            t.Size = new Size(larg / 20, alt / 25);
            t.Location = new Point(0, 0);
            t.AutoSize = true;
            form2.Controls.Add(t);

        }

        private void set_conta_mosse()
        {
            mossanumero.AutoSize = true;
            mossanumero.Text =  mosse.ToString();
            mossanumero.Size = new Size(larg / 20, alt / 25);
            mossanumero.Location = new Point(t.Location.X, t.Height + t.Location.Y + 1);
            form2.Controls.Add(mossanumero);
            mosse = 0;


        }

        private void set_tempo()
        {
            tempo.Interval = 1000;

            if (!tempo.Enabled) //evita i multipli tick nelle nuove form generate ogni volta
            {
                tempo.Tick += tempo_Tick;
            }
            tempo.Start();

            //azzeramento tempo ogni partita
            m = 0;
            s = 0;

        }

        private void set_bt_musica()
        {

            musica.Text = "Music";
            musica.Size = mossanumero.Size;
            musica.Location = new Point(t.Location.X, mossanumero.Location.Y + mossanumero.Height + 1);
            musica.MouseClick += Musica_Click;
            musica.AutoSize = true;
            form2.Controls.Add(musica);


        }


        private void set_bt_inizio()
        {
            Inizio.Location = new Point((ClientSize.Width - Inizio.Width) / 4, Size.Height / 3);
            Inizio.Size = new Size(ClientSize.Width / 10, ClientSize.Height / 20);
        }

        private void get_dischi()
        {
            //in
            numericUpDown1.Location = new Point(Inizio.Location.X, Inizio.Location.Y + Inizio.Height + 5);
            numericUpDown1.Size = new Size(Inizio.Width, Inizio.Height);
            //out
            label1.Location = new Point(numericUpDown1.Width + numericUpDown1.Location.X + 1, numericUpDown1.Location.Y);
            label1.Text = "Dischi";


        }

        private void set_bt_info_menu()
        {

            Istruzioni.Size = new Size(Inizio.Width, Inizio.Height);
            Istruzioni.Location = new Point((ClientSize.Width / 6) - (Istruzioni.Width / 2), ClientSize.Height - Size.Height / 6);

            Storia.Location = new Point(((ClientSize.Width / 6) * 5) - (Storia.Width / 2), Istruzioni.Location.Y);
            Storia.Size = new Size(Inizio.Width, Inizio.Height);

            Scoreboard.Size = Storia.Size;
            Scoreboard.Location = new Point(ClientSize.Width / 2 - Scoreboard.Width / 2, Storia.Location.Y);



        }

        private void set_nick()
        {

            nickname.Location = new Point((Inizio.Location.X + Inizio.Width / 2) - nickname.Width / 2, Inizio.Location.Y - nickname.Height - 5);
            nickname.Text = "";
            Controls.Add(nickname);

            nom.Text = "Nome:";
            nom.Size = label1.Size;
            nom.Location = new Point(nickname.Location.X - nom.Width - 5, nickname.Location.Y);
            Controls.Add(nom);


        }

        private void get_dim_gioco()
        {
            //altezza
            numericUpDown3.Location = new Point(Inizio.Location.X, numericUpDown1.Height + numericUpDown1.Location.Y + 5);
            numericUpDown3.Size = new Size(Inizio.Width, Inizio.Height);
            label2.Location = new Point(numericUpDown3.Width + numericUpDown3.Location.X + 1, numericUpDown3.Location.Y);

            //larghezza
            numericUpDown2.Location = new Point(Inizio.Location.X, numericUpDown3.Height + numericUpDown3.Location.Y + 5);
            numericUpDown2.Size = new Size(Inizio.Width, Inizio.Height);
            label3.Location = new Point(numericUpDown2.Width + numericUpDown2.Location.X + 1, numericUpDown2.Location.Y);

        }

        private void set_bt_aiuto()
        {

            Aiuto.Text = "Aiuto";
            Aiuto.Click += Aiuto_Click;
            Aiuto.Size = mossanumero.Size;
            Aiuto.Location = new Point(t.Location.X, musica.Height + musica.Location.Y + 1);
            Aiuto.AutoSize = true;
            form2.Controls.Add(Aiuto);


        }










    }
}
