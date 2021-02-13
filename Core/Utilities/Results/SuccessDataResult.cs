using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //version1: data and message parameter constructor
        public SuccessDataResult(T data, string message):base(data,true,message)
        {

        }

        //version2: only data, don't giving a message - data parameter constructor
        public SuccessDataResult(T data):base(data,true)
        {

        }

        //version3: return data by default for example.message
        public SuccessDataResult(string message):base(default,true,message)
        {

        }

        //version4: give nothing
        public SuccessDataResult():base(default,true)
        {

        }


    }
}
