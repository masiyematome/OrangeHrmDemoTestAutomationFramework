//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrangeHrmDemo.Web.resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class config {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal config() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OrangeHrmDemo.Web.resources.config", typeof(config).Assembly);
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
        ///   Looks up a localized string similar to Chrome.
        /// </summary>
        internal static string BrowserName {
            get {
                return ResourceManager.GetString("BrowserName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to https://opensource-demo.orangehrmlive.com/.
        /// </summary>
        internal static string OrangeHrmDemoUrl {
            get {
                return ResourceManager.GetString("OrangeHrmDemoUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to someRandomPassword.
        /// </summary>
        internal static string OrangeHrmInvalidPassword {
            get {
                return ResourceManager.GetString("OrangeHrmInvalidPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to admin123.
        /// </summary>
        internal static string OrangeHrmPassword {
            get {
                return ResourceManager.GetString("OrangeHrmPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Admin.
        /// </summary>
        internal static string OrangeHrmUsername {
            get {
                return ResourceManager.GetString("OrangeHrmUsername", resourceCulture);
            }
        }
    }
}
