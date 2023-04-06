
using System;
using Newtonsoft.Json.Bson;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged; 
        
        public void Log(string error)
        {
            // null
            // ""
            // " "
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();

            LastError = error;

            // Write the log to a storage
            // ...

            ErrorLogged?.Invoke(this, Guid.NewGuid());

           // OnErrorLogged(Guid.NewGuid());
        }

        protected virtual void OnErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }

        //private void bla(){}
        //protected void bla1(){}
        //protected virtual void bla2(){}
    }
}