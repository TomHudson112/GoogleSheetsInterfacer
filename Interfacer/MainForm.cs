using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GW;

namespace Interfacer {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

			GSService sheetsService = new GSService();
			GSheet sheetsWrapper = new GSheet(sheetsService, "Test Spreadsheet", "First Sheet");
		}

		private void TemplateDesignPanel_Paint(object sender, PaintEventArgs e) {

		}
	}
}
