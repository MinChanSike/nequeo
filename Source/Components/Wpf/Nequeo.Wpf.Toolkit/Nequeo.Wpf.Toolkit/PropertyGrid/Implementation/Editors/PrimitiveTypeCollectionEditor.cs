﻿/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Nequeo Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://Nequeo.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Windows;
namespace Nequeo.Wpf.Toolkit.PropertyGrid.Editors
{
  public class PrimitiveTypeCollectionEditor : TypeEditor<PrimitiveTypeCollectionControl>
  {
    protected override void SetControlProperties()
    {
      Editor.BorderThickness = new System.Windows.Thickness( 0 );
      Editor.Content = "(Collection)";
    }

    protected override void SetValueDependencyProperty()
    {
      ValueProperty = PrimitiveTypeCollectionControl.ItemsSourceProperty;
    }

    protected override void ResolveValueBinding( PropertyItem propertyItem )
    {
      var type = propertyItem.PropertyType;
      Editor.ItemsSourceType = type;

      if( type.BaseType == typeof( System.Array ) )
      {
        Editor.ItemType = type.GetElementType();
      }
      else if( type.IsGenericType )
      {
        var typeArguments = type.GetGenericArguments();
        if( typeArguments.Length > 0 )
        {
          Editor.ItemType = typeArguments[ 0 ];
        }
      }

      base.ResolveValueBinding( propertyItem );
    }
  }

  public class PropertyGridEditorPrimitiveTypeCollectionControl : PrimitiveTypeCollectionControl
  {
    static PropertyGridEditorPrimitiveTypeCollectionControl()
    {
      DefaultStyleKeyProperty.OverrideMetadata( typeof( PropertyGridEditorPrimitiveTypeCollectionControl ), new FrameworkPropertyMetadata( typeof( PropertyGridEditorPrimitiveTypeCollectionControl ) ) );
    }
  }
}
