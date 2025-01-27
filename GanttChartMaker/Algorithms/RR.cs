using GanttChartMaker.Algorithms.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GanttChartMaker.Algorithms;

class RR : IAlgorithm, IPreemptive, IQuantum
{
    private List<Process> processes;

    public string Name => "Round Robin";
    public bool CanBePreemptive() => false;

    public bool ConsidersPriority() => false;

    public bool NeedsQuantum() => true;

    public bool Preemptive { get; set; } = false;


    public void SetData(List<Process> processes)
    {
        this.processes = processes;
    }

    public List<Process> DoAlgorithm(bool withArrivalTime)
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
            processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Name).ToList();
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
                if (curr.BurstTime <= Quantum)
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
                        ordered[ordered.Count - 1].BurstTime += Quantum;
                    }
                    else
                    {
                        ordered.Add(new Process(curr, Quantum));
                    }
                    curr.BurstTime -= Quantum;
                    timer += Quantum;
                    enqueue = true;
                }
                //sort
                processes = processes.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Name).ToList();
                // Enqueue any newly available processes.
                foreach (Process p in processes)
                {
                    if (p.ArrivalTime <= timer)
                    {
                        q.Enqueue(p);
                    }
                }
                // Remove all that were just added.
                processes.RemoveAll(p => p.ArrivalTime <= timer);
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
            processes = processes.OrderBy(p => p.Name).ToList();
            double timer = 0;
            foreach (Process p in processes)
            {
                q.Enqueue(p);
            }
            while (q.Count != 0)
            {
                Process curr = q.Dequeue();
                if (curr.BurstTime <= Quantum)
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
                    timer += Quantum;
                    if (ordered.Count != 0 && curr.Name == ordered[ordered.Count - 1].Name)
                    {
                        ordered[ordered.Count - 1].BurstTime += Quantum;
                    }
                    else
                    {
                        ordered.Add(new Process(curr.Name, curr.Priority, Quantum, curr.ArrivalTime));
                    }
                    curr.BurstTime -= Quantum;
                    q.Enqueue(curr);
                }
            }
            return ordered;
        }
    }

    public double Quantum { get; set; }

    public string OnHoverDescription() => "This algorithm runs an available process for the given quantum or termination(whichever is shorter) then switches to the next available process. This is preemptive by nature.";
}
