/*
 * This gives a definition for algorithms.
 * Each algorithm must implement the following to work successfully.
 */

/*
    This abstract class is set to provide a means for 'standardization of algorithms' 
*/
using System.Collections.Generic;

namespace GanttChartMaker;

interface IAlgorithm
{
    public string GetName();
    public bool CanBePreemptive();
    public bool ConsidersPriority();
    public bool NeedsQuantum();
    public void SetData(List<Process> processes);
    public List<Process> DoAlgorithm(bool withArrivalTime);
    public string OnHoverDescription();
}
