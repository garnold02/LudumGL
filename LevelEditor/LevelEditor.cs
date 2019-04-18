using System;
#pragma warning disable IDE1006
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
    public partial class LevelEditor : Form
    {
        public LevelEditor()
        {
            InitializeComponent();
        }

        private void objectListButton_Click(object sender, EventArgs e)
        {
            ObjectList objectList = new ObjectList();
            objectList.Show();
        }

        private void resourceManagerButton_Click(object sender, EventArgs e)
        {
            ResourceManager resourceManager = new ResourceManager();
            resourceManager.Show();
        }
    }
}
