using System.Collections.Generic;

namespace LiteDB.Studio.Core.Models.CollectionView
{
    public class CollectionItem
    {
        public string Name { get; set; }
        public CollectionItemType Type { get; set; }
        public List<CollectionItem> Children { get; set; }
        

        public CollectionItem()
        {
            Children = new List<CollectionItem>();
        }
    }
}