//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YoutubePlayer.Resx {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("YoutubePlayer.Resx.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        public static string VideoPlayerText {
            get {
                return ResourceManager.GetString("VideoPlayerText", resourceCulture);
            }
        }
        
        public static string AlertText {
            get {
                return ResourceManager.GetString("AlertText", resourceCulture);
            }
        }
        
        public static string OkText {
            get {
                return ResourceManager.GetString("OkText", resourceCulture);
            }
        }
        
        public static string PasteUrlText {
            get {
                return ResourceManager.GetString("PasteUrlText", resourceCulture);
            }
        }
        
        public static string GoText {
            get {
                return ResourceManager.GetString("GoText", resourceCulture);
            }
        }
        
        public static string EnterValidUrlMessage {
            get {
                return ResourceManager.GetString("EnterValidUrlMessage", resourceCulture);
            }
        }
        
        public static string CannotLocatePageMessage {
            get {
                return ResourceManager.GetString("CannotLocatePageMessage", resourceCulture);
            }
        }
        
        public static string AuthorText {
            get {
                return ResourceManager.GetString("AuthorText", resourceCulture);
            }
        }
        
        public static string TitleText {
            get {
                return ResourceManager.GetString("TitleText", resourceCulture);
            }
        }
        
        public static string DurationText {
            get {
                return ResourceManager.GetString("DurationText", resourceCulture);
            }
        }
    }
}
