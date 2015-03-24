using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OnlineBusinessAnalystCrawler.Utils
{
    public static class TreeNodeEx
    {
        public static IEnumerable<TreeNode> AddRange(this TreeNode collection, IEnumerable<TreeNode> nodes)
        {
            var items = nodes.ToArray();
            collection.Nodes.AddRange(items);
            return new[] { collection };
        }

        /// <summary>
        /// Extension method for getting all nodes recursively. Lazy implementation.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IEnumerable<TreeNode> GetAllNodes(this TreeNode node)
        {
            return new[] { node }.Concat(node.Nodes.Cast<TreeNode>().SelectMany(n => n.GetAllNodes()));
        }

        public static IEnumerable<TreeNode> GetAllNodes(this TreeView tree)
        {
            return tree.Nodes.Cast<TreeNode>().SelectMany(n => n.GetAllNodes());
        }
    }
}
