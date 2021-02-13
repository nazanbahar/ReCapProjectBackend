using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        //version1: data and message parameter constructor
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //version2: only data, don't giving a message - data parameter constructor
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //version3: return data by default for example.message
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //version4: give nothing
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
