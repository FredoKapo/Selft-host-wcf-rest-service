using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttpNamespaceManager.Lib;
using HttpNamespaceManager.Lib.AccessControl;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace HttpNamespaceManager.UI
{
    public partial class MainForm : Form
    {
        private HttpApi nsManager;
        Dictionary<string, SecurityDescriptor> nsTable;

        NamespaceManagerAction action = NamespaceManagerAction.None;
        string initialUrl = null;

        public MainForm()
        {
            nsManager = new HttpApi();
            InitializeComponent();
        }

        public MainForm(NamespaceManagerAction action, string url)
        {
            nsManager = new HttpApi();
            InitializeComponent();

            this.action = action;
            this.initialUrl = url;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.nsTable = this.nsManager.QueryHttpNamespaceAcls();

            foreach (string prefix in this.nsTable.Keys)
            {
                this.listHttpNamespaces.Items.Add(prefix);
            }

            if (this.initialUrl != null) listHttpNamespaces.SelectedItem = this.initialUrl;
            else listHttpNamespaces.SelectedIndex = 0;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.action != NamespaceManagerAction.None)
            {
                switch (this.action)
                {
                    case NamespaceManagerAction.Add:
                        buttonAdd_Click(this, new EventArgs());
                        break;
                    case NamespaceManagerAction.Edit:
                        buttonEdit_Click(this, new EventArgs());
                        break;
                    case NamespaceManagerAction.Remove:
                        buttonRemove_Click(this, new EventArgs());
                        break;
                }
            }
        }

        private void Elevate(NamespaceManagerAction action, string url)
        {
            if (!Util.IsUserAnAdmin())
            {
                ProcessStartInfo procInfo = new ProcessStartInfo(Application.ExecutablePath, String.Format("-{0} {1}", action.ToString(), url));
                procInfo.UseShellExecute = true;
                procInfo.Verb = "runas";
                procInfo.WindowStyle = ProcessWindowStyle.Normal;

                Process.Start(procInfo);

                Application.Exit();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)listHttpNamespaces.SelectedItem))
            {
                Elevate(NamespaceManagerAction.Add, (string)listHttpNamespaces.SelectedItem);

                string url;

                InputBox.Show("Enter URL", "Enter the URL to add:", out url);

                if (!String.IsNullOrEmpty(url))
                {
                    SecurityDescriptor newSd = new SecurityDescriptor();
                    newSd.DACL = new AccessControlList();

                    AccessControlListDialog aclDlg = new AccessControlListDialog(url,
                        newSd.DACL,
                        new List<AceRights>(new AceRights[] { AceRights.GenericAll, AceRights.GenericExecute, AceRights.GenericRead, AceRights.GenericWrite }),
                        new List<AceType>(new AceType[] { AceType.AccessAllowed }));

                    if (aclDlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.nsManager.SetHttpNamespaceAcl(url, newSd);
                            this.nsTable.Add(url, newSd);
                            this.listHttpNamespaces.Items.Add(url);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Adding ACL. " + ex.Message, "Error Adding ACL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)listHttpNamespaces.SelectedItem))
            {
                Elevate(NamespaceManagerAction.Edit, (string)listHttpNamespaces.SelectedItem);

                AccessControlList original = this.nsTable[(string)listHttpNamespaces.SelectedItem].DACL;

                AccessControlListDialog aclDialog = new AccessControlListDialog((string)listHttpNamespaces.SelectedItem,
                    original != null ? new AccessControlList(original) : new AccessControlList(),
                    new List<AceRights>(new AceRights[] { AceRights.GenericAll, AceRights.GenericExecute, AceRights.GenericRead, AceRights.GenericWrite }),
                    new List<AceType>(new AceType[] { AceType.AccessAllowed }));
                if (aclDialog.ShowDialog() == DialogResult.OK)
                {
                    bool removed = false;
                    try
                    {
                        this.nsManager.RemoveHttpHamespaceAcl((string)listHttpNamespaces.SelectedItem);
                        removed = true;
                        this.nsTable[(string)listHttpNamespaces.SelectedItem].DACL = aclDialog.ACL;
                        this.nsManager.SetHttpNamespaceAcl((string)listHttpNamespaces.SelectedItem, this.nsTable[(string)listHttpNamespaces.SelectedItem]);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Setting ACL. " + ex.Message, "Error Setting ACL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (removed)
                        {
                            try
                            {
                                this.nsTable[(string)listHttpNamespaces.SelectedItem].DACL = original;
                                this.nsManager.SetHttpNamespaceAcl((string)listHttpNamespaces.SelectedItem, this.nsTable[(string)listHttpNamespaces.SelectedItem]);
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show("Unable to Restore Original ACL, ACL may be corrupt. " + ex2.Message, "Error Retoring ACL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)listHttpNamespaces.SelectedItem))
            {
                Elevate(NamespaceManagerAction.Remove, (string)listHttpNamespaces.SelectedItem);

                try
                {
                    this.nsManager.RemoveHttpHamespaceAcl((string)listHttpNamespaces.SelectedItem);
                    this.nsTable.Remove((string)listHttpNamespaces.SelectedItem);
                    this.listHttpNamespaces.Items.Remove((string)listHttpNamespaces.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Removing ACL. " + ex.Message, "Error Removing ACL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.nsManager != null) this.nsManager.Dispose();
        }
    }

    public enum NamespaceManagerAction
    {
        None,
        Add,
        Edit,
        Remove
    }
}