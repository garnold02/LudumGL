using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class ComponentEditor : Form
    {
        public ComponentEditor()
        {
            InitializeComponent();
            foreach (Type type in Program.componentTypes)
            {
                componentSelectorBox.Items.Add(type.Name);
            }
        }

        private void componentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
