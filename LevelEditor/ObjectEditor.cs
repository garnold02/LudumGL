#pragma warning disable IDE1006
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

using LudumGL;

namespace LevelEditor
{
    public partial class ObjectEditor : Form
    {
        public GameObject editedGameObject;
        public ObjectList listWindow;

        public ObjectEditor(GameObject gameObject)
        {
            InitializeComponent();
            Text = gameObject.Name;

            editedGameObject = gameObject;
            nameBox.Text = gameObject.Name;
            nameBox.TextChanged += NameChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void posXBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(posXBox.Text, TransformValue.PositionX);
        }

        private void posYBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(posYBox.Text, TransformValue.PositionY);
        }

        private void posZBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(posZBox.Text, TransformValue.PositionZ);
        }

        private void rotXBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(rotXBox.Text, TransformValue.RotationX);
        }

        private void rotYBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(rotYBox.Text, TransformValue.RotationY);
        }

        private void rotZBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(rotZBox.Text, TransformValue.RotationZ);
        }

        private void scaleYBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(scaleXBox.Text, TransformValue.ScaleX);
        }

        private void scaleXBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(scaleYBox.Text, TransformValue.ScaleY);
        }


        private void scaleZBox_TextChanged(object sender, EventArgs e)
        {
            ChangeTransformValue(scaleZBox.Text, TransformValue.ScaleZ);
        }

        void NameChanged(object sender, EventArgs e)
        {
            editedGameObject.Name = nameBox.Text;
            listWindow.UpdateList(this, new EventArgs());
        }

        void ChangeTransformValue(string raw, TransformValue value)
        {
            NumberFormatInfo info = new NumberFormatInfo { NumberDecimalSeparator = "." };

            if (!float.TryParse(raw, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, info, out float result))
            {
                result = 0;
            }

            switch (value)
            {
                case TransformValue.PositionX:
                    editedGameObject.Transform.localPosition.X = result;
                    break;
                case TransformValue.PositionY:
                    editedGameObject.Transform.localPosition.Y = result;
                    break;
                case TransformValue.PositionZ:
                    editedGameObject.Transform.localPosition.Z = result;
                    break;
                case TransformValue.RotationX:
                    editedGameObject.Transform.localRotation.X = result;
                    break;
                case TransformValue.RotationY:
                    editedGameObject.Transform.localRotation.Y = result;
                    break;
                case TransformValue.RotationZ:
                    editedGameObject.Transform.localRotation.Z = result;
                    break;
                case TransformValue.ScaleX:
                    editedGameObject.Transform.localScale.X = result;
                    break;
                case TransformValue.ScaleY:
                    editedGameObject.Transform.localScale.Y = result;
                    break;
                case TransformValue.ScaleZ:
                    editedGameObject.Transform.localScale.Z = result;
                    break;
            }
        }

        enum TransformValue
        {
            PositionX,
            PositionY,
            PositionZ,
            RotationX,
            RotationY,
            RotationZ,
            ScaleX,
            ScaleY,
            ScaleZ
        }

        private void customizeButton_Click(object sender, EventArgs e)
        {
            ComponentEditor editorWindow = new ComponentEditor();
            editorWindow.Show();
        }
    }
}
