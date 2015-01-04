namespace HttpNamespaceManager.UI
{
    partial class AccessControlListDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessControlListDialog));
            this.labelObjectNameLabel = new System.Windows.Forms.Label();
            this.labelObjectName = new System.Windows.Forms.Label();
            this.labelUsersAndGroups = new System.Windows.Forms.Label();
            this.listUsersAndGroups = new System.Windows.Forms.ListBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.aclListPermissions = new HttpNamespaceManager.UI.AccessControlRightsListBox();
            this.SuspendLayout();
            // 
            // labelObjectNameLabel
            // 
            this.labelObjectNameLabel.AutoSize = true;
            this.labelObjectNameLabel.Location = new System.Drawing.Point(12, 9);
            this.labelObjectNameLabel.Name = "labelObjectNameLabel";
            this.labelObjectNameLabel.Size = new System.Drawing.Size(70, 13);
            this.labelObjectNameLabel.TabIndex = 0;
            this.labelObjectNameLabel.Text = "Object name:";
            // 
            // labelObjectName
            // 
            this.labelObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelObjectName.AutoEllipsis = true;
            this.labelObjectName.Location = new System.Drawing.Point(88, 9);
            this.labelObjectName.Name = "labelObjectName";
            this.labelObjectName.Size = new System.Drawing.Size(286, 23);
            this.labelObjectName.TabIndex = 1;
            this.labelObjectName.Text = "name";
            // 
            // labelUsersAndGroups
            // 
            this.labelUsersAndGroups.AutoSize = true;
            this.labelUsersAndGroups.Location = new System.Drawing.Point(12, 37);
            this.labelUsersAndGroups.Name = "labelUsersAndGroups";
            this.labelUsersAndGroups.Size = new System.Drawing.Size(109, 13);
            this.labelUsersAndGroups.TabIndex = 2;
            this.labelUsersAndGroups.Text = "Group or User Names";
            // 
            // listUsersAndGroups
            // 
            this.listUsersAndGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listUsersAndGroups.FormattingEnabled = true;
            this.listUsersAndGroups.IntegralHeight = false;
            this.listUsersAndGroups.Location = new System.Drawing.Point(12, 53);
            this.listUsersAndGroups.Name = "listUsersAndGroups";
            this.listUsersAndGroups.Size = new System.Drawing.Size(362, 136);
            this.listUsersAndGroups.TabIndex = 3;
            this.listUsersAndGroups.SelectedIndexChanged += new System.EventHandler(this.listUsersAndGroups_SelectedIndexChanged);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(299, 195);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(218, 195);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add...";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(299, 342);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(218, 342);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 10;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // aclListPermissions
            // 
            this.aclListPermissions.ACL = null;
            this.aclListPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.aclListPermissions.BackColor = System.Drawing.SystemColors.Control;
            this.aclListPermissions.Location = new System.Drawing.Point(12, 224);
            this.aclListPermissions.Name = "aclListPermissions";
            this.aclListPermissions.SelectedUser = null;
            this.aclListPermissions.Size = new System.Drawing.Size(362, 112);
            this.aclListPermissions.TabIndex = 11;
            // 
            // AccessControlListDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 377);
            this.Controls.Add(this.aclListPermissions);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listUsersAndGroups);
            this.Controls.Add(this.labelUsersAndGroups);
            this.Controls.Add(this.labelObjectName);
            this.Controls.Add(this.labelObjectNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 413);
            this.Name = "AccessControlListDialog";
            this.ShowInTaskbar = false;
            this.Text = "Permissions";
            this.Load += new System.EventHandler(this.AccessControlListDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelObjectNameLabel;
        private System.Windows.Forms.Label labelObjectName;
        private System.Windows.Forms.Label labelUsersAndGroups;
        private System.Windows.Forms.ListBox listUsersAndGroups;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private AccessControlRightsListBox aclListPermissions;
    }
}