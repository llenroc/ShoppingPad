﻿// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ShoppingPad.iOS
{
    [Register ("ShoppingListTableViewCell")]
    partial class ShoppingListTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton _checkboxButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel _itemTitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_checkboxButton != null) {
                _checkboxButton.Dispose ();
                _checkboxButton = null;
            }

            if (_itemTitleLabel != null) {
                _itemTitleLabel.Dispose ();
                _itemTitleLabel = null;
            }
        }
    }
}