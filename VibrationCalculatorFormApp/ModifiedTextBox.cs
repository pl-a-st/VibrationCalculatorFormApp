using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VibrationCalculatorFormApp {
    public enum Access {
        UnLock,
        Blocked
    }
    class ModifiedTextBox:TextBox {
        private string LastText;
        public Access Access = Access.UnLock;
        protected override void OnTextChanged(EventArgs e) {
            if (Access == Access.Blocked) {
                return;
            }
            if (IsNotTextDoubleOrSpace()) {
                ReturnLastText();
                return;
            }
            LastText = Text;
            base.OnTextChanged(e);
        }
        private void ReturnLastText () {
            Access = Access.Blocked;
            Text = LastText;
            Access = Access.UnLock;
            SelectionStart = Text.Length;
        }
        private bool IsNotTextDoubleOrSpace() {
            return !double.TryParse(Text, out _) && Text != "";
        }
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (e.KeyChar =='.'|| e.KeyChar == ',') {
                e.KeyChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            }
            if (char.IsWhiteSpace(e.KeyChar)) {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
}
