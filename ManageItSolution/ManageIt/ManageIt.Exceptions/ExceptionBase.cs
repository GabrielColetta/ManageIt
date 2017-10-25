using System;

namespace ManageIt.Exceptions
{
    public class ExceptionBase : Exception
    {
        public virtual int statusCode { get; set; }
        public virtual string ErrorDescription { get; set; }
        public virtual Exception Exception { get; set; }
    }
}
