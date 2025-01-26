/*
 * Interface for algorithms that can be preemptive.
 */

namespace GanttChartMaker;

interface IPreemptive
{
    bool Preemptive { get; set; }
}
