using System;
using UnityEngine;

namespace LoneStar.Graph.Base.Runtime.Data
{
    [Serializable]
    public class GraphEdgeDataBase : ScriptableObject
    {
        public int ID;

        public int FromID;
        
        public int ToID;
    }
}