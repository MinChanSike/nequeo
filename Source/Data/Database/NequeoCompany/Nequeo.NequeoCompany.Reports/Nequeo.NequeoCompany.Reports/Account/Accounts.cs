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

namespace Nequeo.Report.NequeoCompany.Account
{
    /// <summary>
    /// Account reports
    /// </summary>
    public partial class Accounts : Nequeo.Report.NequeoCompany.Viewer.ViewerControl
    {
        /// <summary>
        /// Show Account report
        /// </summary>
        /// <param name="reportBindingSourceCollection">The report binding source collection.</param>
        public virtual void AccountShow(Nequeo.Model.DataSource.BindingSourceData[] reportBindingSourceCollection)
        {
            // Display the report
            ShowEmbedded(
                reportBindingSourceCollection,
                "Nequeo.Report.NequeoCompany.Account.Accounts.rdlc",
                "Accounts");
        }

        /// <summary>
        /// Create Account binding s ource data
        /// </summary>
        /// <param name="accountID">The accountID value</param>
        /// <returns>The report binding source collection.</returns>
        public virtual Nequeo.Model.DataSource.BindingSourceData[] Account(int accountID = 0)
        {
            // Assign the binding sources
            System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
            bindingSource.DataMember = "Accounts";

            if (accountID == 0)
                bindingSource.DataSource = new Nequeo.DataAccess.NequeoCompany.Data.Extension.Accounts().Select.SelectDataEntities();
            else
                bindingSource.DataSource = new Nequeo.DataAccess.NequeoCompany.Data.Extension.Accounts().Select.SelectDataEntitiesPredicate(u => u.AccountID == accountID);

            // Return the data within the binding source.
            return new Model.DataSource.BindingSourceData[]
            {
                new Model.DataSource.BindingSourceData() { DataSource = bindingSource, DataSourceName = "Accounts", 
                    BindingSourceParameters = new Nequeo.Model.DataSource.BindingSourceParameter[] 
                    {
                        new Nequeo.Model.DataSource.BindingSourceParameter() 
                        { 
                            Name = "ReportTitle", 
                            Value = "Account Details", 
                            ValueType = typeof(String) 
                        },
                    }},
            };
        }
    }
}
