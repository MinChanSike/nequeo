﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 10.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Nequeo.Net.Http.PostBackService.Data.NotesFormService
{
    using System;
    
    
    #line 1 "C:\Development\VisualStudio2010\Nequeo\Client-Servers\Server\Http\Service\Nequeo.Net.Http.PostBackService\Nequeo.Net.Http.PostBackService\Data\NotesFormService\notes.htm"
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public partial class notes : notesBase
    {
        public virtual string TransformText()
        {
            this.Write("<!--");
            this.Write("-->\r\n<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\r\n<html>\r\n\t<he" +
                    "ad>\r\n\t\t<title>Nequeo Custom Notes</title>\r\n        <link href=\"http://www.nequeo" +
                    ".net.au/jquery/jquery-ui-1.8.23/css/overcast/jquery-ui-1.8.23.css\" rel=\"styleshe" +
                    "et\" type=\"text/css\"/>\r\n        <script type=\"text/javascript\" src=\"http://www.ne" +
                    "queo.net.au/jquery/jquery-ui-1.8.23/js/jquery-1.8.0.min.js\"></script>\r\n        <" +
                    "script type=\"text/javascript\" src=\"http://www.nequeo.net.au/jquery/jquery-ui-1.8" +
                    ".23/js/jquery-ui-1.8.23.min.js\"></script>\r\n        <script type=\"text/javascript" +
                    "\">\r\n            $(document).ready(function () {\r\n                $(\"#NoteDate\")." +
                    "datepicker\r\n                ( \r\n                    { \r\n                        " +
                    "dateFormat: \'dd/mm/yy\',\r\n                        showButtonPanel: true,\r\n       " +
                    "                 changeMonth: true,\r\n                        changeYear: true,\r\n" +
                    "                        showWeek: true,\r\n                        firstDay: 1,\r\n " +
                    "                       showAnim: \'show\'\r\n                    }\r\n                " +
                    ");\r\n            });\r\n        </script>\r\n        <style type=\"text/css\" >\r\n      " +
                    "      /*input.date_style { font-size:200%; }*/\r\n            input.submit_style {" +
                    " width:150px; }\r\n            div.ui-datepicker { font-size:12px; } \r\n        </s" +
                    "tyle>\r\n\t</head>\r\n\t<body>\r\n        <form name=\"NotesForm\" action=\"notes.htm\" enct" +
                    "ype=\"multipart/form-data\" method=\"post\">\r\n            <div style=\"display:block;" +
                    "width:600px;\">\r\n                <div style=\"display:inline-block;width:550px;hei" +
                    "ght:30px;\">\r\n                    <span style=\"display:inline-block;width:520px;\"" +
                    ">\r\n                        <span style=\"display:inline-block;width:200px;float:l" +
                    "eft;vertical-align:bottom;\">Note Name :</span>\r\n                        <input t" +
                    "ype=\"text\" id=\"NoteName\" name=\"NoteName\" value=\"NoteName\" style=\"display:inline-" +
                    "block;width:300px;float:left;vertical-align:bottom;\" />\r\n                    </s" +
                    "pan>\r\n                </div>\r\n                <div style=\"display:inline-block;w" +
                    "idth:550px;height:30px;\">\r\n                    <span style=\"display:inline-block" +
                    ";width:520px;\">\r\n                        <span style=\"display:inline-block;width" +
                    ":200px;float:left;vertical-align:bottom;\">Date :</span>\r\n                       " +
                    " <input class=\"date_style\" type=\"text\" id=\"NoteDate\" name=\"NoteDate\" value=\"01/0" +
                    "1/01\" style=\"display:inline-block;width:100px;float:left;vertical-align:bottom;\"" +
                    " />\r\n                    </span>\r\n                </div>\r\n                <div s" +
                    "tyle=\"display:inline-block;width:550px;height:30px;\">\r\n                    <span" +
                    " style=\"display:inline-block;width:520px;\">\r\n                        <span style" +
                    "=\"display:inline-block;width:200px;float:left;vertical-align:bottom;\">Context :<" +
                    "/span>\r\n                        <input type=\"text\" id=\"ContextName\" name=\"Contex" +
                    "tName\" value=\"ContextName\" style=\"display:inline-block;width:200px;float:left;ve" +
                    "rtical-align:bottom;\" />\r\n                    </span>\r\n                </div>\r\n " +
                    "               <div style=\"display:inline-block;width:550px;\">\r\n                " +
                    "    <span style=\"display:inline-block;width:520px;\">\r\n                        <s" +
                    "pan style=\"display:inline-block;width:200px;float:left;vertical-align:bottom;\">N" +
                    "ote :</span>\r\n                        <textarea id=\"NoteData\" name=\"NoteData\" co" +
                    "ls=\"20\" rows=\"10\" style=\"display:inline-block;width:300px;float:left;vertical-al" +
                    "ign:bottom;\">value=\"NoteData\"</textarea>\r\n                    </span>\r\n         " +
                    "       </div>\r\n            </div>\r\n            <div style=\"display:block;width:6" +
                    "00px;\">\r\n                <div style=\"display:inline-block;height:30px; width:200" +
                    "px\">\r\n                    <input class=\"submit_style\" type=\"submit\" value=\"Send " +
                    "Note\" >\r\n        \t    </div>\r\n                <div style=\"display:inline-block;h" +
                    "eight:30px;\">\r\n                </div>\r\n            </div>\r\n        </form>\r\n\t</b" +
                    "ody>\r\n</html>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class notesBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
