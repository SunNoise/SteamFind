using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamFind
{
    [Serializable]
    public class Data
    {
        private string columnName, columnLink;
        private int columnNumber;

        public Data(int columnNumber, string columnName, string columnLink)
        {
            this.columnNumber = columnNumber;
            this.columnName = columnName;
            this.columnLink = columnLink;
        }

        public int ColumnNumber
        {
            get
            {
                return this.columnNumber;
            }
            set
            {
                this.columnNumber = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                this.columnName = value;
            }
        }

        public string ColumnLink
        {
            get
            {
                return this.columnLink;
            }
            set
            {
                this.columnLink = value;
            }
        }
    }
}
