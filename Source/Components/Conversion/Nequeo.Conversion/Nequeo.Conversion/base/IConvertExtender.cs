﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2010 http://www.nequeo.com.au/
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
using System.Linq;
using System.Text;
using System.IO;

using Nequeo.Model.Conversion;

namespace Nequeo.Conversion
{
    /// <summary>
    /// Conversion extender interface
    /// </summary>
    public interface IConvertExtender
    {
        /// <summary>
        /// Write the data to the file.
        /// </summary>
        /// <param name="data">The data to be written.</param>
        /// <param name="fileName">The file name and path where the data is to be written.</param>
        /// <returns>True is all data has been written else false.</returns>
        bool Write(List<TransformModel[]> data, string fileName);

        /// <summary>
        /// Write the data to the file stream.
        /// </summary>
        /// <param name="data">The data to be written.</param>
        /// <param name="fileStream">The file stream where the data is to be written.</param>
        /// <returns>True is all data has been written else false.</returns>
        bool Write(List<TransformModel[]> data, FileStream fileStream);

        /// <summary>
        /// Write the data to the memory stream.
        /// </summary>
        /// <param name="data">The data to be written.</param>
        /// <param name="memoryStream">The memory stream where the data is to be written.</param>
        /// <returns>True is all data has been written else false.</returns>
        bool Write(List<TransformModel[]> data, MemoryStream memoryStream);

        /// <summary>
        /// Read all the data from the file.
        /// </summary>
        /// <param name="fileName">The file name and path where the data is to be read from.</param>
        /// <returns>The collection of data.</returns>
        List<TransformModel[]> ReadAllLines(string fileName);

        /// <summary>
        /// Read the data from the file.
        /// </summary>
        /// <param name="fileName">The file name and path where the data is to be read from.</param>
        /// <returns>The collection of data.</returns>
        List<TransformModel[]> Read(string fileName);

        /// <summary>
        /// Read the data from the file stream.
        /// </summary>
        /// <param name="fileStream">The file stream where the data is to be read from.</param>
        /// <returns>The collection of data.</returns>
        List<TransformModel[]> Read(FileStream fileStream);

        /// <summary>
        /// Read the data from the memory stream.
        /// </summary>
        /// <param name="memoryStream">The memory stream where the data is to be read from.</param>
        /// <returns>The collection of data.</returns>
        List<TransformModel[]> Read(MemoryStream memoryStream);
    }
}