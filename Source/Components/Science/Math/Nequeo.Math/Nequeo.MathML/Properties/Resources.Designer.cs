﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nequeo.MathML.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Nequeo.MathML.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to &lt;xsl:stylesheet
        ///  version=&quot;1.0&quot;
        ///  xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;
        ///  xmlns:mml=&quot;http://www.w3.org/1998/Math/MathML&quot;
        ///&gt;
        ///
        ///  &lt;!--
        ///$Id: ctop.xsl,v 1.3 2002/09/20 08:41:39 davidc Exp $
        ///
        ///Copyright David Carlisle 2001, 2002.
        ///
        ///Use and distribution of this code are permitted under the terms of the &lt;a
        ///href=&quot;http://www.w3.org/Consortium/Legal/copyright-software-19980720&quot;
        ///&gt;W3C Software Notice and License&lt;/a&gt;.
        ///--&gt;
        ///
        ///  &lt;xsl:output method=&quot;xml&quot; /&gt;
        ///
        ///  &lt;xsl:template mode=&quot;c2p&quot; match=&quot;*&quot;&gt;
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ctop {
            get {
                return ResourceManager.GetString("ctop", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;xsl:stylesheet version=&quot;1.0&quot; xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;&gt;
        ///
        ///  &lt;xsl:output method=&quot;xml&quot; /&gt;
        ///  &lt;xsl:template match=&quot;math&quot;&gt;
        ///    &lt;math&gt;
        ///      &lt;xsl:apply-templates/&gt;
        ///    &lt;/math&gt;
        ///  &lt;/xsl:template&gt;
        ///
        ///  &lt;!-- 4.4.1.1 cn --&gt;
        ///
        ///  &lt;xsl:template match=&quot;cn&quot;&gt;
        ///    &lt;mn&gt;
        ///      &lt;xsl:apply-templates/&gt;
        ///    &lt;/mn&gt;
        ///  &lt;/xsl:template&gt;
        ///
        ///  &lt;xsl:template match=&quot;cn[@type=&apos;complex-cartesian&apos;]&quot;&gt;
        ///    &lt;mrow&gt;
        ///      &lt;mn&gt;
        ///        &lt;xsl:apply-templates select=&quot;text()[1]&quot;/&gt;
        ///      &lt;/mn&gt;
        ///      &lt;mo&gt;+&lt;/mo&gt;
        ///    [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ctopML {
            get {
                return ResourceManager.GetString("ctopML", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///&lt;xsl:stylesheet
        ///  version=&quot;1.0&quot;
        ///  xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;
        ///  xmlns:msxsl=&quot;urn:schemas-microsoft-com:xslt&quot;
        ///  xmlns:fns=&quot;http://www.w3.org/2002/Math/preference&quot;
        ///  xmlns:mml=&quot;http://www.w3.org/1998/Math/MathML&quot;
        ///  extension-element-prefixes=&quot;msxsl fns&quot;
        ///&gt;
        ///
        ///&lt;!--
        ///Copyright David Carlisle 2001, 2002.
        ///
        ///Use and distribution of this code are permitted under the terms of the &lt;a
        ///href=&quot;http://www.w3.org/Consortium/Legal/copyright-software-19980720&quot;
        ///&gt;W3C Software Notice and License&lt; [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string mathml {
            get {
                return ResourceManager.GetString("mathml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot;?&gt;
        ///
        ///&lt;!-- ******************************************************** --&gt;
        ///&lt;!--  XSL Transform of MathML content to MathML presentation  --&gt;
        ///&lt;!--             Version 1.0 RC2 from 13-Jun-2003             --&gt;
        ///&lt;!--                                                          --&gt;
        ///&lt;!--    Complies with the W3C MathML 2.0 Recommenation of     --&gt;
        ///&lt;!--                    21 February 2001.                     --&gt;
        ///&lt;!--                                                          --&gt;
        ///&lt;!--   Authors Igo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string mmlctop2_0 {
            get {
                return ResourceManager.GetString("mmlctop2_0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;xsl:stylesheet
        ///  version=&quot;1.0&quot;
        ///  xmlns:xsl=&quot;http://www.w3.org/1999/XSL/Transform&quot;
        ///  xmlns:mml=&quot;http://www.w3.org/1998/Math/MathML&quot;
        ///  xmlns:h=&quot;http://www.w3.org/1999/xhtml&quot;
        ///  xmlns=&quot;http://www.w3.org/1999/xhtml&quot;
        ///  xmlns:msxsl=&quot;urn:schemas-microsoft-com:xslt&quot;
        ///  xmlns:fns=&quot;http://www.w3.org/2002/Math/preference&quot;
        ///  xmlns:doc=&quot;http://www.dcarlisle.demon.co.uk/xsldoc&quot;
        ///  xmlns:ie5=&quot;http://www.w3.org/TR/WD-xsl&quot;
        ///  exclude-result-prefixes=&quot;h ie5 fns msxsl fns doc&quot;
        ///  extension-element-prefixes=&quot;msxsl fns doc&quot;
        ///&gt;
        ///
        ///  &lt;! [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string pmathml {
            get {
                return ResourceManager.GetString("pmathml", resourceCulture);
            }
        }
    }
}