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
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Nequeo.Data.Enum
{
    /// <summary>
    /// The send data integration mode.
    /// </summary>
    [SerializableAttribute()]
    [DataContractAttribute()]
    public enum IntegrationMode : int
    {
        /// <summary>
        /// Send data to all identities (receivers).
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToReceivers = 0,
        /// <summary>
        /// Send data to all contacts online, based on the unique identifier.
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToContactsOnline = 1,
        /// <summary>
        /// Send data to all contacts, based on the unique identifier.
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToContacts = 2,
        /// <summary>
        /// Send data to all clients.
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToAll = 3,
        /// <summary>
        /// Send data to all clients online.
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToAllOnline = 4,
        /// <summary>
        /// Send data to all contacts that are logged on.
        /// </summary>
        [EnumMemberAttribute()]
        [XmlEnumAttribute()]
        [SoapEnumAttribute()]
        SendToContactsLoggedOn = 5,
    }
}
