namespace DataProvider
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public sealed class Provider : IEnumerable<byte>
    {
        // 8 * 1024 = 8192 * 16 = 131072
        private const int InitialCapacity = 131072;
        private int capacity;

        private Provider() {}

        /// <summary>
        /// Get an instance of provider by data type
        /// </summary>
        /// <typeparam name="T">Data-type provided by current instance</typeparam>
        /// <param name="dataType">initial data</param>
        /// <returns></returns>
        public Provider GetInstance<T>(T dataType)
        {
            // TODO: Implement providing data ...
            throw new NotImplementedException();
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (byte @byte in this)
            {
                yield return @byte;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}