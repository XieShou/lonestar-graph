using System;
using LoneStar.Graph.Base.Runtime;
using LoneStar.Graph.Base.Runtime.Data;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace LoneStar.Graph.Base.Editor
{
    public abstract class GraphViewBase : GraphView
    {
        private GraphSearchWindowBase _searchWindow;
        protected VisualElement _graphArea;
        public GraphViewDataBase Data { get; set; }
        public GraphViewBase()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            _searchWindow = CreateSearchWindow();
            if (_searchWindow)
            {
                _searchWindow.GraphViewBase = this;
            }
            nodeCreationRequest += OpenSearchWindow;
        }

        public abstract GraphSearchWindowBase CreateSearchWindow();

        protected virtual void OpenSearchWindow(NodeCreationContext context)
        {
            SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), _searchWindow);
        }

        /// <summary>
        /// 检查节点是否唯一
        /// </summary>
        /// <param name="type">继承自GraphNodeViewBase</param>
        /// <returns></returns>
        public bool CheckIsUnique(Type type)
        {
            bool isUnique = true;
            nodes.ForEach((nodes) =>
            {
                if (nodes.GetType() == type)
                {
                    isUnique = false;
                }
            });
            return isUnique;
        }
        #region 数据

        public int GenGuid()
        {
            //return _dataBase.GenGuid();
            return 1;
        }
        #endregion
        
        public void AddNodeView(GraphNodeViewBase node)
        {
            this.AddElement(node);
        }
        
        public virtual void OnStart(GraphViewDataBase data)
        {
            Data = data;
        }
        
        public virtual void Save()
        {
            nodes.ForEach(SaveNode);
            ports.ForEach(SavePort);
            edges.ForEach(SaveEdge);
        }

        protected virtual void SaveEdge(Edge obj)
        {
            
        }

        protected virtual void SavePort(Port obj)
        {
            
        }

        protected virtual void SaveNode(Node obj)
        {
            
        }


    }
}

