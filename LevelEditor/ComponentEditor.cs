#pragma warning disable IDE1006
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using LudumGL.Scene;

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

        private void componentSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type component = Program.componentTypes[componentSelectorBox.SelectedIndex];
            FieldInfo[] fields = component.GetFields().Where(field => field.IsDefined(typeof(SceneData))).ToArray();
            PropertyInfo[] properties = component.GetProperties().Where(property => property.IsDefined(typeof(SceneData))).ToArray();

            propertyComboBox.Items.Clear();
            foreach (FieldInfo field in fields)
            {
                propertyComboBox.Items.Add(field.Name);
            }
            foreach (PropertyInfo property in properties)
            {
                propertyComboBox.Items.Add(property.Name);
            }
        }

        private void propertyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
