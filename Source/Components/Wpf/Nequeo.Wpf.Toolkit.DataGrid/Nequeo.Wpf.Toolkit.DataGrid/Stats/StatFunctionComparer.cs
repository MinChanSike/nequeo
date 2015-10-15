﻿/*************************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2007-2013 Nequeo Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://Nequeo.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

  ***********************************************************************************/

using System.Collections.Generic;

namespace Nequeo.Wpf.DataGrid.Stats
{
  internal class StatFunctionComparer : IEqualityComparer<StatFunction>
  {
    internal static readonly StatFunctionComparer Default = new StatFunctionComparer();

    public bool Equals( StatFunction x, StatFunction y )
    {
      return StatFunction.AreEquivalents( x, y );
    }

    public int GetHashCode( StatFunction statFunction )
    {
      if( statFunction == null )
        return 0;

      return statFunction.GetEquivalenceKey();
    }
  }
}