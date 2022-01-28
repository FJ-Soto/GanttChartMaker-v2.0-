/*
 * This gives a definition for algorithms.
 * Each algorithm must implement the following to work successfully.
 */

using System;
using System.Collections.Generic;

/*
    This abstract class is set to provide a means for 'standardization of algorithms' 
*/
namespace GanttChartMaker_v2._0
{
    abstract class Algorithm
    {
        public abstract String Name { get; }
        public abstract bool canBePreemptive();
        public abstract bool considersPriority();
        public abstract bool needsQuantum();
        public abstract void setData(List<Process> processes);
        public abstract List<Process> doAlgorithm(bool withArrivalTime);
        public abstract String onHoverDescription();
    }
}
