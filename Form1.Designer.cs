namespace NeuralNetworksApp
{
    partial class NeuralNetworksAPPGUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworksAPPGUI));
            this.PictureSelector = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ShowButton = new System.Windows.Forms.Button();
            this.ClrButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameField = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ChooseDirectoryBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NxtButton = new System.Windows.Forms.Button();
            this.PrvButton = new System.Windows.Forms.Button();
            this.Help_button = new System.Windows.Forms.Button();
            this.pic_panel = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.ContextMNU = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Colorselect = new System.Windows.Forms.ToolStripMenuItem();
            this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileName = new System.Windows.Forms.SaveFileDialog();
            this.sedanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sUVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniVanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heavyTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.pic_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.ContextMNU.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureSelector
            // 
            this.PictureSelector.FileName = "openFileDialog1";
            resources.ApplyResources(this.PictureSelector, "PictureSelector");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ShowButton);
            this.flowLayoutPanel1.Controls.Add(this.ClrButton);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.NameField);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Controls.Add(this.ChooseDirectoryBTN);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // ShowButton
            // 
            resources.ApplyResources(this.ShowButton, "ShowButton");
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // ClrButton
            // 
            resources.ApplyResources(this.ClrButton, "ClrButton");
            this.ClrButton.Name = "ClrButton";
            this.ClrButton.UseVisualStyleBackColor = true;
            this.ClrButton.Click += new System.EventHandler(this.ClrButton_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // NameField
            // 
            resources.ApplyResources(this.NameField, "NameField");
            this.NameField.Name = "NameField";
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ChooseDirectoryBTN
            // 
            resources.ApplyResources(this.ChooseDirectoryBTN, "ChooseDirectoryBTN");
            this.ChooseDirectoryBTN.Name = "ChooseDirectoryBTN";
            this.ChooseDirectoryBTN.UseVisualStyleBackColor = true;
            this.ChooseDirectoryBTN.Click += new System.EventHandler(this.ChooseDirectoryBTN_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.NxtButton, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.PrvButton, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.Help_button, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.pic_panel, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // NxtButton
            // 
            resources.ApplyResources(this.NxtButton, "NxtButton");
            this.NxtButton.Name = "NxtButton";
            this.NxtButton.UseVisualStyleBackColor = true;
            this.NxtButton.Click += new System.EventHandler(this.NxtButton_Click);
            // 
            // PrvButton
            // 
            resources.ApplyResources(this.PrvButton, "PrvButton");
            this.PrvButton.Name = "PrvButton";
            this.PrvButton.UseVisualStyleBackColor = true;
            this.PrvButton.Click += new System.EventHandler(this.PrvButton_Click);
            // 
            // Help_button
            // 
            resources.ApplyResources(this.Help_button, "Help_button");
            this.Help_button.Name = "Help_button";
            this.Help_button.UseVisualStyleBackColor = true;
            this.Help_button.Click += new System.EventHandler(this.Help_button_Click);
            // 
            // pic_panel
            // 
            resources.ApplyResources(this.pic_panel, "pic_panel");
            this.pic_panel.Controls.Add(this.pictureBox);
            this.pic_panel.Name = "pic_panel";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // ContextMNU
            // 
            this.ContextMNU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Colorselect,
            this.typeToolStripMenuItem});
            this.ContextMNU.Name = "contextMenuStrip1";
            resources.ApplyResources(this.ContextMNU, "ContextMNU");
            // 
            // Colorselect
            // 
            this.Colorselect.Name = "Colorselect";
            resources.ApplyResources(this.Colorselect, "Colorselect");
            this.Colorselect.Click += new System.EventHandler(this.Colorselect_Click);
            // 
            // typeToolStripMenuItem
            // 
            this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miniBusToolStripMenuItem,
            this.bUSToolStripMenuItem,
            this.miniVanToolStripMenuItem,
            this.sedanToolStripMenuItem,
            this.sUVToolStripMenuItem,
            this.lightTruckToolStripMenuItem,
            this.mediumTruckToolStripMenuItem,
            this.heavyTruckToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
            this.typeToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            resources.ApplyResources(this.typeToolStripMenuItem, "typeToolStripMenuItem");
            // 
            // sedanToolStripMenuItem
            // 
            this.sedanToolStripMenuItem.Name = "sedanToolStripMenuItem";
            resources.ApplyResources(this.sedanToolStripMenuItem, "sedanToolStripMenuItem");
            this.sedanToolStripMenuItem.Click += new System.EventHandler(this.Get_Carname);
            // 
            // sUVToolStripMenuItem
            // 
            this.sUVToolStripMenuItem.Name = "sUVToolStripMenuItem";
            resources.ApplyResources(this.sUVToolStripMenuItem, "sUVToolStripMenuItem");
            this.sUVToolStripMenuItem.Click += new System.EventHandler(this.Get_Carname);
            // 
            // miniVanToolStripMenuItem
            // 
            this.miniVanToolStripMenuItem.Name = "miniVanToolStripMenuItem";
            resources.ApplyResources(this.miniVanToolStripMenuItem, "miniVanToolStripMenuItem");
            this.miniVanToolStripMenuItem.Click += new System.EventHandler(this.Get_Carname);
            // 
            // bUSToolStripMenuItem
            // 
            this.bUSToolStripMenuItem.Name = "bUSToolStripMenuItem";
            resources.ApplyResources(this.bUSToolStripMenuItem, "bUSToolStripMenuItem");
            this.bUSToolStripMenuItem.Click += new System.EventHandler(this.Get_Carname);
            // 
            // miniBusToolStripMenuItem
            // 
            this.miniBusToolStripMenuItem.Name = "miniBusToolStripMenuItem";
            resources.ApplyResources(this.miniBusToolStripMenuItem, "miniBusToolStripMenuItem");
            this.miniBusToolStripMenuItem.Click += new System.EventHandler(this.Get_Carname);
            // 
            // lightTruckToolStripMenuItem
            // 
            this.lightTruckToolStripMenuItem.Name = "lightTruckToolStripMenuItem";
            resources.ApplyResources(this.lightTruckToolStripMenuItem, "lightTruckToolStripMenuItem");
            // 
            // mediumTruckToolStripMenuItem
            // 
            this.mediumTruckToolStripMenuItem.Name = "mediumTruckToolStripMenuItem";
            resources.ApplyResources(this.mediumTruckToolStripMenuItem, "mediumTruckToolStripMenuItem");
            // 
            // heavyTruckToolStripMenuItem
            // 
            this.heavyTruckToolStripMenuItem.Name = "heavyTruckToolStripMenuItem";
            resources.ApplyResources(this.heavyTruckToolStripMenuItem, "heavyTruckToolStripMenuItem");
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            resources.ApplyResources(this.othersToolStripMenuItem, "othersToolStripMenuItem");
            // 
            // NeuralNetworksAPPGUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.tableLayoutPanel);
            this.KeyPreview = true;
            this.Name = "NeuralNetworksAPPGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeuralNetworksGUI_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NeuralNetworksAPPGUI_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.pic_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ContextMNU.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog PictureSelector;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.Button ClrButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button PrvButton;
        private System.Windows.Forms.Button NxtButton;
        private System.Windows.Forms.ContextMenuStrip ContextMNU;
        private System.Windows.Forms.ToolStripMenuItem Colorselect;
        private System.Windows.Forms.SaveFileDialog SaveFileName;
        private System.Windows.Forms.Button ChooseDirectoryBTN;
        private System.Windows.Forms.Button Help_button;
        private System.Windows.Forms.Panel pic_panel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem sedanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sUVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniVanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bUSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniBusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heavyTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
    }
}

