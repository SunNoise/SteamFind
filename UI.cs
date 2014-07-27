using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SteamFind
{
    class UI
    {
        private static SteamFind form;
        internal static Label lblS;
        internal static Label lblCS;
        internal static Label lblC;
        internal static Label lblB;
        internal static RadioButton rbtnBest;
        internal static RadioButton rbtnGood;
        internal static RadioButton rbtnFast;
        internal static Button btnStart;
        internal static Button btnClear;
        internal static TextBox txtStartingSeed;
        internal static GroupBox gBSaveLoad;
        internal static GroupBox gBSearch;
        internal static GroupBox gBSearchOptions;

        public UI(SteamFind mainForm)
        {
            form = mainForm;
            lblS = form.lblS;
            lblCS = form.lblCS;
            lblC = form.lblC;
            lblB = form.lblB;
            rbtnBest = form.rbtnBest;
            rbtnGood = form.rbtnGood;
            rbtnFast = form.rbtnFast;
            btnStart = form.btnStart;
            btnClear = form.btnClear;
            txtStartingSeed = form.txtStartingSeed;
            gBSaveLoad = form.gBSaveLoad;
            gBSearch = form.gBSearch;
            gBSearchOptions = form.gBSearchOptions;
        }

        internal static void InvokeText(Control formObject, string text)
        {
            if (form.InvokeRequired)
                formObject.Invoke((Action)(() => formObject.Text = text));
            else
                formObject.Text = text;
        }

        internal static void InvokeEnable(Control formObject, bool status)
        {
            if (form.InvokeRequired)
                formObject.Invoke((Action)(() => formObject.Enabled = status));
            else
                formObject.Enabled = status;
        }

        internal static void Alert(string text)
        {
            DialogResult dg;
            using (DialogCenteringService centeringService = new DialogCenteringService(form))
            {
                if (form.InvokeRequired)
                    form.Invoke(new Action<string>(Alert), text);
                else
                    dg = MessageBox.Show(form, text);
            }
        }

        internal static void UpdateBindingSource(Data newData)
        {
            if (form.InvokeRequired)
                form.Invoke(new Action<Data>(UpdateBindingSource), newData);
            else
                form.dataBindingSource.Add(newData);
        }

        internal static void AutoScrolling(int index)
        {
            if (form.chkAutoScroll.Checked)
                if (form.InvokeRequired)
                    form.dGVResults.Invoke((Action)(() => form.dGVResults.FirstDisplayedScrollingRowIndex = index));
                else
                    form.dGVResults.FirstDisplayedScrollingRowIndex = index;
        }
    }
}
