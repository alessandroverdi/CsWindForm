using System.Windows.Forms;
using System.Drawing;

namespace Torri_Hanoi
{
    
        public class cerchio
        {
            public PictureBox Immagine;
            public int dimx;
            public int posx, posy;


            public cerchio(Form a, Size dimensione, Point pos)
            {

                Immagine = new PictureBox();
                Immagine.Size = dimensione;
                Immagine.Location = pos;
                Immagine.ImageLocation = "cerchio.png"; //texture cerchio
                Immagine.SizeMode = PictureBoxSizeMode.StretchImage;
                a.Controls.Add(Immagine);


            }

         



        }
    
}
