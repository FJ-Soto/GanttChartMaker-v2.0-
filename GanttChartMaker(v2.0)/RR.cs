using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttChartMaker_v2._0
{
    class RR : Algorithm, IPreemptive, IQuantum
    {
        private readonly String name = "Round Robin";
        private List<Process> processes;
        private bool preemptive = false;
        private double quantum;
        public override string Name { get { return name; } }

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
            return true;
        }
        public void setPreemptive(bool preemptive)
        {
            this.preemptive = preemptive;
        }

        public override void setData(List<Process> processes)
        {
            this.processes = processes;
        }

        public override List<Process> doAlgorithm(bool withArrivalTime)
        {
            /* With arrival time, a queue is made to provide cyclic nature.
               The first process is obtained with a general sort; thereafter,
               an appropriate comparisons are done to add the next process.
             */
            if (withArrivalTime)
            {
                Queue<Process> q = new Queue<Process>();
                List<Process> ordered = new List<Process>();
                double timer = 0;
                bool enqueue;
                processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Name).ToList<Process>();
                q.Enqueue(processes[0]);
                processes.RemoveAt(0);
                while (q.Count != 0)
                {
                    enqueue = false;
                    Process curr = q.Dequeue();
                    // Creates 'idle time'
                    if (timer < curr.ArrivalTime)
                    {
                        ordered.Add(new Process("IDLE", curr.ArrivalTime - timer));
                        timer = curr.ArrivalTime;
                    }
                    if (curr.BurstTime <= quantum)
                    {
                        timer += curr.BurstTime;
                        curr.CompletionTime = timer;
                        // This appends if the previously executed job is continuing.
                        if (ordered.Count != 0 && curr.Name == ordered[ordered.Count - 1].Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += curr.BurstTime;
                            ordered[ordered.Count - 1].CompletionTime = curr.CompletionTime;
                        }
                        else
                        {
                            ordered.Add(curr);
                        }
                    }
                    else
                    {
                        if (ordered.Count != 0 && curr.Name == ordered[ordered.Count - 1].Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += quantum;
                        }
                        else
                        {
                            ordered.Add(new Process(curr, quantum));
                        }
                        curr.BurstTime -= quantum;
                        timer += quantum;
                        enqueue = true;
                    }
                    //sort
                    processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Name).ToList<Process>();
                    // Enqueue any newly available processes.
                    foreach (Process p in processes)
                    {
                        if (p.ArrivalTime <= timer)
                        {
                            q.Enqueue(p);
                        }
                    }
                    // Remove all that were just added.
                    processes.RemoveAll(p => (p.ArrivalTime <= timer));
                    // Re-enqueue the currently executed process if not completed.
                    if (enqueue)
                    {
                        q.Enqueue(curr);
                    }
                    // Enqueue a process if no process is in queue and there are still processes needing to execute.
                    if (q.Count == 0 && !enqueue && processes.Count != 0)
                    {
                        q.Enqueue(processes[0]);
                        processes.RemoveAt(0);
                    }
                }
                return ordered;
            }
            else
            /* If no arrival time, then a sort on arrival time/serialization is done.
             * Then each process is added to a queue by such order and round-robin execution goes on.
             */
            {
                Queue<Process> q = new Queue<Process>();
                List<Process> ordered = new List<Process>();
                processes = processes.OrderBy(p => p.Name).ToList<Process>();
                double timer = 0;
                foreach (Process p in processes)
                {
                    q.Enqueue(p);
                }
                while (q.Count != 0)
                {
                    Process curr = q.Dequeue();
                    if (curr.BurstTime <= quantum)
                    {
                        timer += curr.BurstTime;
                        curr.CompletionTime = timer;
                        if (ordered.Count != 0 && curr.Name == ordered[ordered.Count - 1].Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += curr.BurstTime;
                            ordered[ordered.Count - 1].CompletionTime = curr.CompletionTime;
                        }
                        else
                        {
                            ordered.Add(curr);
                        }
                    }
                    else
                    {
                        timer += quantum;
                        if (ordered.Count != 0 && curr.Name == ordered[ordered.Count - 1].Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += quantum;
                        }
                        else
                        {
                            ordered.Add(new Process(curr.Name, curr.Priority, quantum, curr.ArrivalTime));
                        }
                        curr.BurstTime -= quantum;
                        q.Enqueue(curr);
                    }
                }
                return ordered;
            }
        }

        public void setQuantum(double quantum)
        {
            this.quantum = quantum;
        }

        public override string onHoverDescription()
        {
            return "This algorithm runs an available process for the given quantum or termination(whichever is shorter) then switches to the next available process.\n" +
                "This is preemptive by nature.";
        }
    }
}
