using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VibroMath; 

namespace VibrationCalculatorFormApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void TSensitivity_KeyPress(object sender, KeyPressEventArgs e) {
           
        }

        private void TSensitivity_TextChanged(object sender, EventArgs e) {
            
            Sensitivity sensitivity = new Sensitivity();
            if (radSensitivityG.Checked) {
                sensitivity.Set_mV_G(double.Parse(TSensitivity.Text));
            }
            if (radSensitivityM.Checked) {
                sensitivity.Set_mV_MS2(double.Parse(TSensitivity.Text));
            }
            if (radAccSensFreq.Checked) {
                VibroCalc.CalcAll(sensitivity, Freeze.Acceleration);
            }
            if (radVelSensFreq.Checked) {
                VibroCalc.CalcAll(sensitivity, Freeze.Velocity);
            }
            if (radDispSensFreq.Checked) {
                VibroCalc.CalcAll(sensitivity, Freeze.Displacement);
            }
             
        }

        private void TFrequency_TextChanged(object sender, EventArgs e) {

        }
    }
}
