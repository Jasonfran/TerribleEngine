using OpenTK.Graphics;

namespace TerribleEditor
{
    partial class EditorMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.mainSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.leftSplitContainer = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.settingsTabControl = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.sceneTreePage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.sceneTreeView = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.settingsPage = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.glControl1 = new OpenTK.GLControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer.Panel1)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer.Panel2)).BeginInit();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer.Panel1)).BeginInit();
            this.leftSplitContainer.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer.Panel2)).BeginInit();
            this.leftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsTabControl)).BeginInit();
            this.settingsTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sceneTreePage)).BeginInit();
            this.sceneTreePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPage)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(0, 0);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 0;
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.leftSplitContainer);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.glControl1);
            this.mainSplitContainer.Size = new System.Drawing.Size(1567, 767);
            this.mainSplitContainer.SplitterDistance = 522;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // leftSplitContainer
            // 
            this.leftSplitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.leftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.leftSplitContainer.Name = "leftSplitContainer";
            this.leftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftSplitContainer.Panel1
            // 
            this.leftSplitContainer.Panel1.Controls.Add(this.settingsTabControl);
            this.leftSplitContainer.Size = new System.Drawing.Size(522, 767);
            this.leftSplitContainer.SplitterDistance = 480;
            this.leftSplitContainer.TabIndex = 1;
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.sceneTreePage,
            this.settingsPage});
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(522, 480);
            this.settingsTabControl.TabIndex = 0;
            this.settingsTabControl.Text = "kryptonNavigator1";
            // 
            // sceneTreePage
            // 
            this.sceneTreePage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.sceneTreePage.Controls.Add(this.sceneTreeView);
            this.sceneTreePage.Flags = 65534;
            this.sceneTreePage.LastVisibleSet = true;
            this.sceneTreePage.MinimumSize = new System.Drawing.Size(50, 50);
            this.sceneTreePage.Name = "sceneTreePage";
            this.sceneTreePage.Size = new System.Drawing.Size(520, 447);
            this.sceneTreePage.Text = "Scene tree";
            this.sceneTreePage.ToolTipTitle = "Page ToolTip";
            this.sceneTreePage.UniqueName = "0C60F8CA6F1340AB8A887E2181642713";
            // 
            // sceneTreeView
            // 
            this.sceneTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sceneTreeView.Location = new System.Drawing.Point(0, 0);
            this.sceneTreeView.Name = "sceneTreeView";
            this.sceneTreeView.Size = new System.Drawing.Size(520, 447);
            this.sceneTreeView.TabIndex = 0;
            // 
            // settingsPage
            // 
            this.settingsPage.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.settingsPage.Flags = 65534;
            this.settingsPage.LastVisibleSet = true;
            this.settingsPage.MinimumSize = new System.Drawing.Size(50, 50);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(520, 447);
            this.settingsPage.Text = "Settings";
            this.settingsPage.ToolTipTitle = "Page ToolTip";
            this.settingsPage.UniqueName = "109E9AE0FC0A42A5BDBA71A682177B75";
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1040, 767);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // EditorMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(125F, 125F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1567, 767);
            this.Controls.Add(this.mainSplitContainer);
            this.Name = "EditorMainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer.Panel1)).EndInit();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer.Panel2)).EndInit();
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer.Panel1)).EndInit();
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).EndInit();
            this.leftSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsTabControl)).EndInit();
            this.settingsTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sceneTreePage)).EndInit();
            this.sceneTreePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settingsPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer mainSplitContainer;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer leftSplitContainer;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator settingsTabControl;
        private ComponentFactory.Krypton.Navigator.KryptonPage sceneTreePage;
        private ComponentFactory.Krypton.Navigator.KryptonPage settingsPage;
        private OpenTK.GLControl glControl1;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView sceneTreeView;
    }
}

