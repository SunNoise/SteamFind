using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using HtmlAgilityPack;
using Fizzler.Systems.HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace SteamFind
{
    class Algorithm
    {
        //needs optimization (downloader thread)
        internal List<string> result = new List<string>(), totalSeeds = new List<string>(), seeds = new List<string>();
        internal string currentSeed;
        internal string targetCountry, targetGame;
        internal bool activeOnly;

        private List<string> pastSeeds = new List<string>();

        internal void UseStartSearch(string seed)
        {
            StartSearch(seed);
        }

        private void StartSearch(string seed)
        {
            try
            {
                List<string> possibleSeeds = null;

                if (seeds.Count == 0)
                {
                    seeds.Add(seed);
                    totalSeeds.Add(seed);
                    pastSeeds.Add(seed);
                }

                while (seeds.Count != 0)
                {
                    currentSeed = seeds.First();
                    UI.InvokeText(UI.lblCS, currentSeed);

                    //get friends of seed for more possible seeds
                    possibleSeeds = Search(String.Concat(currentSeed, "/friends"), ".friendBlockLinkOverlay");
                    //curate for profiles with friends
                    for (int friends = 0; friends < possibleSeeds.Count; friends++)
                    {
                        if (stop)
                            break;
                        string testFriend = possibleSeeds.ElementAt(friends);

                        if (Search(testFriend, ".friendBlockLinkOverlay").Count != 0)
                        {
                            if (UI.rbtnFast.Checked && totalSeeds.ElementAt(totalSeeds.Count - 1) == testFriend && totalSeeds.Count > seeds.Count)
                            {
                                AddSeed(testFriend);
                                continue;
                            }
                            else
                            {
                                if (!UI.rbtnFast.Checked)
                                    if (hasFlag)
                                    {
                                        if (!pastSeeds.Contains(testFriend))
                                        {
                                            AddSeed(testFriend);
                                            continue;
                                        }
                                    }
                                    else if (UI.rbtnBest.Checked)
                                    {
                                        if (hasFriends)
                                        {
                                            AddSeed(testFriend);
                                            continue;
                                        }
                                    }
                            }
                        }
                        possibleSeeds.RemoveAt(friends);
                        friends--;
                    }

                    if (stop)
                        break;
                    else
                        seeds.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                seeds.RemoveAt(0);
                totalSeeds.RemoveAt(0);
                UI.Alert(String.Concat("Could not download required files. " +
                                    "Make sure you are connected to the Internet, " +
                                    "or that the URL is written correctly.\n", ex.StackTrace));
            }

            try
            {
                Stop();
                UI.InvokeText(UI.btnStart, "Start");
                UI.Alert("Search Finished");
            }
            catch { }


            stop = false;
        }

        private void AddSeed(string testFriend)
        {
            pastSeeds.Add(testFriend);
            seeds.Add(testFriend);
            UI.InvokeText(UI.lblS, seeds.Count.ToString());
        }

        bool hasFlag, hasFriends;
        private List<string> Search(string seed, string selector = ".profile_flag")
        {
            List<string> link = new List<string>();
            var web = new HtmlWeb();
            var document = web.Load(seed);
            var page = document.DocumentNode;

            hasFriends = false;

            GetSize(page);
            GetChecks();

            hasFlag = GetInfo(seed, page);

            if (!UI.rbtnBest.Checked)
                if (targetCountry != "")
                    if (!hasFlag)
                        return link;

            foreach (var item in page.QuerySelectorAll(selector))
            {
                link.Add(item.Attributes.AttributesWithName("href").First().Value);
                hasFriends = true;
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
                }
            }
            else
                return true;

            foreach (var item in page.QuerySelectorAll(".profile_flag"))
            {
                string testCountry = item.Attributes.AttributesWithName("src").First().Value;
                if (!Check(seed, testCountry.Substring(testCountry.Length - 6, 2), IsActive(page), gameList, name))
                    if (!UI.rbtnGood.Checked)
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
                    MatchCollection gameCollection = Regex.Matches(item.OuterHtml, "id\":([0-9]+),");//change to collection
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
            if (targetCountry == countryOfSeed && (gamesOfSeed == null || gamesOfSeed.Contains(targetGame)) && !totalSeeds.Contains(currentSeed))
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

            UI.UpdateBindingSource(new Data(result.Count, name, result.ElementAt(numberOfResults)));
            UI.AutoScrolling(numberOfResults);

            return true;
        }

        internal void UseStop()
        {
            Stop();
        }

        private bool stop = false;
        private void Stop()
        {
            UI.InvokeEnable(UI.btnStart, false);
            UI.InvokeText(UI.btnStart, "Resume");
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
                UI.InvokeText(UI.txtStartingSeed, currentSeed);
                UI.InvokeText(UI.lblCS, "");
                UI.InvokeEnable(UI.btnStart, true);
                UI.InvokeEnable(UI.btnClear, true);
                UI.InvokeEnable(UI.gBSaveLoad, true);
                UI.InvokeEnable(UI.gBSearch, true);
                UI.InvokeEnable(UI.gBSearchOptions, true);
            }
            catch { }
        }

        private double bandwidth = 0;
        private void GetSize(HtmlNode page)
        {
            double bw = System.Text.ASCIIEncoding.Unicode.GetByteCount(page.OuterHtml);
            bw = (bw / (1024 * 1024));
            bandwidth += bw;

            UI.InvokeText(UI.lblB, String.Concat(bandwidth.ToString("N1"), "MB"));
        }

        private int checks = 0;
        private void GetChecks()
        {
            checks++;
            UI.InvokeText(UI.lblC, checks.ToString());
        }
    }
}
