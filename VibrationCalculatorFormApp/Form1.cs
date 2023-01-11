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
public enum TextboxIsChangeable {
    Acceleration,
    Acceleration_dB
}
namespace VibrationCalculatorFormApp {
    public partial class Form1 : Form {
        SignalParametrType AccType = SignalParametrType.RMS; // объяснить
        SensitivityType SenType = SensitivityType.mV_G;
        Freeze Freeze = Freeze.Acceleration;
        

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

            // После изменений в библиотеке и добавления полей для чекбоксов метод сокращается: 
            if (double.TryParse(TSensitivity.Text, out double result)) {
                VibroCalc.CalcAll(new Sensitivity(result, SenType), Freeze);
            }
                
        }

        private void TFrequency_TextChanged(object sender, EventArgs e) {

        }

        private void TAcceleration_TextChanged(object sender, EventArgs e) {

        }

        private void radAccelerationRMS_CheckedChanged(object sender, EventArgs e) {
            /// Добавил рассказать
            if (radAccelerationRMS.Checked) {
                AccType = SignalParametrType.RMS;
            }
            /// Добавить push textboxes
        }
        private void PushAllTextboxes(TextboxIsChangeable isChangeable) {
            if(isChangeable != TextboxIsChangeable.Acceleration) {
                TAcceleration.Text = VibroCalc.Acceleration.Get
            }
        }
    }
}
