﻿/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Nequeo Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://Nequeo.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System;

namespace Nequeo.Wpf.Toolkit.PropertyGrid.Attributes
{
  public enum UsageContextEnum
  {
    Alphabetical,
    Categorized,
    Both
  }

  [AttributeUsage( AttributeTargets.Property, AllowMultiple = true, Inherited = true )]
  public class PropertyOrderAttribute : Attribute
  {
    #region Properties

    public int Order
    {
      get;
      set;
    }

    public UsageContextEnum UsageContext
    {
      get;
      set;
    }

    public override object TypeId
    {
      get
      {
        return this;
      }
    }

    #endregion

    #region Initialization

    public PropertyOrderAttribute( int order )
      : this( order, UsageContextEnum.Both )
    {
    }

    public PropertyOrderAttribute( int order, UsageContextEnum usageContext )
    {
      Order = order;
      UsageContext = usageContext;
    }

    #endregion
  }
}
