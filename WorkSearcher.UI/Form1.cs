using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            var urls = GetUrls();
            listResult.Items.AddRange(urls.Select(r => (object)r.AbsoluteUri).ToArray());
        }

        private Uri[] GetUrls()
        {
            var searches = txtSearch.Text.Split(',');
            return _searcher.Search(searches).ToArray();
        }
        
        private void listResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listResult.IndexFromPoint(e.Location);
            if (index == System.Windows.Forms.ListBox.NoMatches) return;
            var item = listResult.Items[index];
            Process.Start(item.ToString());
        }
    }
}
