﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2012 http://www.nequeo.com.au/
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
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.IO;

using Nequeo.Cryptography.Signing;
using Nequeo.Net.OAuth.Framework.Utility;

namespace Nequeo.Net.OAuth.Framework.Signing
{
    /// <summary>
    /// OAuth context signer
    /// </summary>
    public class OAuthContextSigner : IOAuthContextSigner
    {
        /// <summary>
        /// OAuth context signer
        /// </summary>
        /// <param name="implementations">The collection of context signature implementations</param>
        public OAuthContextSigner(params IContextSignature[] implementations)
        {
            if (implementations != null) _implementations.AddRange(implementations);
        }

        /// <summary>
        /// OAuth context signer
        /// </summary>
        public OAuthContextSigner()
            : this(new RsaSha1Signature(), new HmacSha1Signature(), new PlainTextSignature())
        {
        }

        private readonly List<IContextSignature> _implementations = new List<IContextSignature>();

        /// <summary>
        /// Sign the current OAuth context.
        /// </summary>
        /// <param name="authContext">The OAuth context.</param>
        /// <param name="signingContext">The signing context.</param>
        public void SignContext(IOAuthContext authContext, SigningContext signingContext)
        {
            signingContext.SignatureBase = authContext.GenerateSignatureBase();
            FindImplementationForAuthContext(authContext).SignContext(authContext, signingContext);
        }

        /// <summary>
        /// Validate the OAuth signature.
        /// </summary>
        /// <param name="authContext">The OAuth context.</param>
        /// <param name="signingContext">The signing context.</param>
        /// <returns>True if valid; else false.</returns>
        public bool ValidateSignature(IOAuthContext authContext, SigningContext signingContext)
        {
            signingContext.SignatureBase = authContext.GenerateSignatureBase();
            return FindImplementationForAuthContext(authContext).ValidateSignature(authContext, signingContext);
        }

        /// <summary>
        /// Find implementation for auth context
        /// </summary>
        /// <param name="authContext">The OAuth context.</param>
        /// <returns>The context signature</returns>
        IContextSignature FindImplementationForAuthContext(IOAuthContext authContext)
        {
            IContextSignature impl =
                _implementations.FirstOrDefault(i => i.MethodName == authContext.SignatureMethod);

            if (impl != null) return impl;

            // If the signature method is unknown.
            throw Error.UnknownSignatureMethod(authContext.SignatureMethod);
        }
    }
}
