using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class AdministracionCustomMenuStrip : UserControl
    {
        public AdministracionCustomMenuStrip()
        {
            InitializeComponent();
        }

        private void CustomButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.Black;
        }

        private void CustomButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.White;
        }
    }
}
