/*
 * This class holds and stores the read-in processes.
 * It also provides means for displaying a processes' details
 * in the form of textboxs to be used in the main.
 */

using System;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace GanttChartMaker;

class Process
{
    /*Fields*/
    private int priority;
    private readonly string name;
    private double arrivalTime, burstTime, completionTime, burstCopy;
    /*End of Fields*/

    /*Constructors*/
    // Copy constructor.
    public Process(Process toCopy)
    {
        this.name = toCopy.name;
        this.priority = toCopy.priority;
        this.burstTime = toCopy.burstTime;
        this.arrivalTime = toCopy.arrivalTime;
        this.burstCopy = toCopy.burstCopy;
    }

    // This is the main constructor to be called.
    public Process(string name)
    {
        this.name = name;
        this.burstTime = 0;
        this.priority = 0;
        this.arrivalTime = 0;
        this.burstCopy = 0;
    }

    public Process(Process p, double burstTime)
    {
        this.name = p.name;
        this.burstTime = burstTime;
        this.priority = p.priority;
        this.arrivalTime = p.arrivalTime;
        this.burstCopy = p.burstCopy;
    }

    // This is used to generate 'idle time'.
    public Process(string name, double idleTime)
    {
        this.name = name;
        this.burstTime = idleTime;
        this.completionTime = 0;
    }

    // This method creates a custom process; mainly used in preemptive algorithms.
    public Process(string name, int priority, double burstTime, double arrivalTime)
    {
        this.name = name;
        this.priority = priority;
        this.burstTime = burstTime;
        this.arrivalTime = arrivalTime;
        this.burstCopy = burstTime;
    }
    /*End of Constructors*/

    /*Get/Sets for Properties*/
    public double CompletionTime { get { return completionTime; } set { this.completionTime = value; } }

    public double BurstTime { get { return burstTime; } set { burstTime = value; } }

    public string Name { get { return name; } }

    public int Priority { get { return priority; } }

    public double ArrivalTime { get { return arrivalTime; } }

    public double getTT(bool withArrivalTime)
    {
        return withArrivalTime ? completionTime - arrivalTime : completionTime;
    }

    public double OriginalBurstTime { get { return burstCopy; } }

    // Method for bulk-updating processes'.
    public void setProperties(int priority, double burstTime, double arrivalTime)
    {
        this.burstTime = burstTime;
        this.priority = priority;
        this.arrivalTime = arrivalTime;
        this.burstCopy = burstTime;
    }

    /*End of Get/Sets for Properties*/

    // Generates the required TextBoxes w/details to be displayed in main.
    public TextBox[] Details
    {
        get
        {

            return
            [
                new() {Text = name },
                new() {Text = $"{priority}"},
                new() {Text = $"{burstTime}"},
                new() {Text = $"{arrivalTime}"},
            ];
        }
    }
}
