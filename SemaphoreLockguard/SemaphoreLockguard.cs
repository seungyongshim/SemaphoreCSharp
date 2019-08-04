using System;
using System.Threading;

namespace SemaphoreLockguard
{
    public class SemaphoreLockguard : IDisposable
    {
        public Semaphore Semaphore { get; }
        public bool IsGotOne { get; }


        public SemaphoreLockguard(Semaphore semaphore, TimeSpan timeout)
        {
            Semaphore = semaphore;
            IsGotOne = semaphore.WaitOne(timeout);
        }
        
        #region IDisposable Support

        public bool IsDisposed { get; private set; } = false;
        
        protected virtual void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    if (IsGotOne == true)
                    {
                        Semaphore.Release();
                    }
                }

                IsDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
