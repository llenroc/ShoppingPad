﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingPad.Common.Models;
using ShoppingPad.Common.Services;
using ShoppingPad.Common.ViewModels;
using Xunit;
using SQLite;
using System.IO;
using ShoppingPad.Tests.Base;

namespace ShoppingPad.Tests.ViewModels
{
    public class PastPurchasesViewModelTests : BaseShoppingServiceTests
    {
        [Fact]
        public void Add_Item()
        {
            // Arrange
            var vm = new PastPurchasesViewModel(_shoppingService);
            var item = new BoughtItem("item 1");

            // Act
            vm.Add(item);

            // Assert
            Assert.Contains<BoughtItem>(vm.Items, x => x == item);
        }

        [Fact]
        public void Add_Item_Already_Added()
        {
            // Arrange
            var vm = new PastPurchasesViewModel(_shoppingService);
            var item = new BoughtItem("item 1");
            vm.Add(item);
            var item2 = new BoughtItem("item 1");

            // Act
            vm.Add(item);

            // Assert
            Assert.Equal(1, vm.Items.Count);
            Assert.Equal(2, vm.Items.First().BoughtCount);
        }

        [Fact]
        public void Copy_Item_To_Shopping_List()
        {
            // Arrange
            var vm = new PastPurchasesViewModel(_shoppingService);
            var itemTitle = "item1";
            var item = new BoughtItem(itemTitle);
            vm.Add(item);

            // Act
            vm.CopyItemToShoppingList(item);

            // Assert
            Assert.Equal(1, _shoppingService.Items.Count);
            Assert.Contains<Item>(_shoppingService.Items, x => x.Title == itemTitle);
        }
    }
}
