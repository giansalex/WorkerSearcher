using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkSearcher.BL;

namespace WorkSearcher.UI
{
    public partial class Form1 : Form
    {
        private ISearcher _searcher;
        public Form1(ISearcher searcher)
        {
            _searcher = searcher;
            InitializeComponent();
        }


    }
}
