﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesignPatterns.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DesignPatterns.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Red Machine;10;50
        ///Blue Machine;1;100
        ///Pink Machine;5;65
        ///Gold Machine;100;1.
        /// </summary>
        internal static string CsvMachines {
            get {
                return ResourceManager.GetString("CsvMachines", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Red Machine;10.01.2022;Winding break;3;400000
        ///Red Machine;14.01.2022;Inter-turn closures;6;100
        ///Red Machine;22.01.2022;Charring and breakdown of the insulation coating;24;200
        ///Blue Machine;01.01.2022;Block contact breakdown;2;20
        ///Blue Machine;06.01.2022;Coil damage;3;30
        ///Pink Machine;16.01.2022;Anchor sticking to the core;9;150
        ///Gold Machine;10.01.2022;Technical inspection;1;0.
        /// </summary>
        internal static string CsvRenovations {
            get {
                return ResourceManager.GetString("CsvRenovations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Machines&gt;
        ///	&lt;Machine&gt;
        ///		&lt;Name&gt;Red Machine&lt;/Name&gt;
        ///		&lt;HourProductivity&gt;10&lt;/HourProductivity&gt;
        ///		&lt;PieceProfit&gt;50&lt;/PieceProfit&gt;
        ///	&lt;/Machine&gt;
        ///	&lt;Machine&gt;
        ///		&lt;Name&gt;Blue Machine&lt;/Name&gt;
        ///		&lt;HourProductivity&gt;1&lt;/HourProductivity&gt;
        ///		&lt;PieceProfit&gt;100&lt;/PieceProfit&gt;
        ///	&lt;/Machine&gt;
        ///	&lt;Machine&gt;
        ///		&lt;Name&gt;Pink Machine&lt;/Name&gt;
        ///		&lt;HourProductivity&gt;5&lt;/HourProductivity&gt;
        ///		&lt;PieceProfit&gt;65&lt;/PieceProfit&gt;
        ///	&lt;/Machine&gt;
        ///	&lt;Machine&gt;
        ///		&lt;Name&gt;Gold Machine&lt;/Name&gt;
        ///		&lt;HourProductivity&gt;100&lt;/HourP [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string XmlMachines {
            get {
                return ResourceManager.GetString("XmlMachines", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Renovations&gt;
        ///	&lt;Renovation&gt;
        ///		&lt;Machine&gt;Red Machine&lt;/Machine&gt;
        ///		&lt;Date&gt;10.01.2022&lt;/Date&gt;
        ///		&lt;Description&gt;Winding break&lt;/Description&gt;
        ///		&lt;HoursDuration&gt;3&lt;/HoursDuration&gt;
        ///		&lt;Cost&gt;40&lt;/Cost&gt;
        ///	&lt;/Renovation&gt;
        ///	&lt;Renovation&gt;
        ///		&lt;Machine&gt;Red Machine&lt;/Machine&gt;
        ///		&lt;Date&gt;14.01.2022&lt;/Date&gt;
        ///		&lt;Description&gt;Inter-turn closures&lt;/Description&gt;
        ///		&lt;HoursDuration&gt;6&lt;/HoursDuration&gt;
        ///		&lt;Cost&gt;100&lt;/Cost&gt;
        ///	&lt;/Renovation&gt;
        ///	&lt;Renovation&gt;
        ///		&lt;Machine&gt;Red Machine&lt;/Machine&gt;
        ///		&lt;Date&gt;22.01.2022 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string XmlRenovations {
            get {
                return ResourceManager.GetString("XmlRenovations", resourceCulture);
            }
        }
    }
}
