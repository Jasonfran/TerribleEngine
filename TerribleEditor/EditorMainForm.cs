using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using OpenTK;
using OpenTK.Graphics;
using TerribleEngine;
using TerribleEngine.Enums;

namespace TerribleEditor
{
    public partial class EditorMainForm : Form
    {
        private TerribleApp _engine;

        private delegate void SetPerformanceInfo(string performanceString);

        private SetPerformanceInfo performanceInfoDelegate;

        public EditorMainForm()
        {
            InitializeComponent();
            var node = new KryptonTreeNode("Test");
            sceneTreeView.Nodes.Add(node);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Init();
        }

        public void Init()
        {
            _engine = new TerribleApp();
            _engine.Init(LaunchState.Editor, new InitialiseSettings()
            {
                Context = glControl1.Context,
                WindowInfo = glControl1.WindowInfo,
                Height = glControl1.Height,
                Width = glControl1.Width
            });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _engine.Exit();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (_engine != null && glControl1.HasValidContext)
            {
                _engine.Renderer.Resize(glControl1.Width, glControl1.Height);
            }
        }
    }
}