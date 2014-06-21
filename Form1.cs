using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Xml;

namespace SteamFind
{
    public partial class SteamFind : Form
    {
        private List<string> result = new List<string>(), totalSeeds = new List<string>(), seeds = new List<string>(); //savefile
        
        public SteamFind()
        {
            InitializeComponent();
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
                Alert("Error loading the init file" + ex.StackTrace);
            }

            if (chkAutoLoad.Checked)
                LoadUp();
        }

        private string currentSeed; //savefile
        private void StartSearch(string seed)
        {
            try
            {
                List<string> possibleSeeds = null;

                if (!totalSeeds.Contains(seed))
                {
                    seeds.Add(seed);
                    totalSeeds.Add(seed);
                }

                while (seeds.Count != 0)
                {
                    currentSeed = seeds.First();
                    lblCS.Invoke((Action)(() => lblCS.Text = currentSeed));

                    //get friends of seed for more possible seeds
                    possibleSeeds = Search(String.Concat(currentSeed, "/friends"), ".friendBlockLinkOverlay");
                    //curate for profiles with friends
                    for (int friends = 0; friends < possibleSeeds.Count; friends++)
                    {
                        string testFriend = possibleSeeds.ElementAt(friends);

                        if (Search(testFriend, ".friendBlockLinkOverlay").Count == 0)
                        {
                            possibleSeeds.RemoveAt(friends);
                            friends--;
                        }
                        else //add the good ones to the seeds
                        {
                            seeds.Add(testFriend);
                            lblS.Invoke((Action)(() => lblS.Text = seeds.Count.ToString()));
                        }
                        if (stop)
                            break;
                    }

                    if (stop)
                        break;
                    else
                        seeds.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    Alert(ex.StackTrace);
                    seeds.RemoveAt(0);
                    totalSeeds.RemoveAt(0);
                    Stop();
                    if (InvokeRequired)
                        btnStart.Invoke((Action)(() => btnStart.Text = "Start"));
                }
                catch { }
            }
            stop = false;
        }

        private List<string> Search(string seed, string selector = ".profile_flag")
        {
            List<string> link = new List<string>();
            bool hasFlag;
            var web = new HtmlWeb();
            var document = web.Load(seed);
            var page = document.DocumentNode;

            GetSize(page);
            GetChecks();

            hasFlag = GetInfo(seed, page);

            if (!rbtnBest.Checked)
                if (!hasFlag)
                    return link;

            foreach (var item in page.QuerySelectorAll(selector))
            {
                link.Add(item.Attributes.AttributesWithName("href").First().Value);
            }

            return link;
        }

        private bool GetInfo(string seed, HtmlNode page)
        {
            //create game list for testFriend
            List<string> gameList = GetGames(seed);

            string name = GetName(page);

            if (seed.Substring(seed.Length - 7, 7) != "friends")
            {
                if (targetCountry == "")
                {
                    Check(seed, targetCountry, IsActive(page), gameList, name);
                    return true;
                }
            }
            else
                return true;

            foreach (var item in page.QuerySelectorAll(".profile_flag"))
            {
                string testCountry = item.Attributes.AttributesWithName("src").First().Value;
                if (!Check(seed, testCountry.Substring(testCountry.Length - 6, 2), IsActive(page), gameList, name))
                    if (!rbtnGood.Checked)
                        return false;
                return true;
            }
            return false;
        }

        private List<string> GetGames(string seed)
        {
            if (targetGame == "" || seed.Substring(seed.Length - 7, 7) == "friends")
                return null;

            var web = new HtmlWeb();
            var document = web.Load(String.Concat(seed, "/games?tab=all"));
            var page = document.DocumentNode;

            GetSize(page);

            List<string> gameList = new List<string>();
            foreach (var item in page.QuerySelectorAll("script"))
            {
                if (item.OuterHtml.Substring(37, 7) == "rgGames")
                {
                    MatchCollection gameCollection = Regex.Matches(item.OuterHtml,"id\":([0-9]+),");//change to collection
                    foreach (Match game in gameCollection)
                    {
                        string key = game.Groups[1].Value;
                        gameList.Add(key);
                    }
                }
            }

            return gameList;
        }

        private string GetName(HtmlNode page)
        {
            string name = "";
            foreach (var item in page.QuerySelectorAll(".persona_name"))
            {
                name = Regex.Match(item.InnerText, "\t(?!\t)(.*)(?<!\t)\t").Groups[1].Value;
            }
            return name;
        }

        private bool IsActive(HtmlNode page)
        {
            foreach (var item in page.QuerySelectorAll(".recentgame_quicklinks"))
            {
                string activity = item.InnerText.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                if (!activity.Substring(0, 4).Equals("View"))
                    return true;
                break;
            }
            return false;
        }

        private bool Check(string currentSeed, string countryOfSeed, bool activeSeed = false, List<string> gamesOfSeed = null, string name = null)
        {
            if (targetCountry == countryOfSeed && (gamesOfSeed == null || gamesOfSeed.Contains(targetGame) ) && !totalSeeds.Contains(currentSeed))
            {
                if (activeOnly)
                {
                    if (activeSeed)
                    {
                        return Update(currentSeed, name);
                    }
                }
                else
                {
                    return Update(currentSeed, name);
                }
            }
            return false;
        }

        private bool Update(string currentSeed, string name)
        {
            result.Add(currentSeed);
            totalSeeds.Add(currentSeed);

            int numberOfResults = result.Count - 1;

            UpdateBindingSource(new Data(result.Count, name, result.ElementAt(numberOfResults)));
            if (chkAutoScroll.Checked)
                dGVResults.Invoke((Action)(() => dGVResults.FirstDisplayedScrollingRowIndex = numberOfResults));

            return true;
        }

