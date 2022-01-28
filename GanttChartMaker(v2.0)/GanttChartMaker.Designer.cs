namespace GanttChartMaker_v2._0
{
    partial class GanttChartMaker
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
            this.pnlProcesses = new System.Windows.Forms.Panel();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.pnlGanttChart = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.gpProcesses = new System.Windows.Forms.GroupBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.txtProcessCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpScheduling = new System.Windows.Forms.GroupBox();
            this.cbNoArrivalTime = new System.Windows.Forms.CheckBox();
            this.txtQuantum = new System.Windows.Forms.TextBox();
            this.lblQuantum = new System.Windows.Forms.Label();
            this.cbPriorityRank = new System.Windows.Forms.CheckBox();
            this.cbIsPreemptive = new System.Windows.Forms.CheckBox();
            this.cbAlgorithms = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlDrawResultSplit = new System.Windows.Forms.SplitContainer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSettings.SuspendLayout();
            this.gpProcesses.SuspendLayout();
            this.gpScheduling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawResultSplit)).BeginInit();
            this.pnlDrawResultSplit.Panel1.SuspendLayout();
            this.pnlDrawResultSplit.Panel2.SuspendLayout();
            this.pnlDrawResultSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProcesses
            // 
            this.pnlProcesses.AutoScroll = true;
            this.pnlProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcesses.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProcesses.Location = new System.Drawing.Point(0, 0);
            this.pnlProcesses.Name = "pnlProcesses";
            this.pnlProcesses.Size = new System.Drawing.Size(370, 481);
            this.pnlProcesses.TabIndex = 0;
            this.pnlProcesses.Validating += new System.ComponentModel.CancelEventHandler(this.pnlProcesses_Validating);
            // 
            // pnlResults
            // 
            this.pnlResults.AutoScroll = true;
            this.pnlResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResults.Location = new System.Drawing.Point(0, 0);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(884, 106);
            this.pnlResults.TabIndex = 0;
            // 
            // pnlGanttChart
            // 
            this.pnlGanttChart.AutoScroll = true;
            this.pnlGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttChart.Location = new System.Drawing.Point(0, 0);
            this.pnlGanttChart.Name = "pnlGanttChart";
            this.pnlGanttChart.Size = new System.Drawing.Size(884, 264);
            this.pnlGanttChart.TabIndex = 2;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.btnLoad);
            this.pnlSettings.Controls.Add(this.gpProcesses);
            this.pnlSettings.Controls.Add(this.gpScheduling);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSettings.Location = new System.Drawing.Point(370, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSettings.Size = new System.Drawing.Size(884, 107);
            this.pnlSettings.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(791, 15);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 80);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load File";
            this.toolTip.SetToolTip(this.btnLoad, "This will read a file in ther format of: priority, burst time, arrival time. The " +
        "process number will be assigned automatically and as read. ");
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // gpProcesses
            // 
            this.gpProcesses.Controls.Add(this.btnResize);
            this.gpProcesses.Controls.Add(this.btnReset);
            this.gpProcesses.Controls.Add(this.btnMake);
            this.gpProcesses.Controls.Add(this.txtProcessCount);
            this.gpProcesses.Controls.Add(this.label1);
            this.gpProcesses.Location = new System.Drawing.Point(10, 10);
            this.gpProcesses.Name = "gpProcesses";
            this.gpProcesses.Size = new System.Drawing.Size(258, 85);
            this.gpProcesses.TabIndex = 2;
            this.gpProcesses.TabStop = false;
            this.gpProcesses.Text = "Add/Remove Processes";
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(174, 20);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(77, 23);
            this.btnResize.TabIndex = 2;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            this.btnResize.MouseHover += new System.EventHandler(this.btnResize_MouseHover);
            // 
            // btnReset
            // 
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReset.Location = new System.Drawing.Point(174, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(77, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseHover += new System.EventHandler(this.btnReset_MouseHover);
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(9, 48);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(142, 23);
            this.btnMake.TabIndex = 4;
            this.btnMake.Text = "Make Chart";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            this.btnMake.MouseHover += new System.EventHandler(this.btnMake_MouseHover);
            // 
            // txtProcessCount
            // 
            this.txtProcessCount.Location = new System.Drawing.Point(86, 22);
            this.txtProcessCount.Name = "txtProcessCount";
            this.txtProcessCount.Size = new System.Drawing.Size(65, 20);
            this.txtProcessCount.TabIndex = 0;
            this.txtProcessCount.Validating += new System.ComponentModel.CancelEventHandler(this.txtProcessCount_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "# of Processes:";
            // 
            // gpScheduling
            // 
            this.gpScheduling.Controls.Add(this.cbNoArrivalTime);
            this.gpScheduling.Controls.Add(this.txtQuantum);
            this.gpScheduling.Controls.Add(this.lblQuantum);
            this.gpScheduling.Controls.Add(this.cbPriorityRank);
            this.gpScheduling.Controls.Add(this.cbIsPreemptive);
            this.gpScheduling.Controls.Add(this.cbAlgorithms);
            this.gpScheduling.Controls.Add(this.label2);
            this.gpScheduling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpScheduling.Location = new System.Drawing.Point(285, 10);
            this.gpScheduling.Name = "gpScheduling";
            this.gpScheduling.Size = new System.Drawing.Size(500, 85);
            this.gpScheduling.TabIndex = 1;
            this.gpScheduling.TabStop = false;
            this.gpScheduling.Text = "Scheduling Algorithm Settings";
            // 
            // cbNoArrivalTime
            // 
            this.cbNoArrivalTime.AutoSize = true;
            this.cbNoArrivalTime.Location = new System.Drawing.Point(4, 60);
            this.cbNoArrivalTime.Name = "cbNoArrivalTime";
            this.cbNoArrivalTime.Size = new System.Drawing.Size(98, 17);
            this.cbNoArrivalTime.TabIndex = 2;
            this.cbNoArrivalTime.Text = "No Arrival Time";
            this.cbNoArrivalTime.UseVisualStyleBackColor = true;
            this.cbNoArrivalTime.MouseHover += new System.EventHandler(this.cbArrivalTime_MouseHover);
            // 
            // txtQuantum
            // 
            this.txtQuantum.Location = new System.Drawing.Point(403, 58);
            this.txtQuantum.Name = "txtQuantum";
            this.txtQuantum.Size = new System.Drawing.Size(75, 20);
            this.txtQuantum.TabIndex = 5;
            this.txtQuantum.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuantum_Validating);
            // 
            // lblQuantum
            // 
            this.lblQuantum.AutoSize = true;
            this.lblQuantum.Location = new System.Drawing.Point(349, 61);
            this.lblQuantum.Name = "lblQuantum";
            this.lblQuantum.Size = new System.Drawing.Size(53, 13);
            this.lblQuantum.TabIndex = 4;
            this.lblQuantum.Text = "Quantum:";
            this.lblQuantum.MouseHover += new System.EventHandler(this.lblQuantum_MouseHover);
            // 
            // cbPriorityRank
            // 
            this.cbPriorityRank.AutoSize = true;
            this.cbPriorityRank.Location = new System.Drawing.Point(219, 60);
            this.cbPriorityRank.Name = "cbPriorityRank";
            this.cbPriorityRank.Size = new System.Drawing.Size(109, 17);
            this.cbPriorityRank.TabIndex = 3;
            this.cbPriorityRank.Text = "Increasing Priority";
            this.cbPriorityRank.UseVisualStyleBackColor = true;
            this.cbPriorityRank.MouseHover += new System.EventHandler(this.cbPriorityRank_MouseHover);
            // 
            // cbIsPreemptive
            // 
            this.cbIsPreemptive.AutoSize = true;
            this.cbIsPreemptive.Location = new System.Drawing.Point(125, 60);
            this.cbIsPreemptive.Name = "cbIsPreemptive";
            this.cbIsPreemptive.Size = new System.Drawing.Size(79, 17);
            this.cbIsPreemptive.TabIndex = 2;
            this.cbIsPreemptive.Text = "Preemptive";
            this.cbIsPreemptive.UseVisualStyleBackColor = true;
            this.cbIsPreemptive.MouseHover += new System.EventHandler(this.cbIsPreemptive_MouseHover);
            // 
            // cbAlgorithms
            // 
            this.cbAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlgorithms.FormattingEnabled = true;
            this.cbAlgorithms.Location = new System.Drawing.Point(89, 25);
            this.cbAlgorithms.Name = "cbAlgorithms";
            this.cbAlgorithms.Size = new System.Drawing.Size(389, 21);
            this.cbAlgorithms.TabIndex = 0;
            this.cbAlgorithms.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithms_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Algorithm Name:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // pnlDrawResultSplit
            // 
            this.pnlDrawResultSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDrawResultSplit.Location = new System.Drawing.Point(370, 107);
            this.pnlDrawResultSplit.Name = "pnlDrawResultSplit";
            this.pnlDrawResultSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlDrawResultSplit.Panel1
            // 
            this.pnlDrawResultSplit.Panel1.AutoScroll = true;
            this.pnlDrawResultSplit.Panel1.Controls.Add(this.pnlGanttChart);
            // 
            // pnlDrawResultSplit.Panel2
            // 
            this.pnlDrawResultSplit.Panel2.Controls.Add(this.pnlResults);
            this.pnlDrawResultSplit.Size = new System.Drawing.Size(884, 374);
            this.pnlDrawResultSplit.SplitterDistance = 264;
            this.pnlDrawResultSplit.TabIndex = 2;
            // 
            // GanttChartMaker
            // 
            this.AcceptButton = this.btnMake;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnReset;
            this.ClientSize = new System.Drawing.Size(1254, 481);
            this.Controls.Add(this.pnlDrawResultSplit);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.pnlProcesses);
            this.MinimumSize = new System.Drawing.Size(1270, 520);
            this.Name = "GanttChartMaker";
            this.Text = "Gantt Chart Maker";
            this.Load += new System.EventHandler(this.GanttChartMaker_Load);
            this.pnlSettings.ResumeLayout(false);
            this.gpProcesses.ResumeLayout(false);
            this.gpProcesses.PerformLayout();
            this.gpScheduling.ResumeLayout(false);
            this.gpScheduling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.pnlDrawResultSplit.Panel1.ResumeLayout(false);
            this.pnlDrawResultSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlDrawResultSplit)).EndInit();
            this.pnlDrawResultSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProcesses;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.GroupBox gpScheduling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProcessCount;
        private System.Windows.Forms.CheckBox cbIsPreemptive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAlgorithms;
        private System.Windows.Forms.CheckBox cbPriorityRank;
        private System.Windows.Forms.GroupBox gpProcesses;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblQuantum;
        private System.Windows.Forms.TextBox txtQuantum;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.CheckBox cbNoArrivalTime;
        private System.Windows.Forms.Panel pnlGanttChart;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.SplitContainer pnlDrawResultSplit;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

