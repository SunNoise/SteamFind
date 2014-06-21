using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SteamFind
{
    [Serializable]
    internal class SaveFile
    {
        private BindingList<Data> dataList;
        private List<string> result, seeds, totalSeeds;
        private string currentSeed, targetCountry, targetGame;
        private bool activeOnly;

        internal SaveFile(BindingList<Data> dataList, List<string> result, List<string> seeds, List<string> totalSeeds, string currentSeed, string targetCountry, string targetGame, bool activeOnly)
        {
            this.dataList = dataList;
            this.result = result;
            this.seeds = seeds;
            this.totalSeeds = totalSeeds;
            this.currentSeed = currentSeed;
            this.targetCountry = targetCountry;
            this.targetGame = targetGame;
            this.activeOnly = activeOnly;
        }

        public BindingList<Data> DataList
        {
            get
            {
                return this.dataList;
            }
            set
            {
                this.dataList = value;
            }
        }

        public List<string> Result
        {
            get
            {
                return this.result;
            }
            set
            {
                this.result = value;
            }
        }

        public List<string> Seeds
        {
            get
            {
                return this.seeds;
            }
            set
            {
                this.seeds = value;
            }
        }

        public List<string> TotalSeeds
        {
            get
            {
                return this.totalSeeds;
            }
            set
            {
                this.totalSeeds = value;
            }
        }

        public string CurrentSeed
        {
            get
            {
                return this.currentSeed;
            }
            set
            {
                this.currentSeed = value;
            }
        }

        public string TargetCountry
        {
            get
            {
                return this.targetCountry;
            }
            set
            {
                this.targetCountry = value;
            }
        }

        public string TargetGame
        {
            get
            {
                return this.targetGame;
            }
            set
            {
                this.targetGame = value;
            }
        }

        public bool ActiveOnly
        {
            get
            {
                return this.activeOnly;
            }
            set
            {
                this.activeOnly = value;
            }
        }
    }
}
