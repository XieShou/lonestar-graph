using System.Collections.Generic;
using LoneStar.Graph.Base.Editor.Nodes;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LoneStar.Graph.Base.Editor
{
    public abstract class GraphSearchWindowBase : ScriptableObject, ISearchWindowProvider
    {
        private List<SearchTreeEntry> entries;
        private GraphViewBase m_GraphViewBase;
        public GraphViewBase GraphViewBase
        {
            get => m_GraphViewBase;
            set => m_GraphViewBase = value;
        }

        public void ConstructGroupEntry(string name, int level)
        {
            entries.Add(new SearchTreeGroupEntry(new GUIContent(name)) {level = level});
        }
        
        public void ConstructEntry(string name, int level, GraphNodeViewBase node)
        {
            entries.Add(new SearchTreeEntry(new GUIContent(name))
            {
                level = level,
                userData = node,
            });
        }
        
        public virtual List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
        {
            if (entries == null)
            {
                entries = new List<SearchTreeEntry>();
                ConstructGroupEntry("All Nodes", 0);
                ConstructGroupEntry("Common", 1);
                ConstructEntry("Start Node", 2, new StartNode(0));
                ConstructEntry("End Node", 2, new StartNode(0));
                AddCustomEntries(context);
            }

            return entries;
        }

        protected abstract void AddCustomEntries(SearchWindowContext context);

        public virtual bool OnSelectEntry(SearchTreeEntry entry, SearchWindowContext context)
        {
            if (entry.userData is GraphNodeViewBase nodeBase)
            {
                if (!CheckEntry(nodeBase))
                {
                    return false;
                }

                AddEntry(nodeBase);
            }
            return false;
        }

        /// <summary>
        /// 检查节点是否能添加
        /// </summary>
        /// <param name="nodeBase"></param>
        /// <returns></returns>
        public virtual bool CheckEntry(GraphNodeViewBase nodeBase)
        {
            return nodeBase.CheckCanCreate(m_GraphViewBase);
            return true;
        }
        
        public virtual bool AddEntry(GraphNodeViewBase nodeBase)
        {
            int guid = m_GraphViewBase.GenGuid();
            GraphNodeViewBase node = nodeBase.CreateToGraphView(guid);
            m_GraphViewBase.AddNodeView(node);
            return false;
        }
        
    }
}