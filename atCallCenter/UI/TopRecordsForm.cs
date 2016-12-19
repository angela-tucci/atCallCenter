using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atCallCenter.UI
{
    public partial class TopRecordsForm : Form
    {
        public TopRecordsForm(BindingSource bs)
        {
            InitializeComponent();
            
            dataGridViewTopRecords.DataSource = bs;
            dataGridViewTopRecords.Columns[7].Visible = false; //hide the column with the Rate object
        }
    }
}
