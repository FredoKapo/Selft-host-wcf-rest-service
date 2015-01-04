using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttpNamespaceManager.Lib.AccessControl;

namespace HttpNamespaceManager.UI
{
    public partial class AccessControlListDialog : Form
    {
        private string objectName;
        private AccessControlList acl;
        private List<SecurityIdentity> userList;

        public string ObjectName
        {
            get { return this.objectName; }
        }

        public AccessControlList ACL
        {
            get { return this.acl; }
        }

        public AccessControlListDialog()
        {
            InitializeComponent();
        }

        public AccessControlListDialog(string objectName, AccessControlList acl, List<AceRights> supportedRights, List<AceType> supportedTypes)
        {
            InitializeComponent();
            if (objectName == null)
            {
                throw new ArgumentNullException("objectName");
            }

            if (acl == null)
            {
                throw new ArgumentNullException("acl");
            }

            this.objectName = objectName;
            this.acl = acl;
            this.labelObjectName.Text = objectName;

            this.userList = new List<SecurityIdentity>();

            foreach (AccessControlEntry ace in this.acl)
            {
                if (!this.userList.Contains(ace.AccountSID))
                {
                    this.userList.Add(ace.AccountSID);
                }
            }

            this.aclListPermissions.SupportedRights.AddRange(supportedRights);
            this.aclListPermissions.SupportedTypes.AddRange(supportedTypes);
            this.aclListPermissions.ACL = this.acl;
        }

        private void AccessControlListDialog_Load(object sender, EventArgs e)
        {
            if (this.userList != null)
            {
                foreach (SecurityIdentity sid in this.userList)
                {
                    this.listUsersAndGroups.Items.Add(sid);
                }

                this.listUsersAndGroups.DisplayMember = "Name";

                if (this.listUsersAndGroups.Items.Count > 0) this.listUsersAndGroups.SelectedIndex = 0;
                else
                {
                    this.aclListPermissions.UpdateList();
                }
            }
        }

        private void listUsersAndGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.aclListPermissions.SelectedUser = (SecurityIdentity)this.listUsersAndGroups.SelectedItem;

            this.aclListPermissions.UpdateList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string accountName;
            if (InputBox.Show("Add User or Group", "Enter the User or Group Name:", out accountName) == DialogResult.OK)
            {
                try
                {
                    SecurityIdentity sid = SecurityIdentity.SecurityIdentityFromName(accountName);
                    
                    if (MessageBox.Show(String.Format("Add user or group: {0}?", sid.Name), "User or Group Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!this.userList.Contains(sid))
                        {
                            AccessControlEntry ace = new AccessControlEntry(sid);
                            ace.AceType = AceType.AccessAllowed;
                            this.acl.Add(ace);
                            this.userList.Add(sid);
                            this.listUsersAndGroups.Items.Add(sid);
                        }
                        else
                        {
                            MessageBox.Show("The selected user or group already exists.", "Duplicate User or Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("User or group name was not found. " + ex.Message, "User or Group Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (this.listUsersAndGroups.SelectedItem != null)
            {
                SecurityIdentity sid = (SecurityIdentity)this.listUsersAndGroups.SelectedItem;

                List<AccessControlEntry> toDelete = new List<AccessControlEntry>();

                foreach (AccessControlEntry ace in this.acl)
                {
                    if (ace.AccountSID == sid)
                    {
                        toDelete.Add(ace);
                    }
                }

                foreach (AccessControlEntry deleteAce in toDelete)
                {
                    this.acl.Remove(deleteAce);
                }

                this.userList.Remove(sid);

                this.listUsersAndGroups.Items.Remove(sid);
            }
        }
    }
}