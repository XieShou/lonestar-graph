using System;

namespace LoneStar.Graph.Base.Runtime.Data
{
    [Serializable]
    public class GraphPortDataBase
    {
        public int ID;

        /// <summary>
        /// 端口条件
        /// </summary>
        public GraphConditionDataBase Condition;
    }
}