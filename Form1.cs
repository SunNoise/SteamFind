using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace SteamFind
{
    public partial class SteamFind : Form
    {
        private static Algorithm algo = new Algorithm();
        private static UI ui;

        public SteamFind()
        {
            InitializeComponent();
            ui = new UI(this);
        }

        private void Start()
        {
            if (txtStartingSeed.Text.Length > 0)
                if (txtStartingSeed.Text.Substring(txtStartingSeed.Text.Length - 1, 1) == "/")
                    txtStartingSeed.Text = txtStartingSeed.Text.Substring(0, txtStartingSeed.Text.Length - 1);
            txtCountry.Text = txtCountry.Text.ToLower();

            try//curate txtCountry and txtApp
            {
                if (txtApp.Text.Length > 0)
                    int.Parse(txtApp.Text);
                if (txtCountry.Text.Length != 2 && txtCountry.Text.Length != 0)
                    throw new Exception("Wrong Country Code Format. Make sure you're using the 2 letter code");
            }
            catch (Exception ex)
            {
                UI.Alert(ex.Message + ex.StackTrace);
                return;
            }

            btnStart.Text = "Stop";
            btnStart.Enabled = false;
            btnClear.Enabled = false;
            gBSaveLoad.Enabled = false;
            gBSearch.Enabled = false;
            gBSearchOptions.Enabled = false;

            Initialize();
            btnStart.Enabled = true;
        }

        private void Initialize()
        {
            string seed = txtStartingSeed.Text;
            algo.targetCountry = txtCountry.Text;
            algo.targetGame = txtApp.Text;
            algo.activeOnly = chkActive.Checked;

            Thread thread = new Thread(() => algo.UseStartSearch(seed));
            thread.Start();
        }

        private const string INIT_FILENAME = "init.xml";
        private void OnLoad(object sender, EventArgs e)
        {
            //autoload read init.xml file
            try
            {
                InitFile init = XmlSerialization.ReadFromXmlFile<InitFile>(INIT_FILENAME);

                chkAutoScroll.Checked = init.AutoScroll;
                chkAutoSave.Checked = init.AutoSave;
                chkAutoLoad.Checked = init.AutoLoad;
            }
            catch (Exception ex)
            {
                UI.Alert("Error loading the init file" + ex.StackTrace);
            }

            if (chkAutoLoad.Checked)
                LoadUp();
        }

        private bool LoadUp()
        {
            //put the objects in the txtboxes and lists
            try
            {
                SaveFile saveFile = BinarySerialization.ReadFromBinaryFile<SaveFile>(DATA_FILENAME);

                algo.result = saveFile.Result;
                algo.seeds = saveFile.Seeds;
                algo.totalSeeds = saveFile.TotalSeeds;
                algo.currentSeed = saveFile.CurrentSeed;
                algo.targetCountry = saveFile.TargetCountry;
                algo.targetGame = saveFile.TargetGame;
                algo.activeOnly = saveFile.ActiveOnly;

                txtStartingSeed.Text = algo.currentSeed;
                txtCountry.Text = algo.targetCountry;
                txtApp.Text = algo.targetGame;
                chkActive.Checked = algo.activeOnly;
                btnStart.Text = "Resume";

                BindingList<Data> dataList = saveFile.DataList;
                dataBindingSource.DataSource = dataList;
                return true;
            }
            catch (Exception ex)
            {
                UI.Alert("Error loading the data file" + ex.StackTrace);
            }
            return false;
        }

        private const string DATA_FILENAME = "SteamFind.dat";
        private bool Save()
        {
            //save object to files (make new object with all objects inside)
            BindingList<Data> dataList = (BindingList<Data>)dataBindingSource.List;
            SaveFile saveFile = new SaveFile(dataList, algo.result, algo.seeds, algo.totalSeeds, algo.currentSeed, algo.targetCountry, algo.targetGame, algo.activeOnly);

            try
            {
                BinarySerialization.WriteToBinaryFile<SaveFile>(DATA_FILENAME, saveFile);
                return true;
            }
            catch (Exception ex)
            {
                UI.Alert("Could not write to data file" + ex.StackTrace);
            }
            return false;
        }

        private void SteamFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop and save before closing
            if(!txtStartingSeed.Enabled)
                algo.UseStop();
            InitFile initFile = new InitFile();
            initFile.AutoScroll = chkAutoScroll.Checked;
            initFile.AutoSave = chkAutoSave.Checked;
            initFile.AutoLoad = chkAutoLoad.Checked;

            try
            {
                XmlSerialization.WriteToXmlFile<InitFile>(INIT_FILENAME, initFile);
            }
            catch (Exception ex)
            {
                UI.Alert("Could not write to init file" + ex.StackTrace);
            }

            if (chkAutoSave.Checked)
                Save();
        }

        private void txtStartingSeed_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtStartingSeed.Text == "Starting Seed (Community Link)")
                txtStartingSeed.Text = "";
        }

        private void txtStartingSeed_Leave(object sender, EventArgs e)
        {
            if (txtStartingSeed.Text == "")
                txtStartingSeed.Text = "Starting Seed (Community Link)";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start" || btnStart.Text == "Resume")
                Start();
            else
                algo.UseStop();
        }

        private void lblCountryCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://countrycode.org/");
        }

        private void lblApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamdb.info/apps/");
        }

        private void dGVResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != 0)
            {
                string path = (string)dGVResults.Rows[e.RowIndex].Cells[2].Value;
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                UI.Alert("Saved Successfully");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (LoadUp())
                UI.Alert("Loaded Successfully");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SaveFile clear = new SaveFile(new BindingList<Data>(), new List<string>(), new List<string>(), new List<string>(), "", "", "", false);

            algo.result = clear.Result;
            algo.seeds = clear.Seeds;
            algo.totalSeeds = clear.TotalSeeds;
            algo.currentSeed = clear.CurrentSeed;
            algo.targetCountry = clear.TargetCountry;
            algo.targetGame = clear.TargetGame;
            algo.activeOnly = clear.ActiveOnly;

            txtStartingSeed.Text = algo.currentSeed;
            txtCountry.Text = algo.targetCountry;
            txtApp.Text = algo.targetGame;
            chkActive.Checked = algo.activeOnly;
            btnStart.Text = "Start";

            BindingList<Data> dataList = clear.DataList;
            dataBindingSource.DataSource = dataList;
        }
    }
}
