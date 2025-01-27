namespace GanttChartMaker;

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
        components = new System.ComponentModel.Container();
        pnlProcesses = new System.Windows.Forms.Panel();
        pnlResults = new System.Windows.Forms.Panel();
        pnlGanttChart = new System.Windows.Forms.Panel();
        pnlSettings = new System.Windows.Forms.Panel();
        btnLoad = new System.Windows.Forms.Button();
        gpProcesses = new System.Windows.Forms.GroupBox();
        btnResize = new System.Windows.Forms.Button();
        btnReset = new System.Windows.Forms.Button();
        btnMake = new System.Windows.Forms.Button();
        txtProcessCount = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        gpScheduling = new System.Windows.Forms.GroupBox();
        cbNoArrivalTime = new System.Windows.Forms.CheckBox();
        txtQuantum = new System.Windows.Forms.TextBox();
        lblQuantum = new System.Windows.Forms.Label();
        cbPriorityRank = new System.Windows.Forms.CheckBox();
        cbIsPreemptive = new System.Windows.Forms.CheckBox();
        cbAlgorithms = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        errorProvider = new System.Windows.Forms.ErrorProvider(components);
        pnlDrawResultSplit = new System.Windows.Forms.SplitContainer();
        toolTip = new System.Windows.Forms.ToolTip(components);
        pnlSettings.SuspendLayout();
        gpProcesses.SuspendLayout();
        gpScheduling.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pnlDrawResultSplit).BeginInit();
        pnlDrawResultSplit.Panel1.SuspendLayout();
        pnlDrawResultSplit.Panel2.SuspendLayout();
        pnlDrawResultSplit.SuspendLayout();
        SuspendLayout();
        // 
        // pnlProcesses
        // 
        pnlProcesses.AutoScroll = true;
        pnlProcesses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlProcesses.Dock = System.Windows.Forms.DockStyle.Left;
        pnlProcesses.Location = new System.Drawing.Point(0, 0);
        pnlProcesses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pnlProcesses.Name = "pnlProcesses";
        pnlProcesses.Size = new System.Drawing.Size(374, 555);
        pnlProcesses.TabIndex = 0;
        pnlProcesses.Validating += pnlProcesses_Validating;
        // 
        // pnlResults
        // 
        pnlResults.AutoScroll = true;
        pnlResults.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        pnlResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlResults.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlResults.Location = new System.Drawing.Point(0, 0);
        pnlResults.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pnlResults.Name = "pnlResults";
        pnlResults.Size = new System.Drawing.Size(1089, 123);
        pnlResults.TabIndex = 0;
        // 
        // pnlGanttChart
        // 
        pnlGanttChart.AutoScroll = true;
        pnlGanttChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlGanttChart.Location = new System.Drawing.Point(0, 0);
        pnlGanttChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pnlGanttChart.Name = "pnlGanttChart";
        pnlGanttChart.Size = new System.Drawing.Size(1089, 304);
        pnlGanttChart.TabIndex = 2;
        // 
        // pnlSettings
        // 
        pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlSettings.Controls.Add(btnLoad);
        pnlSettings.Controls.Add(gpProcesses);
        pnlSettings.Controls.Add(gpScheduling);
        pnlSettings.Dock = System.Windows.Forms.DockStyle.Top;
        pnlSettings.Location = new System.Drawing.Point(374, 0);
        pnlSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pnlSettings.Name = "pnlSettings";
        pnlSettings.Padding = new System.Windows.Forms.Padding(12);
        pnlSettings.Size = new System.Drawing.Size(1089, 123);
        pnlSettings.TabIndex = 1;
        // 
        // btnLoad
        // 
        btnLoad.Location = new System.Drawing.Point(923, 17);
        btnLoad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new System.Drawing.Size(152, 92);
        btnLoad.TabIndex = 3;
        btnLoad.Text = "Load File";
        toolTip.SetToolTip(btnLoad, "This will read a file in ther format of: priority, burst time, arrival time. The process number will be assigned automatically and as read. ");
        btnLoad.UseVisualStyleBackColor = true;
        btnLoad.Click += btnLoad_Click;
        // 
        // gpProcesses
        // 
        gpProcesses.Controls.Add(btnResize);
        gpProcesses.Controls.Add(btnReset);
        gpProcesses.Controls.Add(btnMake);
        gpProcesses.Controls.Add(txtProcessCount);
        gpProcesses.Controls.Add(label1);
        gpProcesses.Location = new System.Drawing.Point(12, 12);
        gpProcesses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gpProcesses.Name = "gpProcesses";
        gpProcesses.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gpProcesses.Size = new System.Drawing.Size(301, 98);
        gpProcesses.TabIndex = 2;
        gpProcesses.TabStop = false;
        gpProcesses.Text = "Add/Remove Processes";
        // 
        // btnResize
        // 
        btnResize.Location = new System.Drawing.Point(203, 23);
        btnResize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnResize.Name = "btnResize";
        btnResize.Size = new System.Drawing.Size(90, 27);
        btnResize.TabIndex = 2;
        btnResize.Text = "Resize";
        btnResize.UseVisualStyleBackColor = true;
        btnResize.Click += btnResize_Click;
        btnResize.MouseHover += btnResize_MouseHover;
        // 
        // btnReset
        // 
        btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnReset.Location = new System.Drawing.Point(203, 55);
        btnReset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnReset.Name = "btnReset";
        btnReset.Size = new System.Drawing.Size(90, 27);
        btnReset.TabIndex = 3;
        btnReset.Text = "Reset";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        btnReset.MouseHover += btnReset_MouseHover;
        // 
        // btnMake
        // 
        btnMake.Location = new System.Drawing.Point(10, 55);
        btnMake.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        btnMake.Name = "btnMake";
        btnMake.Size = new System.Drawing.Size(166, 27);
        btnMake.TabIndex = 4;
        btnMake.Text = "Make Chart";
        btnMake.UseVisualStyleBackColor = true;
        btnMake.Click += btnMake_Click;
        btnMake.MouseHover += btnMake_MouseHover;
        // 
        // txtProcessCount
        // 
        txtProcessCount.Location = new System.Drawing.Point(100, 25);
        txtProcessCount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        txtProcessCount.Name = "txtProcessCount";
        txtProcessCount.Size = new System.Drawing.Size(75, 23);
        txtProcessCount.TabIndex = 0;
        txtProcessCount.Validating += txtProcessCount_Validating;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(7, 29);
        label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(85, 15);
        label1.TabIndex = 1;
        label1.Text = "# of Processes:";
        // 
        // gpScheduling
        // 
        gpScheduling.Controls.Add(cbNoArrivalTime);
        gpScheduling.Controls.Add(txtQuantum);
        gpScheduling.Controls.Add(lblQuantum);
        gpScheduling.Controls.Add(cbPriorityRank);
        gpScheduling.Controls.Add(cbIsPreemptive);
        gpScheduling.Controls.Add(cbAlgorithms);
        gpScheduling.Controls.Add(label2);
        gpScheduling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        gpScheduling.Location = new System.Drawing.Point(332, 12);
        gpScheduling.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gpScheduling.Name = "gpScheduling";
        gpScheduling.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
        gpScheduling.Size = new System.Drawing.Size(583, 98);
        gpScheduling.TabIndex = 1;
        gpScheduling.TabStop = false;
        gpScheduling.Text = "Scheduling Algorithm Settings";
        // 
        // cbNoArrivalTime
        // 
        cbNoArrivalTime.AutoSize = true;
        cbNoArrivalTime.Location = new System.Drawing.Point(5, 69);
        cbNoArrivalTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbNoArrivalTime.Name = "cbNoArrivalTime";
        cbNoArrivalTime.Size = new System.Drawing.Size(98, 17);
        cbNoArrivalTime.TabIndex = 2;
        cbNoArrivalTime.Text = "No Arrival Time";
        cbNoArrivalTime.UseVisualStyleBackColor = true;
        cbNoArrivalTime.MouseHover += cbArrivalTime_MouseHover;
        // 
        // txtQuantum
        // 
        txtQuantum.Location = new System.Drawing.Point(470, 67);
        txtQuantum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        txtQuantum.Name = "txtQuantum";
        txtQuantum.Size = new System.Drawing.Size(87, 20);
        txtQuantum.TabIndex = 5;
        txtQuantum.Validating += txtQuantum_Validating;
        // 
        // lblQuantum
        // 
        lblQuantum.AutoSize = true;
        lblQuantum.Location = new System.Drawing.Point(407, 70);
        lblQuantum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        lblQuantum.Name = "lblQuantum";
        lblQuantum.Size = new System.Drawing.Size(53, 13);
        lblQuantum.TabIndex = 4;
        lblQuantum.Text = "Quantum:";
        lblQuantum.MouseHover += lblQuantum_MouseHover;
        // 
        // cbPriorityRank
        // 
        cbPriorityRank.AutoSize = true;
        cbPriorityRank.Location = new System.Drawing.Point(255, 69);
        cbPriorityRank.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbPriorityRank.Name = "cbPriorityRank";
        cbPriorityRank.Size = new System.Drawing.Size(109, 17);
        cbPriorityRank.TabIndex = 3;
        cbPriorityRank.Text = "Increasing Priority";
        cbPriorityRank.UseVisualStyleBackColor = true;
        cbPriorityRank.MouseHover += cbPriorityRank_MouseHover;
        // 
        // cbIsPreemptive
        // 
        cbIsPreemptive.AutoSize = true;
        cbIsPreemptive.Location = new System.Drawing.Point(146, 69);
        cbIsPreemptive.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbIsPreemptive.Name = "cbIsPreemptive";
        cbIsPreemptive.Size = new System.Drawing.Size(79, 17);
        cbIsPreemptive.TabIndex = 2;
        cbIsPreemptive.Text = "Preemptive";
        cbIsPreemptive.UseVisualStyleBackColor = true;
        cbIsPreemptive.MouseHover += cbIsPreemptive_MouseHover;
        // 
        // cbAlgorithms
        // 
        cbAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cbAlgorithms.FormattingEnabled = true;
        cbAlgorithms.Location = new System.Drawing.Point(104, 29);
        cbAlgorithms.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        cbAlgorithms.Name = "cbAlgorithms";
        cbAlgorithms.Size = new System.Drawing.Size(453, 21);
        cbAlgorithms.TabIndex = 0;
        cbAlgorithms.SelectedIndexChanged += cbAlgorithms_SelectedIndexChanged;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(7, 33);
        label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(84, 13);
        label2.TabIndex = 1;
        label2.Text = "Algorithm Name:";
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // pnlDrawResultSplit
        // 
        pnlDrawResultSplit.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlDrawResultSplit.Location = new System.Drawing.Point(374, 123);
        pnlDrawResultSplit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        pnlDrawResultSplit.Name = "pnlDrawResultSplit";
        pnlDrawResultSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // pnlDrawResultSplit.Panel1
        // 
        pnlDrawResultSplit.Panel1.AutoScroll = true;
        pnlDrawResultSplit.Panel1.Controls.Add(pnlGanttChart);
        // 
        // pnlDrawResultSplit.Panel2
        // 
        pnlDrawResultSplit.Panel2.Controls.Add(pnlResults);
        pnlDrawResultSplit.Size = new System.Drawing.Size(1089, 432);
        pnlDrawResultSplit.SplitterDistance = 304;
        pnlDrawResultSplit.SplitterWidth = 5;
        pnlDrawResultSplit.TabIndex = 2;
        // 
        // GanttChartMaker
        // 
        AcceptButton = btnMake;
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScroll = true;
        AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
        CancelButton = btnReset;
        ClientSize = new System.Drawing.Size(1463, 555);
        Controls.Add(pnlDrawResultSplit);
        Controls.Add(pnlSettings);
        Controls.Add(pnlProcesses);
        Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
        MinimumSize = new System.Drawing.Size(1479, 594);
        Name = "GanttChartMaker";
        Text = "Gantt Chart Maker";
        Load += GanttChartMaker_Load;
        pnlSettings.ResumeLayout(false);
        gpProcesses.ResumeLayout(false);
        gpProcesses.PerformLayout();
        gpScheduling.ResumeLayout(false);
        gpScheduling.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        pnlDrawResultSplit.Panel1.ResumeLayout(false);
        pnlDrawResultSplit.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pnlDrawResultSplit).EndInit();
        pnlDrawResultSplit.ResumeLayout(false);
        ResumeLayout(false);
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

