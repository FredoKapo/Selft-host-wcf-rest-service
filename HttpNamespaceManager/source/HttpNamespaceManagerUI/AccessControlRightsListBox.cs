using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HttpNamespaceManager.Lib.AccessControl;

namespace HttpNamespaceManager.UI
{
    public partial class AccessControlRightsListBox : UserControl
    {
        private List<AceRights> supportedRights;
        private List<AceType> supportedTypes;
        private AccessControlList acl;
        private SecurityIdentity selectedUser;

        public List<AceRights> SupportedRights
        {
            get { return this.supportedRights; }
        }

        public List<AceType> SupportedTypes
        {
            get { return this.supportedTypes; }
        }

        public AccessControlList ACL
        {
            get
            {
                return this.acl;
            }
            set
            {
                this.acl = value;
            }
        }

        public SecurityIdentity SelectedUser
        {
            get
            {
                return this.selectedUser;
            }
            set
            {
                this.selectedUser = value;
            }
        }

        public AccessControlRightsListBox()
        {
            InitializeComponent();

            this.supportedRights = new List<AceRights>();
            this.supportedTypes = new List<AceType>();
        }

        public void UpdateList()
        {
            this.tableRights.SuspendLayout();

            this.tableHeader.Controls.Clear();
            this.tableHeader.ColumnCount = this.supportedTypes.Count + 1;
            this.tableHeader.ColumnStyles.Clear();

            this.tableRights.Controls.Clear();
            this.tableRights.ColumnCount = this.supportedTypes.Count + 1;
            this.tableRights.RowCount = this.supportedRights.Count;
            this.tableRights.RowStyles.Clear();
            this.tableRights.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.tableRights.ColumnStyles.Clear();
            this.tableRights.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            int maxsize = 0;
            
            int col = 1;
            foreach (AceType type in this.supportedTypes)
            {

                Label labelAceType = new Label();
                labelAceType.Name = String.Format("labelAceType{0}", col.ToString());
                labelAceType.Text = type.ToString();
                labelAceType.TextAlign = ContentAlignment.MiddleCenter;
                labelAceType.Dock = DockStyle.Fill;
                this.tableRights.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, labelAceType.Width));
                this.tableHeader.Controls.Add(labelAceType, col++, 0);
            }

            int row = 0;
            foreach (AceRights right in this.supportedRights)
            {
                if (this.selectedUser != null)
                {
                    col = 1;
                    foreach (AceType type in this.supportedTypes)
                    {
                        CheckBox checkAceType = new CheckBox();
                        checkAceType.Name = String.Format("checkAceType{0}", col.ToString());
                        checkAceType.Text = "";
                        checkAceType.Size = new Size(15, 14);
                        checkAceType.CheckAlign = ContentAlignment.MiddleCenter;
                        checkAceType.Dock = DockStyle.Fill;
                        checkAceType.Checked = GetRightValue(type, right);
                        checkAceTypeCheckedHandler checkedHandler = new checkAceTypeCheckedHandler(this, type, right);
                        checkAceType.CheckedChanged += new EventHandler(checkedHandler.checkAceType_Checked);
                        this.tableRights.Controls.Add(checkAceType, col++, row);
                    }
                }

                Label labelRight = new Label();
                labelRight.Name = String.Format("labelRight{0}", row.ToString());
                labelRight.Text = right.ToString();
                labelRight.TextAlign = ContentAlignment.MiddleLeft;

                maxsize = Math.Max(maxsize, labelRight.Width);

                this.tableRights.Controls.Add(labelRight, 0, row++);
            }

            this.tableHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, maxsize));
            this.tableHeader.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            this.tableRights.ResumeLayout(true);
        }

        private class checkAceTypeCheckedHandler
        {
            private AccessControlRightsListBox parent;
            private AceType aceType;
            private AceRights aceRight;

            public checkAceTypeCheckedHandler(AccessControlRightsListBox parent, AceType aceType, AceRights aceRight)
            {
                this.parent = parent;
                this.aceType = aceType;
                this.aceRight = aceRight;
            }

            public void checkAceType_Checked(object sender, EventArgs e)
            {
                parent.HandleCheckBoxClick((CheckBox)sender, aceType, aceRight);
            }
        }

        private bool GetRightValue(AceType aceType, AceRights aceRight)
        {
            foreach (AccessControlEntry ace in this.acl)
            {
                if (ace.AceType == aceType && ace.AccountSID == this.selectedUser)
                {
                    foreach (AceRights right in ace)
                    {
                        if (right == aceRight) return true;
                    }
                }
            }
            return false;
        }

        private void HandleCheckBoxClick(CheckBox source, AceType aceType, AceRights aceRight)
        {
            foreach (AccessControlEntry ace in this.acl)
            {
                if (ace.AceType == aceType && ace.AccountSID == this.selectedUser)
                {
                    if (source.Checked)
                    {
                        ace.Add(aceRight);
                    }
                    else
                    {
                        ace.Remove(aceRight);
                    }
                    return;
                }
            }

            // The ace type doesn't exist

            AccessControlEntry newAce = new AccessControlEntry(this.selectedUser);
            newAce.AceType = aceType;
            newAce.Add(aceRight);
            this.acl.Add(newAce);
        }
    }
}
