namespace SteamFind
{
    partial class SteamFind
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
            this.components = new System.ComponentModel.Container();
            this.dGVResults = new System.Windows.Forms.DataGridView();
            this.columnNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLinkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCurrentSeed = new System.Windows.Forms.Label();
            this.lblSeeds = new System.Windows.Forms.Label();
            this.lblCS = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.lblChecks = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblBandwidth = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtStartingSeed = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountryCode = new System.Windows.Forms.LinkLabel();
            this.lblApp = new System.Windows.Forms.LinkLabel();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.gBSearch = new System.Windows.Forms.GroupBox();
            this.rbtnBest = new System.Windows.Forms.RadioButton();
            this.rbtnGood = new System.Windows.Forms.RadioButton();
            this.rbtnFast = new System.Windows.Forms.RadioButton();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            this.gBSearchOptions = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.gBSaveLoad = new System.Windows.Forms.GroupBox();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.chkAutoLoad = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).BeginInit();
            this.gBSearch.SuspendLayout();
            this.gBSearchOptions.SuspendLayout();
            this.gBSaveLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGVResults
            // 
            this.dGVResults.AllowUserToAddRows = false;
            this.dGVResults.AllowUserToDeleteRows = false;
            this.dGVResults.AllowUserToResizeColumns = false;
            this.dGVResults.AllowUserToResizeRows = false;
            this.dGVResults.AutoGenerateColumns = false;
            this.dGVResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnNumberDataGridViewTextBoxColumn,
            this.columnNameDataGridViewTextBoxColumn,
            this.columnLinkDataGridViewTextBoxColumn});
            this.dGVResults.DataSource = this.dataBindingSource;
            this.dGVResults.Location = new System.Drawing.Point(12, 104);
            this.dGVResults.Name = "dGVResults";
            this.dGVResults.ReadOnly = true;
            this.dGVResults.RowHeadersVisible = false;
            this.dGVResults.Size = new System.Drawing.Size(488, 240);
            this.dGVResults.TabIndex = 0;
            this.dGVResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResults_CellContentClick);
            // 
            // columnNumberDataGridViewTextBoxColumn
            // 
            this.columnNumberDataGridViewTextBoxColumn.DataPropertyName = "ColumnNumber";
            this.columnNumberDataGridViewTextBoxColumn.HeaderText = "#";
            this.columnNumberDataGridViewTextBoxColumn.Name = "columnNumberDataGridViewTextBoxColumn";
            this.columnNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.columnNumberDataGridViewTextBoxColumn.Width = 50;
            // 
            // columnNameDataGridViewTextBoxColumn
            // 
            this.columnNameDataGridViewTextBoxColumn.DataPropertyName = "ColumnName";
            this.columnNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.columnNameDataGridViewTextBoxColumn.Name = "columnNameDataGridViewTextBoxColumn";
            this.columnNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnLinkDataGridViewTextBoxColumn
            // 
            this.columnLinkDataGridViewTextBoxColumn.DataPropertyName = "ColumnLink";
            this.columnLinkDataGridViewTextBoxColumn.HeaderText = "Link";
            this.columnLinkDataGridViewTextBoxColumn.Name = "columnLinkDataGridViewTextBoxColumn";
            this.columnLinkDataGridViewTextBoxColumn.ReadOnly = true;
            this.columnLinkDataGridViewTextBoxColumn.Width = 318;
            // 
            // dataBindingSource
            // 
            this.dataBindingSource.DataSource = typeof(Data);
            // 
            // lblCurrentSeed
            // 
            this.lblCurrentSeed.AutoSize = true;
            this.lblCurrentSeed.Location = new System.Drawing.Point(12, 347);
            this.lblCurrentSeed.Name = "lblCurrentSeed";
            this.lblCurrentSeed.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentSeed.TabIndex = 1;
            this.lblCurrentSeed.Text = "Current Seed:";
            // 
            // lblSeeds
            // 
            this.lblSeeds.AutoSize = true;
            this.lblSeeds.Location = new System.Drawing.Point(12, 360);
            this.lblSeeds.Name = "lblSeeds";
            this.lblSeeds.Size = new System.Drawing.Size(40, 13);
            this.lblSeeds.TabIndex = 2;
            this.lblSeeds.Text = "Seeds:";
            // 
            // lblCS
            // 
            this.lblCS.AutoSize = true;
            this.lblCS.Location = new System.Drawing.Point(90, 347);
            this.lblCS.Name = "lblCS";
            this.lblCS.Size = new System.Drawing.Size(0, 13);
            this.lblCS.TabIndex = 3;
            // 
            // lblS
            // 
            this.lblS.AutoSize = true;
            this.lblS.Location = new System.Drawing.Point(52, 360);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(0, 13);
            this.lblS.TabIndex = 4;
            // 
            // lblChecks
            // 
            this.lblChecks.AutoSize = true;
            this.lblChecks.Location = new System.Drawing.Point(135, 360);
            this.lblChecks.Name = "lblChecks";
            this.lblChecks.Size = new System.Drawing.Size(46, 13);
            this.lblChecks.TabIndex = 5;
            this.lblChecks.Text = "Checks:";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(181, 360);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(0, 13);
            this.lblC.TabIndex = 6;
            // 
            // lblBandwidth
            // 
            this.lblBandwidth.AutoSize = true;
            this.lblBandwidth.Location = new System.Drawing.Point(282, 360);
            this.lblBandwidth.Name = "lblBandwidth";
            this.lblBandwidth.Size = new System.Drawing.Size(60, 13);
            this.lblBandwidth.TabIndex = 7;
            this.lblBandwidth.Text = "Bandwidth:";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(342, 360);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(0, 13);
            this.lblB.TabIndex = 8;
            // 
            // txtStartingSeed
            // 
            this.txtStartingSeed.Location = new System.Drawing.Point(6, 12);
            this.txtStartingSeed.Name = "txtStartingSeed";
            this.txtStartingSeed.Size = new System.Drawing.Size(292, 20);
            this.txtStartingSeed.TabIndex = 9;
            this.txtStartingSeed.Text = "Starting Seed (Community Link)";
            this.txtStartingSeed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtStartingSeed_MouseClick);
            this.txtStartingSeed.Leave += new System.EventHandler(this.txtStartingSeed_Leave);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(323, 10);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(78, 38);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(24, 20);
            this.txtCountry.TabIndex = 11;
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.Location = new System.Drawing.Point(6, 41);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(71, 13);
            this.lblCountryCode.TabIndex = 13;
            this.lblCountryCode.TabStop = true;
            this.lblCountryCode.Text = "Country Code";
            this.lblCountryCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCountryCode_LinkClicked);
            // 
            // lblApp
            // 
            this.lblApp.AutoSize = true;
            this.lblApp.Location = new System.Drawing.Point(104, 41);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(40, 13);
            this.lblApp.TabIndex = 15;
            this.lblApp.TabStop = true;
            this.lblApp.Text = "App ID";
            this.lblApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblApp_LinkClicked);
            // 
            // txtApp
            // 
            this.txtApp.Location = new System.Drawing.Point(145, 38);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(62, 20);
            this.txtApp.TabIndex = 14;
            // 
            // gBSearch
            // 
            this.gBSearch.Controls.Add(this.rbtnBest);
            this.gBSearch.Controls.Add(this.rbtnGood);
            this.gBSearch.Controls.Add(this.rbtnFast);
            this.gBSearch.Location = new System.Drawing.Point(323, 32);
            this.gBSearch.Name = "gBSearch";
            this.gBSearch.Size = new System.Drawing.Size(100, 66);
            this.gBSearch.TabIndex = 16;
            this.gBSearch.TabStop = false;
            // 
            // rbtnBest
            // 
            this.rbtnBest.AutoSize = true;
            this.rbtnBest.Location = new System.Drawing.Point(6, 45);
            this.rbtnBest.Name = "rbtnBest";
            this.rbtnBest.Size = new System.Drawing.Size(83, 17);
            this.rbtnBest.TabIndex = 2;
            this.rbtnBest.Text = "Best Search";
            this.rbtnBest.UseVisualStyleBackColor = true;
            // 
            // rbtnGood
            // 
            this.rbtnGood.AutoSize = true;
            this.rbtnGood.Location = new System.Drawing.Point(6, 27);
            this.rbtnGood.Name = "rbtnGood";
            this.rbtnGood.Size = new System.Drawing.Size(88, 17);
            this.rbtnGood.TabIndex = 1;
            this.rbtnGood.Text = "Good Search";
            this.rbtnGood.UseVisualStyleBackColor = true;
            // 
            // rbtnFast
            // 
            this.rbtnFast.AutoSize = true;
            this.rbtnFast.Checked = true;
            this.rbtnFast.Location = new System.Drawing.Point(6, 8);
            this.rbtnFast.Name = "rbtnFast";
            this.rbtnFast.Size = new System.Drawing.Size(82, 17);
            this.rbtnFast.TabIndex = 0;
            this.rbtnFast.TabStop = true;
            this.rbtnFast.Text = "Fast Search";
            this.rbtnFast.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(213, 40);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(77, 17);
            this.chkActive.TabIndex = 17;
            this.chkActive.Text = "ActiveOnly";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(15, 75);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(74, 17);
            this.chkAutoScroll.TabIndex = 18;
            this.chkAutoScroll.Text = "AutoScroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // gBSearchOptions
            // 
            this.gBSearchOptions.Controls.Add(this.txtStartingSeed);
            this.gBSearchOptions.Controls.Add(this.txtCountry);
            this.gBSearchOptions.Controls.Add(this.chkActive);
            this.gBSearchOptions.Controls.Add(this.lblCountryCode);
            this.gBSearchOptions.Controls.Add(this.txtApp);
            this.gBSearchOptions.Controls.Add(this.lblApp);
            this.gBSearchOptions.Location = new System.Drawing.Point(12, 4);
            this.gBSearchOptions.Name = "gBSearchOptions";
            this.gBSearchOptions.Size = new System.Drawing.Size(305, 65);
            this.gBSearchOptions.TabIndex = 11;
            this.gBSearchOptions.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 36);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(6, 52);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(59, 36);
            this.btnLoad.TabIndex = 20;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // gBSaveLoad
            // 
            this.gBSaveLoad.Controls.Add(this.btnSave);
            this.gBSaveLoad.Controls.Add(this.btnLoad);
            this.gBSaveLoad.Location = new System.Drawing.Point(429, 4);
            this.gBSaveLoad.Name = "gBSaveLoad";
            this.gBSaveLoad.Size = new System.Drawing.Size(71, 94);
            this.gBSaveLoad.TabIndex = 18;
            this.gBSaveLoad.TabStop = false;
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(95, 75);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(73, 17);
            this.chkAutoSave.TabIndex = 19;
            this.chkAutoSave.Text = "AutoSave";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // chkAutoLoad
            // 
            this.chkAutoLoad.AutoSize = true;
            this.chkAutoLoad.Location = new System.Drawing.Point(174, 75);
            this.chkAutoLoad.Name = "chkAutoLoad";
            this.chkAutoLoad.Size = new System.Drawing.Size(72, 17);
            this.chkAutoLoad.TabIndex = 20;
            this.chkAutoLoad.Text = "AutoLoad";
            this.chkAutoLoad.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 71);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(65, 27);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SteamFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 375);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkAutoLoad);
            this.Controls.Add(this.chkAutoSave);
            this.Controls.Add(this.gBSaveLoad);
            this.Controls.Add(this.gBSearchOptions);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.gBSearch);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblBandwidth);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.lblChecks);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.lblCS);
            this.Controls.Add(this.lblSeeds);
            this.Controls.Add(this.lblCurrentSeed);
            this.Controls.Add(this.dGVResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SteamFind";
            this.Text = "SteamFind";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SteamFind_FormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dGVResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).EndInit();
            this.gBSearch.ResumeLayout(false);
            this.gBSearch.PerformLayout();
            this.gBSearchOptions.ResumeLayout(false);
            this.gBSearchOptions.PerformLayout();
            this.gBSaveLoad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dGVResults;
        private System.Windows.Forms.Label lblCurrentSeed;
        private System.Windows.Forms.Label lblSeeds;
        internal System.Windows.Forms.Label lblCS;
        internal System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblChecks;
        internal System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblBandwidth;
        internal System.Windows.Forms.Label lblB;
        internal System.Windows.Forms.TextBox txtStartingSeed;
        internal System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.LinkLabel lblCountryCode;
        private System.Windows.Forms.LinkLabel lblApp;
        private System.Windows.Forms.TextBox txtApp;
        internal System.Windows.Forms.GroupBox gBSearch;
        internal System.Windows.Forms.RadioButton rbtnBest;
        internal System.Windows.Forms.RadioButton rbtnGood;
        internal System.Windows.Forms.RadioButton rbtnFast;
        internal System.Windows.Forms.CheckBox chkActive;
        internal System.Windows.Forms.CheckBox chkAutoScroll;
        internal System.Windows.Forms.GroupBox gBSearchOptions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        internal System.Windows.Forms.BindingSource dataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLinkDataGridViewTextBoxColumn;
        internal System.Windows.Forms.GroupBox gBSaveLoad;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.CheckBox chkAutoLoad;
        internal System.Windows.Forms.Button btnClear;
    }
}

