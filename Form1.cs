using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VehicleFluidDiagnosis
{
    public partial class Form1 : Form
    {
        private CLIPSNET.Environment melo = new CLIPSNET.Environment();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(

           int nLeftRect, //x-coordinate of upper left conner
           int nTopRect,//y-coordinate of upper left conner
           int nRightRect, //x-coordinate of lower right conner
           int nBottomRect,//y-coordinate of lower right conner
           int nWidthEllipse,//width of ellipse
           int nHeightEllipse//height of ellipse




      );

        public Form1()
        {
            InitializeComponent();
            oilsappcomboBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, oilsappcomboBox1.Width, oilsappcomboBox1.Height, 30, 30));

            othercombo.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, othercombo.Width, othercombo.Height, 30, 30));
            fluidssmellcomboBox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, fluidssmellcomboBox.Width, fluidssmellcomboBox.Height, 30, 30));



            fuelsappcomboBox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, fuelsappcomboBox.Width, fuelsappcomboBox.Height, 30, 30));
            fuelssmellcomboBox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, fuelssmellcomboBox.Width, fuelssmellcomboBox.Height, 30, 30));
            touchcomboBox.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, touchcomboBox.Width, touchcomboBox.Height, 30, 30));

        }
        SoundPlayer player = new SoundPlayer(Properties.Resources.Violet__Evergarden_A_Place_to_Call_Home);
        SoundPlayer player1 = new SoundPlayer(Properties.Resources.Violet_Evergarden_Always_Watching_Over_You);
        bool Check = true;
        Timer vf = new Timer();
       
        Timer Bi = new Timer();
        Timer V = new Timer();

        void fadeIn(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                vf.Stop();
            }

            else
            {
                Opacity += 0.01;
            }
        }

       

        void BackgroundImageChange(object sender, EventArgs e)
        {
            List<Bitmap> ImageCollection = new List<Bitmap> { };
            ImageCollection.Add(Properties.Resources.FluidType);
            ImageCollection.Add(Properties.Resources.Coolant);
            ImageCollection.Add(Properties.Resources.Transmission_Fluid);
            ImageCollection.Add(Properties.Resources.CarFluids);
            ImageCollection.Add(Properties.Resources.VehicleFluid);



            var i = DateTime.Now.Second % ImageCollection.Count;
            
            this.BackgroundImage = ImageCollection[i];
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }

        void ChangeAudio(object sender, EventArgs e)
        {

            if (!Check)
            {
                player.Stop();
                player1.PlayLooping();
                Check = true;
            }

            else
            {
                player1.Stop();
                player.PlayLooping();
                Check = false;
            }

        }

        private void PopulateComboBox()
        {
            foreach (var f in Controls)
            {
                if (f == oilsappcomboBox1)
                {

                    List<string> Oilsappearanceslots = new List<string> { " ", "tan", "light-brown", "dark-brown", "thick-like-honey", "blackened-by-deposits" };
                    oilsappcomboBox1.DataSource = Oilsappearanceslots;
                }

                if (f == othercombo)
                {
                    List<string> Fluid_appearance = new List<string> { "  ", "light-amber", "clear", "red", "bright-color", "oily", "neon-yellow", "green", "amber", "blue" };
                    othercombo.DataSource = Fluid_appearance;
                }

                if (f == fluidssmellcomboBox)
                {
                    List<string> Fluid_smell = new List<string> { " ", "cleanser-odour", "sweet-smell", "no-smell", "sweet-like", "burnt-smell", "fishlike", "baby-oil", "relatively-odorless" };
                    fluidssmellcomboBox.DataSource = Fluid_smell;
                }

                if (f == fuelsappcomboBox)
                {
                    List<string> fuels = new List<string> { " ", "amber", "clear", "brownish-red", "yellow-tint", "brown-with-green-tint", "yellowish-green" };
                    fuelsappcomboBox.DataSource = fuels;
                }



                if (f == fuelssmellcomboBox)
                {
                    List<string> fsmell = new List<string> { " ", "burnt-popcorn", "cooking-oil", "strong-odour", "strong-lingering-odour" };
                    fuelssmellcomboBox.DataSource = fsmell;
                }

                if (f == touchcomboBox)
                {

                    List<string> touchslots = new List<string> { " ", "slippery", "cold", "oily-feel", "waxy" };
                    touchcomboBox.DataSource = touchslots;
                }

                if (f == othercombo)
                {
                    List<string> Fluidslots = new List<string> { " ", "light-amber", "clear", "red", "bright-color", "oily", "transparent", "blue", "neon-yellow", "green" };
                    othercombo.DataSource = Fluidslots;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            date.Text = DateTime.Now.ToLongDateString();

            Opacity = 0;
            vf.Interval = 5;
            vf.Tick += new EventHandler(fadeIn);
            vf.Start();

            Bi.Interval = 12000;//after 12000 millisecs(12 secs)
            Bi.Tick += new EventHandler(BackgroundImageChange);
            Bi.Start();

            player.PlayLooping();
            Check = false;
            V.Interval = 135000;//after 135 secs
            V.Tick += new EventHandler(ChangeAudio);
            V.Start();

            PopulateComboBox();
            this.BackgroundImage = Properties.Resources.VehicleFluid;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            cf.AttachRouter(melo, 10);
            melo.LoadFromResource("VehicleFluidDiagnosis", "VehicleFluidDiagnosis.Auto.clp");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Escape)
            {

                foreach (Form f in Application.OpenForms)
                {
                    if (f.GetType() == typeof(decisionwindow))
                    {
                        f.Activate();




                    }
                }



                decisionwindow d = new decisionwindow();
                d.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, d.Width, d.Height, 40, 40));
                d.Show();
                return true;

               
            }


            if (keyData == Keys.Enter)
            {


                carfluidreset.Enabled = true;
                view2.Enabled = false;

                cf.Clear();
                melo.Run();


                if (cf.TextLength != 0)
                {
                    vehiclefluidsrichTextBox.Font = new System.Drawing.Font("Segoe UI", 18.00F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    vehiclefluidsrichTextBox.Text = cf.Text;


                }

                else
                {
                    PopulateComboBox();
                    vehiclefluidsrichTextBox.Font = new System.Drawing.Font("SimSun", 22.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    var x = "You have NOT selected any symptoms or Symptoms chosen do not describe vehicle fluids,vehicle oils or vehicle fuels." + "If selection has been done;Please seek the services of a professional for further diagnosis.";



                    vehiclefluidsrichTextBox.Text = x;

                }

                melo.Eval("(reset)");





                return true;
            }






            return base.ProcessCmdKey(ref msg, keyData);







        }

        private void oilsappcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oilsappcomboBox1.Enabled = false;

            fluidssmellcomboBox.Enabled = false;
            othercombo.Enabled = false;
            fuelsappcomboBox.Enabled = false;
            fuelssmellcomboBox.Enabled = false;
            touchcomboBox.Enabled = false;


            if (oilsappcomboBox1.SelectedItem.ToString() != " ")
            {
                string q = "(Oils (appearance " + oilsappcomboBox1.SelectedItem.ToString() + "))";
                melo.AssertString(q);
            }
        }

        private void othercombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            othercombo.Enabled = false;
            fuelsappcomboBox.Enabled = false;
            fuelssmellcomboBox.Enabled = false;
            touchcomboBox.Enabled = false;
            oilsappcomboBox1.Enabled = false;

            string z;

            if (othercombo.SelectedValue.ToString() != " ")
            {

                if (othercombo.SelectedValue.ToString() == "light-amber" || othercombo.SelectedValue.ToString() == "clear")
                {
                    z = "(Fluids (appearance " + othercombo.SelectedValue.ToString() + "))";
                    melo.AssertString(z);
                }


                if (othercombo.SelectedValue.ToString() == "red" || othercombo.SelectedValue.ToString() == "bright-color" || othercombo.SelectedValue.ToString() == "oily" || othercombo.SelectedValue.ToString() == "transparent")

                {
                    z = "(TransmissionFluids (appearance " + othercombo.SelectedValue.ToString() + "))";
                    melo.AssertString(z);
                }


                if (othercombo.SelectedValue.ToString()
                 == "green" || othercombo.SelectedValue.ToString()
                 == "neon-yellow")
                {
                    z = "(Coolants (appearance " + othercombo.SelectedValue.ToString()
                        + "))";
                    melo.AssertString(z);
                }

                if (othercombo.SelectedValue.ToString()
                   == "clear")
                {
                    z = "(Water (appearance " + othercombo.SelectedValue.ToString()
                        + "))";
                    melo.AssertString(z);
                }
                if (othercombo.SelectedValue.ToString()
                   == "blue")
                {
                    z = "(Washer (appearance " + othercombo.SelectedValue.ToString()
                        + "))";
                    melo.AssertString(z);
                }


            }
        }

        private void fluidssmellcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fluidssmellcomboBox.Enabled = false;
            fuelsappcomboBox.Enabled = false;
            fuelssmellcomboBox.Enabled = false;
            touchcomboBox.Enabled = false;
            oilsappcomboBox1.Enabled = false;

            if (fluidssmellcomboBox.SelectedValue.ToString() != " ")
            {
                string w;

                if (fluidssmellcomboBox.SelectedValue.ToString()
                    == "fishlike" || fluidssmellcomboBox.SelectedValue.ToString()
                    == "baby-oil")
                {
                    w = "(Fluids (smell " + fluidssmellcomboBox.SelectedValue.ToString() + "))";
                    melo.AssertString(w);
                }

                if (fluidssmellcomboBox.SelectedValue.ToString()
                   == "burnt-smell" || fluidssmellcomboBox.SelectedValue.ToString() == "relatively-odorless")
                {
                    w = "(TransmissionFluids (smell " + fluidssmellcomboBox.SelectedValue.ToString() + "))";
                    melo.AssertString(w);
                }

                if (fluidssmellcomboBox.SelectedValue.ToString()
                    == "sweet-like")
                {
                    w = "(Coolants (smell " + fluidssmellcomboBox.SelectedValue.ToString() + "))";
                    melo.AssertString(w);
                }

                if (fluidssmellcomboBox.SelectedValue.ToString() == "no-smell")
                {
                    w = "(Water (smell " + fluidssmellcomboBox.SelectedValue.ToString() + "))";
                    melo.AssertString(w);
                }



                if (fluidssmellcomboBox.SelectedValue.ToString() == "cleanser-odour" || fluidssmellcomboBox.SelectedValue.ToString() == "sweet-smell")
                {
                    w = "(Washer (smell " + fluidssmellcomboBox.SelectedValue.ToString() + "))";
                    melo.AssertString(w);
                }



            }
        }

        private void fuelsappcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fuelsappcomboBox.Enabled = false;

            oilsappcomboBox1.Enabled = false;

            fluidssmellcomboBox.Enabled = false;
            othercombo.Enabled = false;

            if (fuelsappcomboBox.SelectedValue.ToString() != " ")
            {
                string q;

                q = "(Fuels(appearance " + fuelsappcomboBox.SelectedValue.ToString()
                    + "))";
                melo.AssertString(q);


            }
        }

        private void fuelssmellcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fuelssmellcomboBox.Enabled = false;

            oilsappcomboBox1.Enabled = false;

            fluidssmellcomboBox.Enabled = false;
            othercombo.Enabled = false;

            if (fuelssmellcomboBox.SelectedValue.ToString() != " ")
            {
                string w;


                w = "(Fuels(smell " + fuelssmellcomboBox.SelectedValue.ToString() + "))";
                melo.AssertString(w);


            }
        }

        private void touchcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            touchcomboBox.Enabled = false;

            oilsappcomboBox1.Enabled = false;

            fluidssmellcomboBox.Enabled = false;
            othercombo.Enabled = false;

            if (touchcomboBox.SelectedValue.ToString() != " ")
            {
                string z;


                z = "(Fuels(touch " + touchcomboBox.SelectedValue.ToString() + "))";
                melo.AssertString(z);




            }
        }

        private void carfluidreset_Click(object sender, EventArgs e)
        {
            carfluidreset.Enabled = false;
            PopulateComboBox();



            if (vehiclefluidsrichTextBox.Text != null)
            {
                vehiclefluidsrichTextBox.Clear();
            }





            view2.Enabled = true;


            oilsappcomboBox1.Enabled = true;


            othercombo.Enabled = true;



            fuelsappcomboBox.Enabled = true;


            fluidssmellcomboBox.Enabled = true;


            fuelssmellcomboBox.Enabled = true;


            touchcomboBox.Enabled = true;
        }

        private void view2_Click(object sender, EventArgs e)
        {
            carfluidreset.Enabled = true;
            view2.Enabled = false;

            cf.Clear();
            melo.Run();


            if (cf.TextLength != 0)
            {
                vehiclefluidsrichTextBox.Font = new Font("Segoe UI", 18.00F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                vehiclefluidsrichTextBox.Text = cf.Text;


            }

            else
            {
                vehiclefluidsrichTextBox.Font = new System.Drawing.Font("SimSun", 22.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                var x = "You have NOT selected any symptoms or Symptoms chosen do not describe vehicle fluids." + "If selection has been done;Please seek the services of a professional for further diagnosis.";



                vehiclefluidsrichTextBox.Text = x;

            }
            melo.Eval("(reset)");
        }

        private void fluidsbutton_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == typeof(decisionwindow))
                {
                    f.Activate();


                    return;

                }
            }



            decisionwindow d = new decisionwindow();
            d.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, d.Width, d.Height, 40, 40));
            d.Show();





        }

    }
}