        private void UpdateBindingSource(Data newData)
        {
            if (InvokeRequired)
                Invoke(new Action<Data>(UpdateBindingSource), newData);
            else
                this.dataBindingSource.Add(newData);
        }

        private double bandwidth = 0;
        private void GetSize(HtmlNode page)
        {
            double bw = System.Text.ASCIIEncoding.Unicode.GetByteCount(page.OuterHtml);
            bw = (bw / (1024 * 1024));
            bandwidth += bw;

            lblB.Invoke((Action)(() => lblB.Text = String.Concat(bandwidth.ToString("N1"), "MB")));
        }

        private int checks = 0;
        private void GetChecks()
        {
            checks++;
            lblC.Invoke((Action)(() => lblC.Text = checks.ToString()));
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
                Stop();
        }

        private bool stop = false;
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
                Alert(ex.Message + ex.StackTrace);
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

        private void Stop()
        {
            if (InvokeRequired)
            {
                btnStart.Invoke((Action)(() => btnStart.Enabled = false));
                btnStart.Invoke((Action)(() => btnStart.Text = "Resume"));
            }
            else
            {
                btnStart.Enabled = false;
                btnStart.Text = "Resume";
            }
            stop = true;

            Thread thread = new Thread(() => WaitForStop());
            thread.Start();
        }

        private void WaitForStop()
        {
            while (stop)
            {
                Thread.Sleep(50);
            }

            try
            {
                txtStartingSeed.Invoke((Action)(() => txtStartingSeed.Text = currentSeed));
                lblCS.Invoke((Action)(() => lblCS.Text = ""));
                btnStart.Invoke((Action)(() => btnStart.Enabled = true));
                btnClear.Invoke((Action)(() => btnClear.Enabled = true));
                gBSaveLoad.Invoke((Action)(() => gBSaveLoad.Enabled = true));
                gBSearch.Invoke((Action)(() => gBSearch.Enabled = true));
                gBSearchOptions.Invoke((Action)(() => gBSearchOptions.Enabled = true));
            }
            catch { }
        }

        private string targetCountry, targetGame; //savefile
        private bool activeOnly; //savefile
        private void Initialize()
        {
            string seed = txtStartingSeed.Text;
            targetCountry = txtCountry.Text;
            targetGame = txtApp.Text;
            activeOnly = chkActive.Checked;

            Thread thread = new Thread(() => StartSearch(seed));
            thread.Start();
        }

        private const string DATA_FILENAME = "SteamFind.dat";
        private bool Save()
        {
            //save object to files (make new object with all objects inside)
            BindingList<Data> dataList = (BindingList<Data>)dataBindingSource.List;
            SaveFile saveFile = new SaveFile(dataList, result, seeds, totalSeeds, currentSeed, targetCountry, targetGame, activeOnly);

            try
            {
                BinarySerialization.WriteToBinaryFile<SaveFile>(DATA_FILENAME, saveFile);
                return true;
            }
            catch (Exception ex)
            {
                Alert("Could not write to data file" + ex.StackTrace);
            }
            return false;
        }

        private bool LoadUp()
        {
            //put the objects in the txtboxes and lists
            try
            {
                SaveFile saveFile = BinarySerialization.ReadFromBinaryFile<SaveFile>(DATA_FILENAME);

                this.result = saveFile.Result;
                this.seeds = saveFile.Seeds;
                this.totalSeeds = saveFile.TotalSeeds;
                this.currentSeed = saveFile.CurrentSeed;
                this.targetCountry = saveFile.TargetCountry;
                this.targetGame = saveFile.TargetGame;
                this.activeOnly = saveFile.ActiveOnly;

                txtStartingSeed.Text = currentSeed;
                txtCountry.Text = targetCountry;
                txtApp.Text = targetGame;
                chkActive.Checked = activeOnly;
                btnStart.Text = "Resume";

                BindingList<Data> dataList = saveFile.DataList;
                dataBindingSource.DataSource = dataList;
                return true;
            }
            catch (Exception ex)
            {
                Alert("Error loading the data file" + ex.StackTrace);
            }
            return false;
        }

        private void SteamFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            //stop and save before closing
            if(!txtStartingSeed.Enabled)
                Stop();
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
                Alert("Could not write to init file" + ex.StackTrace);
            }

            if (chkAutoSave.Checked)
                Save();
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
                Alert("Saved Successfully");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (LoadUp())
                Alert("Loaded Successfully");
        }

        private void Alert(string text)
        {
            DialogResult dg;
            using (DialogCenteringService centeringService = new DialogCenteringService(this))
            {
                if (InvokeRequired)
                    Invoke(new Action<string>(Alert), text);
                else
                    dg = MessageBox.Show(this, text);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            SaveFile clear = new SaveFile(new BindingList<Data>(), new List<string>(), new List<string>(), new List<string>(), "", "", "", false);

            this.result = clear.Result;
            this.seeds = clear.Seeds;
            this.totalSeeds = clear.TotalSeeds;
            this.currentSeed = clear.CurrentSeed;
            this.targetCountry = clear.TargetCountry;
            this.targetGame = clear.TargetGame;
            this.activeOnly = clear.ActiveOnly;

            txtStartingSeed.Text = currentSeed;
            txtCountry.Text = targetCountry;
            txtApp.Text = targetGame;
            chkActive.Checked = activeOnly;
            btnStart.Text = "Start";

            BindingList<Data> dataList = clear.DataList;
            dataBindingSource.DataSource = dataList;
        }
    }
}
