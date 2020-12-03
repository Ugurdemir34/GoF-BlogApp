using System;
using System.Collections.Generic;
using System.Text;

namespace GoF.Core.Utilities.Results
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
