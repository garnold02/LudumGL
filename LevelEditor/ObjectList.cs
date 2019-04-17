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

using LudumGL;

namespace LevelEditor
{
    public partial class ObjectList : Form
    {
        public GameObject selectedGameObject;

        public ObjectList()
        {
            InitializeComponent();
            Program.SceneObjectListChanged += UpdateList;
            objectListBox.SelectedIndexChanged += SelectedObject;
        }

        private void objectListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void UpdateList(object sender, EventArgs e)
        {
            objectListBox.Items.Clear();
            foreach (GameObject gameObject in Program.sceneObjects)
            {
                objectListBox.Items.Add(gameObject.Name);
            }
        }

        private void addObjectButton_Click(object sender, EventArgs e)
        {
            GameObject gameObject = new GameObject();
            Program.AddObject(gameObject);
        }

        void SelectedObject(object sender, EventArgs e)
        {
            if(objectListBox.SelectedIndex<Program.sceneObjects.Capacity & objectListBox.SelectedIndex>=0)
            {
                selectedGameObject = Program.sceneObjects[objectListBox.SelectedIndex];
            }
            editObjectButton.Enabled = true;
        }

        private void editObjectButton_Click(object sender, EventArgs e)
        {
            ObjectEditor editorWindow = new ObjectEditor(selectedGameObject)
            {
                listWindow = this
            };
            editorWindow.Show();
        }

        private void removeObjectButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove object", MessageBoxButtons.YesNo);
            if(dialogResult==DialogResult.Yes)
            {
                Program.RemoveObject(selectedGameObject);
            }
        }
    }
}
