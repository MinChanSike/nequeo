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

using Nequeo.Data.Control;
using Nequeo.DataAccess.NequeoCompany;

namespace Nequeo.Logic.NequeoCompany.Asset
{
    /// <summary>
    /// Complete data Assets logic control
    /// </summary>
    public partial interface IAssets
    {
        /// <summary>
        /// Gets the asset data extension implementation.
        /// </summary>
        DataAssetExtender Extension { get; }

        /// <summary>
        /// Gets the asset category data extension implementation.
        /// </summary>
        DataAssetCategoryExtender Extension1 { get; }

        /// <summary>
        /// Gets the asset report extension implementation.
        /// </summary>
        ReportAssetExtender ReportExtension { get; }
    }

    /// <summary>
    /// Complete data asset logic control
    /// </summary>
    public partial class Assets : DataAssetExtender,
        Data.Control.IExtension<
            DataAssetExtender,
            DataAssetCategoryExtender>,
        Report.Common.IReportExtension<ReportAssetExtender>
    {
        /// <summary>
        /// Gets the asset data extension implementation.
        /// </summary>
        public virtual DataAssetExtender Extension
        {
            get { return new DataAssetExtender(); }
        }

        /// <summary>
        /// Gets the asset category data extension implementation.
        /// </summary>
        public virtual DataAssetCategoryExtender Extension1
        {
            get { return new DataAssetCategoryExtender(); }
        }

        /// <summary>
        /// Gets the asset report extension implementation.
        /// </summary>
        public virtual ReportAssetExtender ReportExtension
        {
            get { return new ReportAssetExtender(); }
        }
    }
}