using System.Collections.Generic;
using LoneStar.Graph;
using UnityEngine;
using XDiffGui;

namespace LoneStar.Graph.Base.Runtime.Data
{
    public class GraphViewDataBase : ScriptableObject
    {
        [HideInInspector]
        public int Index = 0;

        /// <summary>
        /// 生成ID
        /// </summary>
        /// <returns></returns>
        public int GenGuid()
        {
            Index++;
            return Index;
        }
    
        /// <summary>
        /// 所有节点数据
        /// </summary>
        public List<GraphNodeDataBase> Nodes;

        public List<GraphPortDataBase> Ports;
        /// <summary>
        /// 所有连接数据
        /// </summary>
        public List<GraphEdgeDataBase> Edges;
    }
}

