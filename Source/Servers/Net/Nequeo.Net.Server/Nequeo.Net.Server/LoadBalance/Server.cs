﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2014 http://www.nequeo.com.au/
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
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Nequeo.Net.LoadBalance
{
    /// <summary>
    /// Load balance server.
    /// </summary>
    public class Server : IDisposable
    {
        /// <summary>
        /// Load balance server.
        /// </summary>
        /// <param name="maxClient">The maximun number of connections.</param>
        public Server(int maxClient = 50000)
        {
            _maxClient = maxClient;

            // Initialise the server.
            Init();
        }

        private Nequeo.Net.ProxyServer _serverV6 = null;
        private Nequeo.Net.ProxyServer _serverSecureV6 = null;
        private Nequeo.Net.ProxyServer _serverV4 = null;
        private Nequeo.Net.ProxyServer _serverSecureV4 = null;

        private ConcurrentBag<RemoteServer> _remoteServers = null;
        private AlgorithmType _algorithmType = AlgorithmType.LeastConnections;
        private Nequeo.Net.Data.context _loadServers = null;
        private Nequeo.Net.InterceptItem[] _interceptItems = null;
        private int _maxClient = 50000;

        private object _lockObject = new object();

        /// <summary>
        /// Start the server.
        /// </summary>
        public void Start()
        {
            try
            {
                // Start the server.
                if (_serverV6 != null)
                    _serverV6.StartListeningThread();

                // Start the server.
                if (_serverSecureV6 != null)
                    _serverSecureV6.StartListeningThread();

                // Start the server.
                if (_serverV4 != null)
                    _serverV4.StartListeningThread();

                // Start the server.
                if (_serverSecureV4 != null)
                    _serverSecureV4.StartListeningThread();
            }
            catch (Exception)
            {
                if (_serverV6 != null)
                    _serverV6.Dispose();

                if (_serverSecureV6 != null)
                    _serverSecureV6.Dispose();

                if (_serverV4 != null)
                    _serverV4.Dispose();

                if (_serverSecureV4 != null)
                    _serverSecureV4.Dispose();

                _serverV6 = null;
                _serverSecureV6 = null;
                _serverV4 = null;
                _serverSecureV4 = null;
                throw;
            }
        }

        /// <summary>
        /// Stop the server.
        /// </summary>
        public void Stop()
        {
            try
            {
                // Stop the server.
                if (_serverV6 != null)
                    _serverV6.StopListeningThread();

                // Stop the server.
                if (_serverSecureV6 != null)
                    _serverSecureV6.StopListeningThread();

                // Stop the server.
                if (_serverV4 != null)
                    _serverV4.StopListeningThread();

                // Stop the server.
                if (_serverSecureV4 != null)
                    _serverSecureV4.StopListeningThread();
            }
            catch { }
            finally
            {
                if (_serverV6 != null)
                    _serverV6.Dispose();

                if (_serverSecureV6 != null)
                    _serverSecureV6.Dispose();

                if (_serverV4 != null)
                    _serverV4.Dispose();

                if (_serverSecureV4 != null)
                    _serverSecureV4.Dispose();

                _serverV6 = null;
                _serverSecureV6 = null;
                _serverV4 = null;
                _serverSecureV4 = null;
            }
        }

        /// <summary>
        /// Initialise the server.
        /// </summary>
        private void Init()
        {
            try
            {
                // Get the data.
                _remoteServers = new ConcurrentBag<RemoteServer>();
                _loadServers = Data.Helper.GetLoadBalanceServer();

                // For each load balance server in the file
                // add to the remote server collection.
                foreach (Nequeo.Net.Data.contextServer item in _loadServers.servers)
                {
                    // Add the remote server.
                    _remoteServers.Add(
                        new RemoteServer()
                        {
                            Name = item.name,
                            Host = item.host,
                            Port = item.port,
                            Secure = item.secure
                        }
                    );
                }

                // Get the certificate reader.
                Nequeo.Security.Configuration.Reader certificateReader = new Nequeo.Security.Configuration.Reader();
                Nequeo.Net.Configuration.Reader hostReader = new Nequeo.Net.Configuration.Reader();

                string socketProviderHostPrefix = "LoadBalance_";
                string hostProviderFullName = socketProviderHostPrefix + "SocketProviderV6";
                string hostProviderFullNameSecure = socketProviderHostPrefix + "SocketProviderV6Ssl";

                // Start the server.
                _serverV6 = new Nequeo.Net.ProxyServer(System.Net.IPAddress.IPv6Any, hostReader.GetServerHost(hostProviderFullName).Port, _remoteServers, _algorithmType);
                _serverV6.Name = "Load Balance Server";
                _serverV6.ServiceName = "LoadBalanceServer";
                _serverV6.InterceptItems = _interceptItems;
                _serverV6.Timeout = hostReader.GetServerHost(hostProviderFullName).ClientTimeOut;
                _serverV6.ReadBufferSize = 32768;
                _serverV6.WriteBufferSize = 32768;
                _serverV6.ResponseBufferCapacity = 10000000;
                _serverV6.RequestBufferCapacity = 10000000;

                // Start the server.
                _serverV4 = new Nequeo.Net.ProxyServer(System.Net.IPAddress.Any, hostReader.GetServerHost(hostProviderFullName).Port, _remoteServers, _algorithmType);
                _serverV4.Name = "Load Balance Server";
                _serverV4.ServiceName = "LoadBalanceServer";
                _serverV4.InterceptItems = _interceptItems;
                _serverV4.Timeout = hostReader.GetServerHost(hostProviderFullName).ClientTimeOut;
                _serverV4.ReadBufferSize = 32768;
                _serverV4.WriteBufferSize = 32768;
                _serverV4.ResponseBufferCapacity = 10000000;
                _serverV4.RequestBufferCapacity = 10000000;

                // Start the server.
                _serverSecureV6 = new Nequeo.Net.ProxyServer(System.Net.IPAddress.IPv6Any, hostReader.GetServerHost(hostProviderFullNameSecure).Port, _remoteServers, _algorithmType);
                _serverSecureV6.Name = "Load Balance Server";
                _serverSecureV6.ServiceName = "LoadBalanceServer";
                _serverSecureV6.InterceptItems = _interceptItems;
                _serverSecureV6.Timeout = hostReader.GetServerHost(hostProviderFullNameSecure).ClientTimeOut;
                _serverSecureV6.ReadBufferSize = 32768;
                _serverSecureV6.WriteBufferSize = 32768;
                _serverSecureV6.ResponseBufferCapacity = 10000000;
                _serverSecureV6.RequestBufferCapacity = 10000000;

                // Start the server.
                _serverSecureV4 = new Nequeo.Net.ProxyServer(System.Net.IPAddress.Any, hostReader.GetServerHost(hostProviderFullNameSecure).Port, _remoteServers, _algorithmType);
                _serverSecureV4.Name = "Load Balance Server";
                _serverSecureV4.ServiceName = "LoadBalanceServer";
                _serverSecureV4.InterceptItems = _interceptItems;
                _serverSecureV4.Timeout = hostReader.GetServerHost(hostProviderFullNameSecure).ClientTimeOut;
                _serverSecureV4.ReadBufferSize = 32768;
                _serverSecureV4.WriteBufferSize = 32768;
                _serverSecureV4.ResponseBufferCapacity = 10000000;
                _serverSecureV4.RequestBufferCapacity = 10000000;

                try
                {
                    // Look for the certificate information in the configuration file.

                    // Get the certificate if any.
                    X509Certificate2 serverCertificate = certificateReader.GetServerCredentials();

                    // If a certificate exists.
                    if (serverCertificate != null)
                    {
                        // Get the secure servers.
                        _serverSecureV6.UseSslConnection = true;
                        _serverSecureV6.X509Certificate = serverCertificate;
                        _serverSecureV4.UseSslConnection = true;
                        _serverSecureV4.X509Certificate = serverCertificate;
                    }
                }
                catch { }
            }
            catch (Exception)
            {
                if (_serverV6 != null)
                    _serverV6.Dispose();

                if (_serverSecureV6 != null)
                    _serverSecureV6.Dispose();

                if (_serverV4 != null)
                    _serverV4.Dispose();

                if (_serverSecureV4 != null)
                    _serverSecureV4.Dispose();

                _serverV6 = null;
                _serverSecureV6 = null;
                _serverV4 = null;
                _serverSecureV4 = null;
                throw;
            }
        }

        #region Dispose Object Methods
        /// <summary>
        /// Track whether Dispose has been called.
        /// </summary>
        private bool _disposed = false;

        /// <summary>
        /// Implement IDisposable.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.  If disposing
        /// equals true, the method has been called directly or indirectly by a user's
        /// code. Managed and unmanaged resources can be disposed.  If disposing equals
        /// false, the method has been called by the runtime from inside the finalizer
        /// and you should not reference other objects. Only unmanaged resources can
        /// be disposed.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // Note disposing has been done.
                _disposed = true;

                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    if (_serverV6 != null)
                        _serverV6.Dispose();

                    if (_serverSecureV6 != null)
                        _serverSecureV6.Dispose();

                    if (_serverV4 != null)
                        _serverV4.Dispose();

                    if (_serverSecureV4 != null)
                        _serverSecureV4.Dispose();
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                _serverV6 = null;
                _serverSecureV6 = null;
                _serverV4 = null;
                _serverSecureV4 = null;
                _lockObject = null;
            }
        }

        /// <summary>
        /// Use C# destructor syntax for finalization code.
        /// This destructor will run only if the Dispose method
        /// does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        /// </summary>
        ~Server()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }
        #endregion
    }
}
