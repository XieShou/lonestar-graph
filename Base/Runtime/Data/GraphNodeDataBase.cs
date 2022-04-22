using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace LoneStar.Graph.Base.Runtime.Data
{
    [Serializable]
    public class GraphNodeDataBase
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        public int ID;

        /// <summary>
        /// 节点
        /// </summary>
        public List<GraphPortDataBase> Ports;
    }
}