﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dlech.SshAgentLib.WinForms {
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
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("dlech.SshAgentLib.WinForms.Strings", typeof(Strings).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} has requested to use the SSH key &apos;{1}&apos; with fingerprint {2}.
        ///
        ///Do you want to allow this?.
        /// </summary>
        public static string askConfirmKey {
            get {
                return ResourceManager.GetString("askConfirmKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Another application.
        /// </summary>
        public static string askConfirmKeyUnknownProcess {
            get {
                return ResourceManager.GetString("askConfirmKeyUnknownProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Agent failure.
        /// </summary>
        public static string errAddKeyFailed {
            get {
                return ResourceManager.GetString("errAddKeyFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File &apos;{0}&apos; failed with error: {1}.
        /// </summary>
        public static string errFileOpenFailed {
            get {
                return ResourceManager.GetString("errFileOpenFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error getting key list.
        /// </summary>
        public static string errListKeysFailed {
            get {
                return ResourceManager.GetString("errListKeysFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Locking failed.
        /// </summary>
        public static string errLockFailed {
            get {
                return ResourceManager.GetString("errLockFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pageant is already running. Application will now close..
        /// </summary>
        public static string errPageantRunning {
            get {
                return ResourceManager.GetString("errPageantRunning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Removing key {0} failed.
        /// </summary>
        public static string errRemoveFailed {
            get {
                return ResourceManager.GetString("errRemoveFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unlocking failed.
        /// </summary>
        public static string errUnlockFailed {
            get {
                return ResourceManager.GetString("errUnlockFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All Files.
        /// </summary>
        public static string filterAllFiles {
            get {
                return ResourceManager.GetString("filterAllFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PuTTY Private Key Files.
        /// </summary>
        public static string filterPuttyPrivateKeyFiles {
            get {
                return ResourceManager.GetString("filterPuttyPrivateKeyFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Click &apos;Refresh&apos; to load keys.
        /// </summary>
        public static string keyInfoViewClickRefresh {
            get {
                return ResourceManager.GetString("keyInfoViewClickRefresh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Locked.
        /// </summary>
        public static string keyInfoViewLocked {
            get {
                return ResourceManager.GetString("keyInfoViewLocked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No Keys Loaded.
        /// </summary>
        public static string keyInfoViewNoKeys {
            get {
                return ResourceManager.GetString("keyInfoViewNoKeys", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to lock using an empty passphrase?.
        /// </summary>
        public static string keyManagerAreYouSureLockPassphraseEmpty {
            get {
                return ResourceManager.GetString("keyManagerAreYouSureLockPassphraseEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comment.
        /// </summary>
        public static string keyManagerCommentColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerCommentColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C.
        /// </summary>
        public static string keyManagerConfirmColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerConfirmColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm Constraint.
        /// </summary>
        public static string keyManagerConfirmColumnHeaderToolTip {
            get {
                return ResourceManager.GetString("keyManagerConfirmColumnHeaderToolTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fingerprint.
        /// </summary>
        public static string keyManagerFingerprintColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerFingerprintColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to L.
        /// </summary>
        public static string keyManagerLifetimeColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerLifetimeColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lifetime Constraint.
        /// </summary>
        public static string keyManagerLifetimeColumnHeaderToolTip {
            get {
                return ResourceManager.GetString("keyManagerLifetimeColumnHeaderToolTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Size.
        /// </summary>
        public static string keyManagerSizeHeaderColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerSizeHeaderColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type.
        /// </summary>
        public static string keyManagerTypeColumnHeaderText {
            get {
                return ResourceManager.GetString("keyManagerTypeColumnHeaderText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter passphrase for {0}.
        /// </summary>
        public static string msgEnterPassphrase {
            get {
                return ResourceManager.GetString("msgEnterPassphrase", resourceCulture);
            }
        }
    }
}
