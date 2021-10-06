
namespace Karma
{
    partial class MarketForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.ItemLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.AddNewButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 79);
            this.panel1.TabIndex = 0;
            // 
            // AddNewButton
            // 
            this.AddNewButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddNewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewButton.Location = new System.Drawing.Point(632, 0);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(168, 79);
            this.AddNewButton.TabIndex = 0;
            this.AddNewButton.Text = "Add new product";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.AddNewButtonClick);
            // 
            // ItemLayoutPanel
            // 
            this.ItemLayoutPanel.AutoScroll = true;
            this.ItemLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemLayoutPanel.Location = new System.Drawing.Point(0, 79);
            this.ItemLayoutPanel.Name = "ItemLayoutPanel";
            this.ItemLayoutPanel.Size = new System.Drawing.Size(800, 371);
            this.ItemLayoutPanel.TabIndex = 1;
            // 
            // MarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ItemLayoutPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MarketForm";
            this.Text = "MarketForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MarketForm_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.FlowLayoutPanel ItemLayoutPanel;
    }
}