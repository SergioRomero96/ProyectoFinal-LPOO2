#pragma checksum "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9FEDBA6F970F10A332CBFCB436A854BF"
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


namespace Vistas.CRUD.Ciudades {
    
    
    /// <summary>
    /// ViewAltaCiudad
    /// </summary>
    public partial class ViewAltaCiudad : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbAddCity;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label codeAddCity;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCodeAddCity;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nameAddCity;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNameAddCity;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddCity;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelCity;
        
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
            System.Uri resourceLocater = new System.Uri("/Vistas;component/crud/ciudades/viewaltaciudad.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
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
            
            #line 4 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
            ((Vistas.CRUD.Ciudades.ViewAltaCiudad)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gbAddCity = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.codeAddCity = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtCodeAddCity = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
            this.txtCodeAddCity.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtCodeAddCity_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.nameAddCity = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtNameAddCity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnAddCity = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
            this.btnAddCity.Click += new System.Windows.RoutedEventHandler(this.btnAddCity_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnCancelCity = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\CRUD\Ciudades\ViewAltaCiudad.xaml"
            this.btnCancelCity.Click += new System.Windows.RoutedEventHandler(this.btnCancelCity_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

