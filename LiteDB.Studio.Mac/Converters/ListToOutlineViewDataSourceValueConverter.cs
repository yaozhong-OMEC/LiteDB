using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LiteDB.Studio.Core.Models.CollectionView;
using LiteDB.Studio.Mac.Models;
using LiteDB.Studio.Mac.Views;
using LiteDB.Studio.Mac.Views.Controls.CollectionOutlineView;
using MvvmCross.Converters;

namespace LiteDB.Studio.Mac.Converters
{
    public class ListToOutlineViewDataSourceValueConverter : MvxValueConverter<List<CollectionItem>>
    {
        protected override object Convert(List<CollectionItem> value, Type targetType, object parameter, CultureInfo culture)
        {
            var rootItem = value?.FirstOrDefault();
            if (rootItem == null)
            {
                return null;
            }

            var rootNode = MapToNode(rootItem);
            return new OutlineViewDataSource(rootNode);
        }


        private Node MapToNode(CollectionItem item)
        {
            var node = new Node(item.Name, item.Type);
            foreach (var child in item.Children)
            {
                node.AddChildNode(MapToNode(child));
            }

            return node;
        }
    }
}