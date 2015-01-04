namespace HttpNamespaceManager.UI
{
    partial class AccessControlRightsListBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelListBox = new System.Windows.Forms.Panel();
            this.tableRights = new System.Windows.Forms.TableLayoutPanel();
            this.tableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panelListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelListBox
            // 
            this.panelListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelListBox.BackColor = System.Drawing.SystemColors.Window;
            this.panelListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelListBox.Controls.Add(this.tableRights);
            this.panelListBox.Location = new System.Drawing.Point(0, 26);
            this.panelListBox.Name = "panelListBox";
            this.panelListBox.Size = new System.Drawing.Size(146, 124);
            this.panelListBox.TabIndex = 1;
            // 
            // tableRights
            // 
            this.tableRights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableRights.AutoScroll = true;
            this.tableRights.ColumnCount = 1;
            this.tableRights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableRights.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableRights.Location = new System.Drawing.Point(2, -1);
            this.tableRights.Name = "tableRights";
            this.tableRights.RowCount = 1;
            this.tableRights.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableRights.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 127F));
            this.tableRights.Size = new System.Drawing.Size(143, 122);
            this.tableRights.TabIndex = 1;
            // 
            // tableHeader
            // 
            this.tableHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableHeader.AutoSize = true;
            this.tableHeader.ColumnCount = 1;
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHeader.Location = new System.Drawing.Point(0, 0);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.RowCount = 1;
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHeader.Size = new System.Drawing.Size(143, 20);
            this.tableHeader.TabIndex = 2;
            // 
            // AccessControlRightsListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableHeader);
            this.Controls.Add(this.panelListBox);
            this.Name = "AccessControlRightsListBox";
            this.Size = new System.Drawing.Size(146, 150);
            this.panelListBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelListBox;
        private System.Windows.Forms.TableLayoutPanel tableRights;
        private System.Windows.Forms.TableLayoutPanel tableHeader;

    }
}
