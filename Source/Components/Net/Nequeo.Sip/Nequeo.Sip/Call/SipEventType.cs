﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2015 http://www.nequeo.com.au/
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
using System.Threading.Tasks;

namespace Nequeo.Net.Sip
{
    /// <summary>
    /// Sip event type.
    /// </summary>
    public enum SipEventType
    {
        /// <summary>
        /// Unidentified event. 
        /// </summary>
        PJSIP_EVENT_UNKNOWN,
        /// <summary> 
        /// Timer event, normally only used internally in transaction. 
        /// </summary>
        PJSIP_EVENT_TIMER,
        /// <summary> 
        /// Message transmission event. 
        /// </summary>
        PJSIP_EVENT_TX_MSG,
        /// <summary> 
        /// Message received event. 
        /// </summary>
        PJSIP_EVENT_RX_MSG,
        /// <summary> 
        /// Transport error event. 
        /// </summary>
        PJSIP_EVENT_TRANSPORT_ERROR,
        /// <summary>
        /// Transaction state changed event. 
        /// </summary>
        PJSIP_EVENT_TSX_STATE,
        /// <summary>
        /// Indicates that the event was triggered by user action. 
        /// </summary>
        PJSIP_EVENT_USER
    }
}
