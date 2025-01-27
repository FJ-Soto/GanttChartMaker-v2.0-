/*
 * Interface for algorithms that can be preemptive.
 */

namespace GanttChartMaker.Algorithms.Interfaces;

interface IPreemptive
{
    bool Preemptive { get; set; }
}
