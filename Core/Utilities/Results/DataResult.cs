using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result, IDataResult<T>
    {
        //data parameter constructor
        public DataResult(T data, bool success, string message):base(success,message)
        {
            Data = data;
        }

        //don't giving a message - data parameter constructor
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }
        
    }
}
