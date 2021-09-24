
namespace Karma
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddNewNavigationButton = new System.Windows.Forms.Button();
            this.ProductNavigationButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Peru;
            this.panel1.Controls.Add(this.AddNewNavigationButton);
            this.panel1.Controls.Add(this.ProductNavigationButton);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 450);
            this.panel1.TabIndex = 0;
            // 
            // AddNewNavigationButton
            // 
            this.AddNewNavigationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddNewNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddNewNavigationButton.Location = new System.Drawing.Point(0, 131);
            this.AddNewNavigationButton.Name = "AddNewNavigationButton";
            this.AddNewNavigationButton.Size = new System.Drawing.Size(171, 70);
            this.AddNewNavigationButton.TabIndex = 2;
            this.AddNewNavigationButton.Text = "Add new product";
            this.AddNewNavigationButton.UseVisualStyleBackColor = false;
            this.AddNewNavigationButton.Click += new System.EventHandler(this.AddNewNavigationButton_Click);
            // 
            // ProductNavigationButton
            // 
            this.ProductNavigationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductNavigationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductNavigationButton.Location = new System.Drawing.Point(0, 67);
            this.ProductNavigationButton.Name = "ProductNavigationButton";
            this.ProductNavigationButton.Size = new System.Drawing.Size(171, 64);
            this.ProductNavigationButton.TabIndex = 1;
            this.ProductNavigationButton.Text = "Products";
            this.ProductNavigationButton.UseVisualStyleBackColor = true;
            this.ProductNavigationButton.Click += new System.EventHandler(this.ProductNavigationButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Peru;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 67);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Bisque;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(171, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 67);
            this.panel3.TabIndex = 1;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(171, 67);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(629, 383);
            this.ContentPanel.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddNewNavigationButton;
        private System.Windows.Forms.Button ProductNavigationButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel ContentPanel;
    }
}

