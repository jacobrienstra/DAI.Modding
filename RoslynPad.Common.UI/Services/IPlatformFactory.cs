using System;
using System.Collections.Generic;

namespace RoslynPad.UI
{
    internal interface IPlatformFactory
    {
        ExecutionPlatform GetExecutionPlatform();

        string DotNetExecutable { get; }

        event Action Changed;
    }
}