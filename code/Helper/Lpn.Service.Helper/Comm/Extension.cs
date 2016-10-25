using System;
using System.Diagnostics.Contracts;
using System.Threading;
using OneCoin.Service.Helper.Serialization;

namespace OneCoin.Service.Helper.Comm
{
    public static class Extension
    {
        public static T DeepCopay<T>(this T source) where T :class ,new ()
        {
            if (source == null)
            {
                return null;
            }

            var buffer = SimpleSerialization.ToBytes(source);
            if (buffer == null)
            {
                return null;
            }

            return (T)SimpleSerialization.ToObject(buffer);
        }

        #region ReadLock
        public static bool Read(this ReaderWriterLockSlim target, Action closure ,int millisecondsTimeout)
        {
            return Read(target, closure, millisecondsTimeout, true);
        }

        public static bool Read(this ReaderWriterLockSlim target, Action closure)
        {
            return Read(target, closure, null, true);
        }

        public static bool Read(this ReaderWriterLockSlim target,Action closure, int? millisecondsTimeout, bool throwsOnTimeout)
        {
            Contract.Requires<ArgumentNullException>(closure != null);
            Contract.Requires<ArgumentOutOfRangeException>(
                millisecondsTimeout == null || millisecondsTimeout >= 0
            );

            bool lockHeld = false;
            try
            {
                lockHeld = target.EnterReadLock(millisecondsTimeout,throwsOnTimeout);
                closure();
            }
            finally
            {
                if (lockHeld)
                    target.ExitReadLock();
            }

            return lockHeld;
        }


        private static bool EnterReadLock(this ReaderWriterLockSlim target,int? millisecondsTimeout, bool throwsOnTimeout)
        {
            if (millisecondsTimeout == null)
                target.EnterReadLock();
            else if (!target.TryEnterReadLock(millisecondsTimeout.Value))
            {
                if (throwsOnTimeout)
                    throw new TimeoutException(
                        "Could not gain a read lock within the timeout specified. " +
                        "(millisecondsTimeout=" + millisecondsTimeout.Value + ") ");

                return false;
            }

            return true;
        }
        #endregion

        #region WriteLock
        /// <summary>
        /// WriteLock
        /// </summary>
        /// <param name="target"></param>
        /// <param name="closure"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static bool Write(this ReaderWriterLockSlim target, Action closure, int millisecondsTimeout)
        {
            return Write(target, closure, millisecondsTimeout, true);
        }

        public static bool Write(this ReaderWriterLockSlim target, Action closure)
        {
            return Write(target, closure, null, true);
        }

        public static bool Write(this ReaderWriterLockSlim target, Action closure, int? millisecondsTimeout, bool throwsOnTimeout)
        {
            Contract.Requires<ArgumentNullException>(closure != null);
            Contract.Requires<ArgumentOutOfRangeException>(
                millisecondsTimeout == null || millisecondsTimeout >= 0
            );

            bool lockHeld = false;
            try
            {
                lockHeld = target.EnterWriteLock(millisecondsTimeout, throwsOnTimeout);
                closure();
            }
            finally
            {
                if (lockHeld)
                    target.ExitWriteLock();
            }

            return lockHeld;
        }


        private static bool EnterWriteLock(this ReaderWriterLockSlim target, int? millisecondsTimeout, bool throwsOnTimeout)
        {
            if (millisecondsTimeout == null)
                target.EnterWriteLock();
            else if (!target.TryEnterWriteLock(millisecondsTimeout.Value))
            {
                if (throwsOnTimeout)
                    throw new TimeoutException(
                        "Could not gain a write lock within the timeout specified. " +
                        "(millisecondsTimeout=" + millisecondsTimeout.Value + ") ");

                return false;
            }

            return true;
        }
        #endregion

        #region Dictionary  
         
        #endregion

        #region Common
        public static string IfNotNullOrEmpty(this string source, string nullOrEmptyReturn)
        {
            if (string.IsNullOrEmpty(source)) return nullOrEmptyReturn;

            return source;
        }

        public static string IfLengthLessThan(this string source,int minLen, string lessThanReturn)
        {
            if (string.IsNullOrEmpty(source)) return lessThanReturn;
            if (source.Length < minLen) return lessThanReturn;

            return source;
        }
        #endregion
    }
 
}
