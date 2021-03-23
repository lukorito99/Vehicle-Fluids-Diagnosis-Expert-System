using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VehicleFluidDiagnosis
{
    public partial class decisionwindow : Form
    {
        public decisionwindow()
        {
            InitializeComponent();
        }

        Timer decisiont1 = new Timer();//for form fade in
        Timer decisiont2 = new Timer();//for form fadeout and close AutoForm when continue button is clicked
        Timer decisiont3 = new Timer();//form fadeout and close decsionwindow form when cancel button is clicked


        Timer Bi = new Timer();

        void fadeIn(object sender, EventArgs e)
        {
            decisiont1.Interval = 4;

            if (Opacity >= 1)
            {
                decisiont1.Stop();
            }
            else
            {
                Opacity += 0.1;
            }
        }

        void fadeOut(object sender, EventArgs e)
        {
            decisiont2.Interval = 5;

            if (Opacity == 0)
            {
                decisiont2.Stop();

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(Form1))
                    {


                        f.Activate();
                        f.Close();
                    }

                }
            }

            else
            {
                Opacity -= 0.01;

            }
        }

        void decisionfadeOut(object sender, EventArgs e)
        {
            decisiont3.Interval = 5;

            if (Opacity == 0)
            {
                decisiont3.Stop();

                Close();


            }

            else
            {
                Opacity -= 0.01;

            }
        }

        void BackgroundImageChange(object sender, EventArgs e)
        {
            List<Bitmap> ImageCollection = new List<Bitmap> { };
            ImageCollection.Add(Properties.Resources.gearstick2);
            ImageCollection.Add(Properties.Resources.ignition1);
          



            var i = DateTime.Now.Second % ImageCollection.Count;

            this.BackgroundImage = ImageCollection[i];
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void continuebutton_Click(object sender, EventArgs e)
        {

            decisiont2.Tick += new EventHandler(fadeOut);
            decisiont2.Start();

        }

        private void decisionwindow_Load(object sender, EventArgs e)
        {
            Opacity = 0;



            decisiont1.Tick += new EventHandler(fadeIn);
           
            decisiont1.Start();

            Bi.Interval = 12000;//after 12000 millisecs(12 secs)
            Bi.Tick += new EventHandler(BackgroundImageChange);
            Bi.Start();

            this.BackgroundImage = Properties.Resources.ignition1;
            this.BackgroundImageLayout = ImageLayout.Stretch;
         
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            decisiont3.Tick += new EventHandler(decisionfadeOut);
            decisiont3.Start();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {
                decisiont3.Tick += new EventHandler(decisionfadeOut);
                decisiont3.Start();

                return true;
            }

            if (keyData == Keys.Enter)
            {
                decisiont2.Tick += new EventHandler(fadeOut);
                decisiont2.Start();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
