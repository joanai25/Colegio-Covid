﻿#pragma checksum "..\..\..\VentanaModificarAula.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B919ECFE4EE109654572DA777ECB3637DB156792"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ColegioCovid;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ColegioCovid {
    
    
    /// <summary>
    /// VentanaModificarAula
    /// </summary>
    public partial class VentanaModificarAula : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbAula;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeleccionar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombre;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPlanta;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCapacidad;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCerrar;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\VentanaModificarAula.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ColegioCovid;component/ventanamodificaraula.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VentanaModificarAula.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbAula = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.btnSeleccionar = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\VentanaModificarAula.xaml"
            this.btnSeleccionar.Click += new System.Windows.RoutedEventHandler(this.btnSeleccionar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtPlanta = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtCapacidad = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\VentanaModificarAula.xaml"
            this.txtCapacidad.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.validarNumero);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCerrar = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\VentanaModificarAula.xaml"
            this.btnCerrar.Click += new System.Windows.RoutedEventHandler(this.btnCerrar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnModificar = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\VentanaModificarAula.xaml"
            this.btnModificar.Click += new System.Windows.RoutedEventHandler(this.btnMod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

