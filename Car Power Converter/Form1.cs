using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Power_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updateCalculations(object sender, EventArgs e)
        {
            bool status = false;
            bool status2 = false;
            double kilos;
            switch ((sender as Control).Name)
            {
                case "kilowatts":
                    status = double.TryParse(kilowatts.Text, out kilos);
                    if (!status) return;
                    horsepower.Text = Convert.ToString(kilos / 0.745699872);
                    break;
                case "horsepower":
                    status = double.TryParse(horsepower.Text, out double hps);
                    if (!status) return;
                    kilowatts.Text = Convert.ToString(0.745699872 * hps);
                    break;
                case "rpm":
                    status = double.TryParse(kilowatts.Text, out kilos);
                    status2 = double.TryParse(rpm.Text, out double speed);
                    if (!status || !status2) return;
                    torque.Text = Convert.ToString(9.5488 * kilos / speed);
                    break;
                case "torque":
                    status = double.TryParse(kilowatts.Text, out kilos);
                    status2 = double.TryParse(torque.Text, out double torq);
                    if (!status || !status2) return;
                    rpm.Text = Convert.ToString(9.5488 * kilos / torq);
                    break;
                default:
                    break;
            }
        }

        private void torSpeedKilos(object sender, EventArgs e)
        {
            bool status = double.TryParse(torqueSeperate.Text, out double torq);
            bool status2 = double.TryParse(speedSeperate.Text, out double speed);
            if (!status || !status2) return;
            kilowattsSeperate.Text = Convert.ToString(torq * speed / 9.5488);
        }

        private void update_Click(object sender, EventArgs e)
        {
            kilowatts.Text = kilowattsSeperate.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(707, 219);
        }
    }
}
