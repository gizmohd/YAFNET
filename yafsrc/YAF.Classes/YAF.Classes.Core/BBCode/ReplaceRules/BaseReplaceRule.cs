﻿/* Yet Another Forum.net
 * Copyright (C) 2006-2010 Jaben Cargman
 * http://www.yetanotherforum.net/
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 */
namespace YAF.Classes.Core.BBCode
{
  using System;

  /// <summary>
  /// Base class for all replacement rules.
  ///   Provides compare functionality based on the rule rank.
  ///   Override replace to handle replacement differently.
  /// </summary>
  public abstract class BaseReplaceRule : IComparable, IBaseReplaceRule
  {
    #region Constants and Fields

    /// <summary>
    ///   The rule rank.
    /// </summary>
    public int RuleRank = 50;

    #endregion

    #region Properties

    /// <summary>
    ///   Gets RuleDescription.
    /// </summary>
    public virtual string RuleDescription
    {
      get
      {
        return string.Empty;
      }
    }

    #endregion

    #region Implemented Interfaces

    #region IBaseReplaceRule

    /// <summary>
    /// The replace.
    /// </summary>
    /// <param name="text">
    /// The text.
    /// </param>
    /// <param name="replacement">
    /// The replacement.
    /// </param>
    /// <exception cref="NotImplementedException">
    /// </exception>
    public virtual void Replace(ref string text, ref HtmlReplacementCollection replacement)
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IComparable

    /// <summary>
    /// The compare to.
    /// </summary>
    /// <param name="obj">
    /// The obj.
    /// </param>
    /// <returns>
    /// The compare to.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// </exception>
    public int CompareTo(object obj)
    {
      if (obj is BaseReplaceRule)
      {
        var otherRule = obj as BaseReplaceRule;

        if (this.RuleRank > otherRule.RuleRank)
        {
          return 1;
        }
        else if (this.RuleRank < otherRule.RuleRank)
        {
          return -1;
        }

        return 0;
      }
      else
      {
        throw new ArgumentException("Object is not of type BaseReplaceRule.");
      }
    }

    #endregion

    #endregion
  }
}