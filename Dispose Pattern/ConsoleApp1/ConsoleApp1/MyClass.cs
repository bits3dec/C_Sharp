using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyClass : IDisposable
    {
        public MyClass()
        {
            Console.WriteLine("Inside constructor");
        }

        //overrides Finalize method of System.Object
        ~MyClass()
        {
            Dispose(false);
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    Console.WriteLine("Release managed resource");
                }

                // TODO: free unmanaged resources (unmanaged objects like file handles, network connections, database connections)
                Console.WriteLine("Release unmanaged resource");

                disposedValue = true;
            }
        }
        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
