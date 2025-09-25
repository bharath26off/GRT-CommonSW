using GRT_BG1.Function;
using GRT_BG1.Function.Interface;
using StreamlineProcess.BaseClass;

public class Process
{
    private readonly IWorkingConveyor _workingConveyor;
    private readonly IlodingConveyor _loadingConveyor;

    public Process(IWorkingConveyor workingConveyor, IlodingConveyor loadingConveyor)
    {
        _workingConveyor = workingConveyor;
        _loadingConveyor = loadingConveyor;
    }

    public void RegisterHandlers()
    {
        ParallelBase.RegisterAsyncHandler(async () =>
        {
            await _loadingConveyor.LoadingConveyor_Seq();
        });

        ParallelBase.RegisterAsyncHandler(async () =>
        {
            await _workingConveyor.WorkingCon_Seq();
        });
       

    }


}








