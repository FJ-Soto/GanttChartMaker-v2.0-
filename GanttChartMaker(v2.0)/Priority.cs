using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttChartMaker_v2._0
{
    class Priority : Algorithm, IPreemptive, IPriority
    {
        /*Required fields*/
        private readonly String name = "Priority";
        private List<Process> processes;
        private bool preemptive = false, ascendingPriority;

        /*Name getter-- what's displayed in combobox*/
        public override string Name { get { return name; } }

        /*Methods that decide if checkboxes are enabled/disabled*/
        public override bool canBePreemptive()
        {
            return true;
        }
        public override bool considersPriority()
        {
            return true;
        }
        public override bool needsQuantum()
        {
            return false;
        }

        public override void setData(List<Process> processes)
        {
            this.processes = processes;
        }

        public void setPreemptive(bool preemptive)
        {
            this.preemptive = preemptive;
        }

        private List<Process> sort()
        {
            // handles the appropriate order to sort by.
            if (ascendingPriority)
            {
                return processes.OrderBy(p => p.ArrivalTime).ThenByDescending(p => p.Priority).ThenBy(p => p.Name).ToList<Process>();
            }
            else
            {
                return processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Priority).ThenBy(p => p.Name).ToList<Process>();
            }
        }

        public override List<Process> doAlgorithm(bool withArrivalTime)
        {
            /* This sorts to find the first job to execute.
             * After its unit of execution, another sort is done to schedule the 
             * appropriate process (higher priority).
             */
            if (withArrivalTime && preemptive)
            {
                List<Process> ordered = new List<Process>(), temp = new List<Process>();
                foreach (Process p in processes)
                {
                    temp.Add(p);
                }
                double timer = 0;
                temp = sort();
                while (temp.Count != 0)
                {
                    if (timer < temp[0].ArrivalTime)
                    {
                        ordered.Add(new Process("IDLE", temp[0].ArrivalTime - timer));
                        timer = temp[0].ArrivalTime;
                    }
                    if (temp[0].BurstTime <= 1)
                    {
                        timer += temp[0].BurstTime;
                        temp[0].CompletionTime = timer;
                        if (ordered.Count > 0 && ordered[ordered.Count - 1].Name == temp[0].Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += 1;
                            ordered[ordered.Count - 1].CompletionTime = temp[0].CompletionTime;
                        }
                        else
                        {
                            ordered.Add(temp[0]);
                        }
                        temp.RemoveAt(0);
                    }
                    else
                    {
                        timer += 1;
                        temp[0].BurstTime -= 1;
                        Process adjusted = new Process(temp[0], 1);
                        if (ordered.Count > 0 && ordered[ordered.Count - 1].Name == adjusted.Name)
                        {
                            ordered[ordered.Count - 1].BurstTime += 1;
                        }
                        else
                        {
                            ordered.Add(adjusted);
                        }
                    }
                    // sort
                    for (int i = 0; i < temp.Count; i++)
                    {
                        int lowestIndex = i;
                        for (int j = i; j < temp.Count; j++)
                        {
                            bool bothArriven = temp[lowestIndex].ArrivalTime <= timer && temp[j].ArrivalTime <= timer;
                            bool needSwap = ascendingPriority ? temp[j].Priority > temp[lowestIndex].Priority : temp[j].Priority < temp[lowestIndex].Priority;
                            if (bothArriven && temp[j].Priority == temp[lowestIndex].Priority && temp[j].ArrivalTime < temp[lowestIndex].ArrivalTime)
                            {
                                lowestIndex = j;
                            }
                            else if (bothArriven && temp[j].Priority == temp[lowestIndex].Priority && temp[j].ArrivalTime == temp[lowestIndex].ArrivalTime && temp[j].Name.CompareTo(temp[lowestIndex].Name) < 0)
                            {
                                lowestIndex = j;
                            }
                            else if (bothArriven && needSwap)
                            {
                                lowestIndex = j;
                            }
                        }
                        Process swap = temp[lowestIndex];
                        temp[lowestIndex] = temp[i];
                        temp[i] = swap;
                    }
                }
                return ordered;
            }
            else if (withArrivalTime)
            /* This sorts to find the first job to execute.
             * After its complete execution, a sort is done to
             * find the next job to execute.
             */
            {
                List<Process> ordered = new List<Process>(), temp = new List<Process>(processes);
                int lowestIndex;
                double timer = 0;
                temp = sort();
                while (temp.Count != 0)
                {
                    if (timer < temp[0].ArrivalTime)
                    {
                        ordered.Add(new Process("IDLE", temp[0].ArrivalTime - timer));
                        timer = temp[0].ArrivalTime;
                    }
                    timer += temp[0].BurstTime;
                    temp[0].CompletionTime = timer;
                    ordered.Add(temp[0]);
                    temp.RemoveAt(0);
                    // sort
                    for (int i = 0; i < temp.Count; i++)
                    {
                        lowestIndex = i;
                        for (int j = i; j < temp.Count; j++)
                        {
                            bool bothArriven = temp[lowestIndex].ArrivalTime <= timer && temp[j].ArrivalTime <= timer;
                            bool needSwap = ascendingPriority ? temp[j].Priority > temp[lowestIndex].Priority : temp[j].Priority < temp[lowestIndex].Priority;
                            if (bothArriven && temp[j].Priority == temp[lowestIndex].Priority && temp[j].Name.CompareTo(temp[lowestIndex].Name) < 0)
                            {
                                lowestIndex = j;
                            }
                            else if (bothArriven && needSwap)
                            {
                                lowestIndex = j;
                            }
                        }
                        Process swap = temp[lowestIndex];
                        temp[lowestIndex] = temp[i];
                        temp[i] = swap;
                    }
                }
                return ordered;
            }
            else
            {
                // sort solely on priority then serialization
                processes = ascendingPriority ? processes.OrderByDescending(p => p.Priority).ThenBy(p => p.Name).ToList<Process>(): processes.OrderBy(p => p.Priority).ThenBy(p => p.Name).ToList<Process>();
                double timer = 0;
                foreach(Process p in processes)
                {
                    timer += p.BurstTime;
                    p.CompletionTime = timer;
                }
                return processes;
            }
        }

        public void setPriorityRanking(bool ascendingPriority)
        {
            this.ascendingPriority = ascendingPriority;
        }

        public override string onHoverDescription()
        {
            return "This algorithm executes the highest-priority, available process first.";
        }
    }
}
