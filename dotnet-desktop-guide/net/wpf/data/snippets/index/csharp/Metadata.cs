using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace bindings
{
    class Metadata
    {
        //<print_metadata>
        public static void PrintMetadata()
        {
            // Get the metadata for the property
            PropertyMetadata metadata = TextBox.TextProperty.GetMetadata(typeof(TextBox));

            // Check if metadata type is FrameworkPropertyMetadata
            if (metadata is FrameworkPropertyMetadata frameworkMetadata)
            {
                System.Diagnostics.Debug.WriteLine($"TextBox.Text property metadata:");
                System.Diagnostics.Debug.WriteLine($"  BindsTwoWayByDefault: {frameworkMetadata.BindsTwoWayByDefault}");
                System.Diagnostics.Debug.WriteLine($"  IsDataBindingAllowed: {frameworkMetadata.IsDataBindingAllowed}");
                System.Diagnostics.Debug.WriteLine($"        AffectsArrange: {frameworkMetadata.AffectsArrange}");
                System.Diagnostics.Debug.WriteLine($"        AffectsMeasure: {frameworkMetadata.AffectsMeasure}");
                System.Diagnostics.Debug.WriteLine($"         AffectsRender: {frameworkMetadata.AffectsRender}");
                System.Diagnostics.Debug.WriteLine($"              Inherits: {frameworkMetadata.Inherits}");
            }

            /*  Displays:
             *  
             *  TextBox.Text property metadata:
             *    BindsTwoWayByDefault: True
             *    IsDataBindingAllowed: True
             *          AffectsArrange: False
             *          AffectsMeasure: False
             *           AffectsRender: False
             *                Inherits: False
            */
        }
        //</print_metadata>
    }
}
