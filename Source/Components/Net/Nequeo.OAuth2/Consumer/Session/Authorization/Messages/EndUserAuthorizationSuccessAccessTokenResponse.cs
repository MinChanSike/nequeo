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

namespace Nequeo.Net.OAuth2.Consumer.Session.Authorization.Messages
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    using Nequeo.Net.Core.Messaging;
    using Nequeo.Net.Core.Messaging.Reflection;
    using Nequeo.Net.OAuth2.Framework;
    using Nequeo.Net.OAuth2.Framework.Utility;
    using Nequeo.Net.OAuth2.Framework.ChannelElements;
    using Nequeo.Net.OAuth2.Framework.Messages;
    using Nequeo.Net.OAuth2.Consumer.Session.Authorization.ChannelElements;

    /// <summary>
    /// The message sent by the Authorization Server to the Client via the user agent
    /// to indicate that user authorization was granted, carrying only an access token,
    /// and to return the user to the Client where they started their experience.
    /// </summary>
    public class EndUserAuthorizationSuccessAccessTokenResponse : EndUserAuthorizationSuccessResponseBase, IAccessTokenIssuingResponse, IHttpIndirectResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EndUserAuthorizationSuccessAccessTokenResponse"/> class.
        /// </summary>
        /// <param name="clientCallback">The URL to redirect to so the client receives the message. This may not be built into the request message if the client pre-registered the URL with the authorization server.</param>
        /// <param name="version">The protocol version.</param>
        internal EndUserAuthorizationSuccessAccessTokenResponse(Uri clientCallback, Version version)
            : base(clientCallback, version)
        {
            this.TokenType = Protocol.AccessTokenTypes.Bearer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EndUserAuthorizationSuccessAccessTokenResponse"/> class.
        /// </summary>
        /// <param name="clientCallback">The URL to redirect to so the client receives the message. This may not be built into the request message if the client pre-registered the URL with the authorization server.</param>
        /// <param name="request">The authorization request from the user agent on behalf of the client.</param>
        internal EndUserAuthorizationSuccessAccessTokenResponse(Uri clientCallback, EndUserAuthorizationRequest request)
            : base(clientCallback, request)
        {
            ((IMessageWithClientState)this).ClientState = request.ClientState;
            this.TokenType = Protocol.AccessTokenTypes.Bearer;
        }

        /// <summary>
        /// Gets or sets the authorization that the token describes.
        /// </summary>
        /// <value></value>
        AccessToken IAccessTokenCarryingRequest.AuthorizationDescription { get; set; }

        /// <summary>
        /// Gets the authorization that the token describes.
        /// </summary>
        IAuthorizationDescription IAuthorizationCarryingRequest.AuthorizationDescription
        {
            get { return ((IAccessTokenCarryingRequest)this).AuthorizationDescription; }
        }

        /// <summary>
        /// Gets a value indicating whether the payload for the message should be included
        /// in the redirect fragment instead of the query string or POST entity.
        /// </summary>
        bool IHttpIndirectResponse.Include301RedirectPayloadInFragment
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the lifetime of the access token.
        /// </summary>
        /// <value>
        /// The lifetime.
        /// </value>
        TimeSpan? IAccessTokenIssuingResponse.Lifetime
        {
            get { return this.Lifetime; }
            set { this.Lifetime = value; }
        }

        /// <summary>
        /// Gets or sets the token type.
        /// </summary>
        /// <value>Usually "bearer".</value>
        /// <remarks>
        /// Described in OAuth 2.0 section 7.1.
        /// </remarks>
        [MessagePart(Protocol.token_type, IsRequired = true)]
        public string TokenType { get; internal set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>The access token.</value>
        [MessagePart(Protocol.access_token, IsRequired = true)]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the scope of the <see cref="AccessToken"/> if one is given; otherwise the scope of the authorization code.
        /// </summary>
        /// <value>The scope.</value>
        [MessagePart(Protocol.scope, IsRequired = false, Encoder = typeof(ScopeEncoder))]
        public new ICollection<string> Scope
        {
            get { return base.Scope; }
            protected set { base.Scope = value; }
        }

        /// <summary>
        /// Gets or sets the lifetime of the authorization.
        /// </summary>
        /// <value>The lifetime.</value>
        [MessagePart(Protocol.expires_in, IsRequired = false, Encoder = typeof(TimespanSecondsEncoder))]
        internal TimeSpan? Lifetime { get; set; }
    }
}
