using System.Collections.Generic;
using Foundation;
using LiteDB.Studio.Core.Models.CollectionView;

namespace LiteDB.Studio.Mac.Models
{
    public class Node : NSObject
    {
        public string Name { get; }
        public CollectionItemType Type { get; }
        private readonly List<Node> _children;

        public Node(string name, CollectionItemType type)
        {
            Name = name;
            Type = type;
            _children = new List<Node>();
        }

        public void AddChildNode(Node childNode)
        {
            _children.Add(childNode);
            
        }

        public Node GetChild(int index)
        {
            return _children[index];
        }

        public int ChildCount => _children.Count;
        public bool IsLeaf => ChildCount == 0;
    }
}