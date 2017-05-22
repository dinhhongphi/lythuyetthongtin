using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruyenTin.src;

namespace TruyenTin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Client client = new Client();
            client.Handler();
        }
    }
}
