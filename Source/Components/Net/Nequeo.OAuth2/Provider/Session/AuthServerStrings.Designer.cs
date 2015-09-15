﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.Net.OAuth2.Provider.Session {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AuthServerStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AuthServerStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Nequeo.Net.OAuth2.Provider.Session.AuthServerStrings", typeof(AuthServerStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The requested access scope exceeds the grant scope..
        /// </summary>
        internal static string AccessScopeExceedsGrantScope {
            get {
                return ResourceManager.GetString("AccessScopeExceedsGrantScope", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The callback URL ({0}) is not allowed for this client..
        /// </summary>
        internal static string ClientCallbackDisallowed {
            get {
                return ResourceManager.GetString("ClientCallbackDisallowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure looking up secret for client or token..
        /// </summary>
        internal static string ClientOrTokenSecretNotFound {
            get {
                return ResourceManager.GetString("ClientOrTokenSecretNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The client secret was incorrect..
        /// </summary>
        internal static string ClientSecretMismatch {
            get {
                return ResourceManager.GetString("ClientSecretMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid resource owner password credential..
        /// </summary>
        internal static string InvalidResourceOwnerPasswordCredential {
            get {
                return ResourceManager.GetString("InvalidResourceOwnerPasswordCredential", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No callback URI was available for this request..
        /// </summary>
        internal static string NoCallback {
            get {
                return ResourceManager.GetString("NoCallback", resourceCulture);
            }
        }
    }
}
