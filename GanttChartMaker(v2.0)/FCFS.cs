using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttChartMaker_v2._0
{
    class FCFS : Algorithm
    {
        private readonly String name = "First Come First Serve";
        private List<Process> processes;

        public override String Name { get { return name; } }
        public override bool canBePreemptive()
        {
            return false;
        }
        public override bool considersPriority()
        {
            return false;
        }
        public override bool needsQuantum()
        {
            return false;
        }

        public override void setData(List<Process> processes)
        {
            this.processes = processes;
        }

        public override List<Process> doAlgorithm(bool withArrivalTime)
        {
            /* Sort by arrival time/serialization, then loop through all adding idle time wherever necessary.
             */
            if (withArrivalTime)
            {
                List<Process> ordered = new List<Process>();
                double timer = 0;
                while (processes.Count != 0)
                {
                    processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Name).ToList<Process>();
                    // Creates 'idle time'
                    if (timer < processes[0].ArrivalTime)
                    {
                        ordered.Add(new Process("IDLE", processes[0].ArrivalTime - timer));
                        timer = processes[0].ArrivalTime;
                    }
                    timer += processes[0].BurstTime;
                    processes[0].CompletionTime = timer;
                    ordered.Add(processes[0]);
                    processes.RemoveAt(0);
                }
                return ordered;
            }
            else
            /* If no arrival time is to be considered, serialization sort then execute in order.
             */
            {
                processes = processes.OrderBy(p => p.Name).ToList<Process>();
                double timer = 0;
                foreach (Process p in processes)
                {
                    timer += p.BurstTime;
                    p.CompletionTime = timer;
                }
                return processes.OrderBy(p => p.Name).ToList<Process>();
            }
        }

        public override string onHoverDescription()
        {
            return "This algorithm executes the firstly-available, firstly-arriven processes first.";
        }
    }
}