﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 * 
 */

#region Nequeo Pty Ltd License
/*
    Permission is hereby granted, free of charge, to any person
    obtaining a copy of this software and associated documentation
    files (the "Software"), to deal in the Software without
    restriction, including without limitation the rights to use,
    copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the
    Software is furnished to do so, subject to the following
    conditions:

    The above copyright notice and this permission notice shall be
    included in all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
    OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Nequeo.Collections
{
    /// <summary>
    /// Provides a thread-safe priority queue data structure.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class LongPriorityQueue<T> : Nequeo.Collections.Concurrent.ConcurrentPriorityQueue<Nequeo.Comparable.LongInteger, T>
    {
        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public LongPriorityQueue(bool useMinHeap = true) : base(useMinHeap) { }

        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new priority queue.</param>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public LongPriorityQueue(IEnumerable<KeyValuePair<Nequeo.Comparable.LongInteger, T>> collection, bool useMinHeap = true) : base(collection, useMinHeap) { }
    }

    /// <summary>
    /// Provides a thread-safe priority queue data structure.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class IntPriorityQueue<T> : Nequeo.Collections.Concurrent.ConcurrentPriorityQueue<Nequeo.Comparable.Integer, T>
    {
        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public IntPriorityQueue(bool useMinHeap = true) : base(useMinHeap) { }

        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new priority queue.</param>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public IntPriorityQueue(IEnumerable<KeyValuePair<Nequeo.Comparable.Integer, T>> collection, bool useMinHeap = true) : base(collection, useMinHeap) { }
    }

    /// <summary>
    /// Provides a thread-safe priority queue data structure.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class ShortPriorityQueue<T> : Nequeo.Collections.Concurrent.ConcurrentPriorityQueue<Nequeo.Comparable.ShortInteger, T>
    {
        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public ShortPriorityQueue(bool useMinHeap = true) : base(useMinHeap) { }

        /// <summary>
        /// Provides a thread-safe priority queue data structure.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new priority queue.</param>
        /// <param name="useMinHeap">Should the min heap or max heap be used.</param>
        public ShortPriorityQueue(IEnumerable<KeyValuePair<Nequeo.Comparable.ShortInteger, T>> collection, bool useMinHeap = true) : base(collection, useMinHeap) { }
    }
}
