#pragma checksum "..\..\..\VentaDePasajes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "81143227A311C10E6D9E693158C58438"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Vistas {
    
    
    /// <summary>
    /// VentaDePasajes
    /// </summary>
    public partial class VentaDePasajes : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\VentaDePasajes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb1;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\VentaDePasajes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrll;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\VentaDePasajes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grid1;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\VentaDePasajes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapPanel1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\VentaDePasajes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapPanel2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vistas;component/ventadepasajes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentaDePasajes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\VentaDePasajes.xaml"
            ((Vistas.VentaDePasajes)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\VentaDePasajes.xaml"
            ((Vistas.VentaDePasajes)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmb1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 7 "..\..\..\VentaDePasajes.xaml"
            this.cmb1.Loaded += new System.Windows.RoutedEventHandler(this.cmb1_Loaded);
            
            #line default
            #line hidden
            
            #line 7 "..\..\..\VentaDePasajes.xaml"
            this.cmb1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmb1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.scrll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 4:
            this.grid1 = ((System.Windows.Controls.Grid)(target));
            
            #line 9 "..\..\..\VentaDePasajes.xaml"
            this.grid1.Loaded += new System.Windows.RoutedEventHandler(this.grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            this.wrapPanel1 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 6:
            this.wrapPanel2 = ((System.Windows.Controls.WrapPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

