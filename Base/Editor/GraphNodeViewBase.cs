using UnityEditor;
using UnityEditor.Experimental.GraphView;

namespace LoneStar.Graph.Base.Editor
{
    public abstract class GraphNodeViewBase : Node
    {
        private int guid;
        public int GUID => guid;

        #region 配置项
        
        protected virtual string m_Title
        {
            get => this.GetType().Name;
            set => title = value;
        }
        
        #endregion


        protected GraphNodeViewBase(int guid)
        {
            this.guid = guid;
            this.title = m_Title;
        }

        public abstract bool IsUniqueNode { get; }

        public virtual bool CheckCanCreate(GraphViewBase graphViewBase)
        {
            if (IsUniqueNode)
            {
                return graphViewBase.CheckIsUnique(this.GetType());
            }

            return true;
        }
        /// <summary>
        /// 创建一个新的
        /// </summary>
        /// <returns></returns>
        public abstract GraphNodeViewBase CreateToGraphView(int guid);
        
    }
}