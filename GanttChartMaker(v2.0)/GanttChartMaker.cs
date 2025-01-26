using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GanttChartMaker;

public partial class GanttChartMaker : Form
{
    /*Fields*/
    private List<Process> processes = new List<Process>();
    static ToolTip tip = new ToolTip();
    /*End of Fields*/

    /*Initialization and Load*/
    public GanttChartMaker()
    {
        InitializeComponent();
    }

    private void GanttChartMaker_Load(object sender, EventArgs e)
    {
        List<IAlgorithm> algorithms = new List<IAlgorithm>();
        algorithms.AddRange(new IAlgorithm[] { new FCFS(), new SJF(), new Priority(), new RR(), new LJF() });
        pnlDrawResultSplit.SplitterDistance = 180;
        cbAlgorithms.DataSource = algorithms;
        cbAlgorithms.DisplayMember = "Name";
        txtProcessCount.Text = "3";
        cbAlgorithms.SelectedIndex = 0;
        btnResize_Click(null, null);
    }
    /*End of Initialization and Load*/

    /*Hover Tool-Tips*/
    // This method is used to add messages on-hover.
    private void hoverMessage(object sender, string message)
    {
        // clears previous messages to avoid stacking them
        tip.SetToolTip((Control)sender, "");
        tip.SetToolTip((Control)sender, message);
    }
    private void cbPriorityRank_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "If checked, high priority numbers indicate high priority.");
    }
    private void cbIsPreemptive_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "If not checked, once a process is running it will run until termination.");
    }
    private void btnResize_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "Selecting this will add/remove processes according to the left number.\nAny processes that are cut off will be deleted.");
    }
    private void btnReset_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "Selecting this will clear all processes and resize to 3.");
    }
    private void btnMake_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "Selecting this will generate a Gantt-Chart with the requested constraints.");
    }
    private void lblQuantum_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "You can specify how large of a quantum each process gets in round-robin.");
    }
    private void cbArrivalTime_MouseHover(object sender, EventArgs e)
    {
        hoverMessage(sender, "If not checked, arrival times will be considered to be zero and go by order.");
    }
    /*End of Hover Tool-Tips*/

    /*Validations*/
    private void txtProcessCount_Validating(object sender, CancelEventArgs e)
    {
        errorProvider.SetError(txtProcessCount, "");
        int temp;
        if (!int.TryParse(txtProcessCount.Text, out temp))
        {
            errorProvider.SetError(txtProcessCount, "Enter an integer value");
            e.Cancel = true;
        }
        else if (temp <= 0)
        {
            errorProvider.SetError(txtProcessCount, "Enter a positive integer value");
            e.Cancel = true;
        }
    }

    private void pnlProcesses_Validating(object sender, CancelEventArgs e)
    {
        TextBox[] txt = pnlProcesses.Controls.OfType<TextBox>().ToArray();
        for (int i = 0; i < txt.Length; i++)
        {
            if (i % 4 != 0)
            {
                txt[i].BackColor = Color.White;
            }
        }
        for (int i = 0; i < txt.Length; i++)
        {
            double temp;
            if (i % 4 != 0 && !double.TryParse(txt[i].Text, out temp))
            {
                txt[i].BackColor = Color.Yellow;
                e.Cancel = true;
            }
            else if (i % 4 != 0 && double.Parse(txt[i].Text) < 0)
            {
                txt[i].BackColor = Color.Yellow;
                e.Cancel = true;
            }
        }
        for (int i = 2; i < txt.Length; i += 4)
        {
            int temp;
            if (int.TryParse(txt[i].Text, out temp) && temp <= 0)
            {
                txt[i].BackColor = Color.Yellow;
                e.Cancel = true;
            }
        }
    }

    private void txtQuantum_Validating(object sender, CancelEventArgs e)
    {
        if (txtQuantum.Enabled)
        {
            double val;
            errorProvider.SetError(txtQuantum, "");
            if (!double.TryParse(txtQuantum.Text, out val) || val <= 0)
            {
                errorProvider.SetError(txtQuantum, "Enter a positive integer");
                e.Cancel = true;
                return;
            }
            if (val % 1 != 0)
            {
                txtQuantum.BackColor = Color.Pink;
                hoverMessage(txtQuantum, "This can cause irregularities in computations due to float-point precision.\n" +
                    "This can represent itself in out-of-place values.\n");
            }
            else
            {
                txtQuantum.BackColor = TextBox.DefaultBackColor;
                hoverMessage(txtQuantum, "");
            }
        }
    }
    /*End of Validations*/

    /*Drawing Methods*/
    private void drawProcessesSection()
    {
        pnlProcesses.Controls.Clear();
        drawHeaders();
        drawProcessDetailGrid();
    }

    private void drawHeaders()
    {
        int leftMost = 20, labelWidth = 80, top = 10;
        Label header = new Label()
        {
            Text = "Process #",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost, top),
            Size = new Size(80, 20),
            BorderStyle = BorderStyle.FixedSingle
        };
        header.TextAlign = ContentAlignment.MiddleLeft;
        pnlProcesses.Controls.Add(header);
        header = new Label()
        {
            Text = "Priority #",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + labelWidth * 1, top),
            Size = new Size(80, 20),
            BorderStyle = BorderStyle.FixedSingle
        };
        header.MouseHover += (s, e) => { hoverMessage(s, "Non-negative integer value."); };
        header.TextAlign = ContentAlignment.MiddleLeft;
        pnlProcesses.Controls.Add(header);
        header = new Label()
        {
            Text = "Burst Time",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + labelWidth * 2, top),
            Size = new Size(80, 20),
            BorderStyle = BorderStyle.FixedSingle
        };
        header.MouseHover += (s, e) => { hoverMessage(s, "Positive number."); };
        header.TextAlign = ContentAlignment.MiddleLeft;
        pnlProcesses.Controls.Add(header);
        header = new Label()
        {
            Text = "Arrival Time",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + labelWidth * 3, top),
            Size = new Size(80, 20),
            BorderStyle = BorderStyle.FixedSingle
        };
        header.MouseHover += (s, e) => { hoverMessage(s, "Non-negative number."); };
        header.TextAlign = ContentAlignment.MiddleLeft;
        pnlProcesses.Controls.Add(header);
    }

    private void drawProcessDetailGrid()
    {
        int leftMost = 20, top = 30, height = 20, width = 80;
        for (int i = processes.Count; i < int.Parse(txtProcessCount.Text); i++)
        {
            processes.Add(new Process(string.Format("P{0}", i + 1)));
        }
        for (int i = 0; i < processes.Count; i++)
        {
            TextBox[] detail = processes[i].Details;
            TextBox name = detail[0];
            name.Location = new Point(leftMost, top + height * i);
            name.Size = new Size(80, 20);
            name.BorderStyle = BorderStyle.FixedSingle;
            name.ReadOnly = true;
            name.TabStop = false;
            this.pnlProcesses.Controls.Add(name);

            name = detail[1];
            name.Location = new Point(leftMost + width * 1, top + height * i);
            name.Size = new Size(80, 20);
            name.BorderStyle = BorderStyle.FixedSingle;
            name.TabStop = false;
            this.pnlProcesses.Controls.Add(name);

            name = detail[2];
            name.Location = new Point(leftMost + width * 2, top + height * i);
            name.Size = new Size(80, 20);
            name.BorderStyle = BorderStyle.FixedSingle;
            name.TabStop = false;
            this.pnlProcesses.Controls.Add(name);

            name = detail[3];
            name.Location = new Point(leftMost + width * 3, top + height * i);
            name.Size = new Size(80, 20);
            name.BorderStyle = BorderStyle.FixedSingle;
            name.TabStop = false;
            this.pnlProcesses.Controls.Add(name);
        }
    }

    private void drawGanttChart(List<Process> orderedProcesses)
    {
        pnlGanttChart.Controls.Clear();
        double sum = 0;
        foreach (Process p in orderedProcesses)
        {
            sum += p.BurstTime;
        }
        double scalar = 720.0 / sum, timer = 0, tt = 0, wt = 0, ct = 0;
        int shift = 0, height = 100, width = 0;
        foreach (Process p in orderedProcesses)
        {
            width = (int)(p.BurstTime * scalar);
            width = width < 35 ? width = 40 : width;

            Label toDraw = new Label()
            {
                Text = $"{timer}",
                Location = new Point(15 + shift, 40 + height),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.pnlGanttChart.Controls.Add(toDraw);
            toDraw = new Label()
            {
                Text = p.Name,
                Location = new Point(20 + shift, 40),
                Size = new Size(width, height),
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = p.Name == "IDLE" ? Color.Black : Label.DefaultBackColor,
                ForeColor = p.Name == "IDLE" ? Color.White : Label.DefaultForeColor
            };
            this.pnlGanttChart.Controls.Add(toDraw);
            toDraw = new Label
            {
                Text = $"{p.BurstTime}",
                Location = new Point(20 + shift, 20),
                Size = new Size(width, 20),
                TextAlign = ContentAlignment.MiddleCenter,

            };
            shift += width;
            this.pnlGanttChart.Controls.Add(toDraw);
            timer += p.BurstTime;
            if (p.CompletionTime != 0)
            {
                ct += p.CompletionTime;
                tt += p.getTT(!cbNoArrivalTime.Checked);
                wt += p.getTT(!cbNoArrivalTime.Checked) - p.OriginalBurstTime;
            }
        }
        Label end = new Label()
        {
            Text = $"{timer}",
            Location = new Point(15 + shift, 40 + height),
            AutoSize = true,
            TextAlign = ContentAlignment.MiddleLeft
        };
        this.pnlGanttChart.Controls.Add(end);
        drawResultsPanel(orderedProcesses, wt, tt, ct);
    }

    private void drawResultsPanel(List<Process> ps, double wt, double tt, double ct)
    {
        pnlResults.Controls.Clear();
        int leftMost = 20, top = 10, width = 80, height = 20, count = 0;
        Label temp = new Label()
        {
            Text = "Process #",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost, top),
            Size = new Size(width, 20),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = "Completion Time",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width * 1, 10),
            Size = new Size(width * 2, 20),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        temp.MouseHover += (s, e) => { hoverMessage(s, "This is the time at which the process is completely done."); };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = "Turnaround Time",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width * 3, 10),
            Size = new Size(width * 2, 20),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        temp.MouseHover += (s, e) => { hoverMessage(s, "This is the total time a process spends in queue until termination."); };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = "Waiting Time",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width * 5, 10),
            Size = new Size(width * 2, 20),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        temp.MouseHover += (s, e) => { hoverMessage(s, "This is the time spent by a process waiting for CPU time."); };
        pnlResults.Controls.Add(temp);
        pnlResults.Controls.Add(temp);
        top = 30;
        ps = ps.OrderBy(p => p.Name).ToList<Process>();
        foreach (Process p in ps)
        {
            if (p.CompletionTime != 0)
            {
                temp = new Label()
                {
                    Text = p.Name,
                    Font = new Font(Font, FontStyle.Bold),
                    Location = new Point(leftMost, top + height * count),
                    Size = new Size(width, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlResults.Controls.Add(temp);
                temp = new Label()
                {
                    Text = $"{p.CompletionTime}",
                    Font = new Font(Font, FontStyle.Bold),
                    Location = new Point(leftMost + width * 1, top + height * count),
                    Size = new Size(width * 2, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlResults.Controls.Add(temp);
                temp = new Label()
                {
                    Text = string.Format(!cbNoArrivalTime.Checked? "{0} - {1} = {2}":"{2}", p.CompletionTime, p.ArrivalTime, p.getTT(!cbNoArrivalTime.Checked)),
                    Font = new Font(Font, FontStyle.Bold),
                    Location = new Point(leftMost + width * 3, top + height * count),
                    Size = new Size(width * 2, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlResults.Controls.Add(temp);
                temp = new Label()
                {
                    Text = string.Format("{0} - {1} = {2}", p.getTT(!cbNoArrivalTime.Checked), p.OriginalBurstTime, (p.getTT(!cbNoArrivalTime.Checked) - p.OriginalBurstTime)),
                    Font = new Font(Font, FontStyle.Bold),
                    Location = new Point(leftMost + width * 5, top + height * count++),
                    Size = new Size(width * 2, height),
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                pnlResults.Controls.Add(temp);
            }
        }
        temp = new Label()
        {
            Location = new Point(leftMost, top + height * count),
            Size = new Size(560, 10),
            BackColor = Color.Black
        };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = "AVG",
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost, top + height * count + 10),
            Size = new Size(width, height),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = string.Format("{0:0.##}", ct / processes.Count),
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width, top + height * count + 10),
            Size = new Size(width * 2, height),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = string.Format("{0:0.##}", tt / processes.Count),
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width * 3, top + height * count + 10),
            Size = new Size(width * 2, height),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlResults.Controls.Add(temp);
        temp = new Label()
        {
            Text = string.Format("{0:0.##}", wt / processes.Count),
            Font = new Font(Font, FontStyle.Bold),
            Location = new Point(leftMost + width * 5, top + height * count + 10),
            Size = new Size(width * 2, height),
            BorderStyle = BorderStyle.FixedSingle,
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlResults.Controls.Add(temp);
    }

    /*End of Draw Methods*/

    /*Event Handlers*/
    private void btnReset_Click(object sender, EventArgs e)
    {
        // The two lines below handle a weird bug where the scrollbar does not reset.
        pnlProcesses.AutoScroll = false;
        pnlProcesses.AutoScroll = true;
        txtProcessCount.Text = "3";
        processes.Clear();
        drawProcessesSection();
        errorProvider.Clear();
    }

    private void btnMake_Click(object sender, EventArgs e)
    {
        errorProvider.SetError(btnMake, "");
        if (this.ValidateChildren(ValidationConstraints.Visible))
        {
            storeValues();
            IAlgorithm selected = (IAlgorithm)cbAlgorithms.SelectedItem;
            selected.SetData(new List<Process>(processes));
            if (cbIsPreemptive.Enabled)
            {
                IPreemptive set = selected as IPreemptive;
                set.Preemptive = cbIsPreemptive.Checked;
            }
            if (cbPriorityRank.Enabled)
            {
                IPriority set = selected as IPriority;
                set.AscendingPriority = cbPriorityRank.Checked;
            }
            if (lblQuantum.Enabled)
            {
                IQuantum set = selected as IQuantum;
                set.Quantum = (double.Parse(txtQuantum.Text));
            }
            List<Process> orderedProcesses = selected.DoAlgorithm(!cbNoArrivalTime.Checked);
            drawGanttChart(orderedProcesses);
        }
        else
        {
            errorProvider.SetError(btnMake, "Please fix errors.\nYellow indicate invalid value.");
        }
    }

    private void cbAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
    {
        IAlgorithm algo = (IAlgorithm)cbAlgorithms.SelectedItem;
        cbIsPreemptive.Enabled = algo.CanBePreemptive();
        cbPriorityRank.Enabled = algo.ConsidersPriority();
        txtQuantum.Enabled = algo.NeedsQuantum();
        lblQuantum.Enabled = algo.NeedsQuantum();
        hoverMessage(sender, algo.OnHoverDescription());
    }

    private void btnResize_Click(object sender, EventArgs e)
    {
        if (this.ValidateChildren() && int.Parse(txtProcessCount.Text) != processes.Count)
        {
            storeValues();
            int newSize = int.Parse(txtProcessCount.Text);
            if (newSize < processes.Count)
            {
                processes.RemoveRange(newSize, processes.Count - newSize);
            }
            drawProcessesSection();
        }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        OpenFileDialog open = new OpenFileDialog();
        DialogResult result = open.ShowDialog();
        if (result == DialogResult.OK)
        {
            try
            {
                processes.Clear();
                using (StreamReader fileIn = new StreamReader(open.FileName))
                {
                    string lineIn = fileIn.ReadLine();
                    string[] split;
                    // must trim inside as you cannot trim a null ReadLine()
                    while (lineIn != null && lineIn.Trim().Length != 0)
                    {
                        split = lineIn.Split(' ');
                        processes.Add(new Process(string.Format("P{0}", processes.Count + 1), int.Parse(split[0]), double.Parse(split[1]), double.Parse(split[2])));
                        lineIn = fileIn.ReadLine();
                    }
                    if (processes.Count == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        txtProcessCount.Text = $"{processes.Count}";
                        drawProcessesSection();
                        btnResize_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                result = MessageBox.Show("An error occured while trying to load the file.\nThe format must follow: (int)priority, (double)burst time, (double)arrival time.", "Error Loading", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    btnLoad_Click(null, null);
                }
            }
        }
    }
    /*End of Event Handlers*/

    //Method for storing values
    private void storeValues()
    {
        TextBox[] vals = pnlProcesses.Controls.OfType<TextBox>().ToArray();
        int index = 1;
        foreach (Process p in processes)
        {
            p.setProperties(int.Parse(vals[index++].Text), double.Parse(vals[index++].Text), double.Parse(vals[index].Text));
            index += 2;
        }
    }
}