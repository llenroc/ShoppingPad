﻿using System;

using Foundation;
using UIKit;
using ShoppingPad.Common.Helpers;
using System.Linq;
using ShoppingPad.Common.ViewModels;
using Autofac;
using System.Threading;
using ShoppingPad.Common.Models;

namespace ShoppingPad.iOS
{
    public class ShoppingListTableSource : UITableViewSource 
	{
        private ShoppingListViewModel _viewModel;

        private Item _deletingItem;
		
		public ShoppingListTableSource ()
		{
            _viewModel = ServiceRegistrar.Container.Resolve<ShoppingListViewModel>();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return _viewModel.Items.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (ShoppingListTableViewCell)tableView.DequeueReusableCell(ShoppingListTableViewCell.Key);

            var item = _viewModel.Items.ElementAt(indexPath.Row);

            var isChecked = item == _deletingItem;
            cell.UpdateCell(item, isChecked);

			return cell;
		}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var item = _viewModel.Items.ElementAt(indexPath.Row);
            _deletingItem = item;
            tableView.ReloadRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Automatic);
            _viewModel.Purchase(item);
            tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
            _deletingItem = null;
        }

        // deleting from the list: https://developer.xamarin.com/guides/ios/user_interface/tables/part_4_-_editing/#Swipe_to_Delete
        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    _viewModel.Remove(_viewModel.Items.ElementAt(indexPath.Row));
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true; // return false if you wish to disable editing for a specific indexPath or for all rows
        }
    }
}
