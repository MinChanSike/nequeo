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
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.ServiceModel;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace Nequeo.Security
{
    /// <summary>
    /// Validates a username and password.
    /// </summary>
    public class ServiceUserNamePasswordValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// Validates a username and password.
        /// </summary>
        /// <param name="provider">The authentication provider.</param>
        public ServiceUserNamePasswordValidator(IAuthorisationProvider provider)
        {
            // Get the validate value.
            if (provider == null)
                throw new ArgumentNullException(nameof(provider));

            _provider = provider;
        }

        private IAuthorisationProvider _provider = null;

        /// <summary>
        /// Validates the specified username and password.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        public override void Validate(string userName, string password)
        {
            bool ret = false;

            // If a provider has been specified.
            if (_provider != null)
            {
                // Create a new user.
                UserCredentials user = new UserCredentials();
                user.Username = userName;
                user.Password = password;
                user.SecurePassword = new SecureText().GetSecureText(password);
                user.ApplicationName = "All";

                // Attempt to authenticate the user.
                ret = _provider.AuthenticateUser(user);
            }

            // If not valid then throw.
            if (!ret)
                throw new SecurityTokenException("Unknown Username or Incorrect Password");
        }
    }
}
