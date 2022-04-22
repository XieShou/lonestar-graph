using GameFlow.Runtime.Data;
using LoneStar.Graph.Base.Editor;
using LoneStar.Graph.Base.Runtime.Data;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LoneStar.Graph.GameFlow.Editor
{
    public class GameFlowView : GraphViewBase
    {
        #region 搜索面板

        #endregion

        public GameFlowView() : base()
        {
            
        }

        public GameFlowData Data { get; set; }

        public override GraphSearchWindowBase CreateSearchWindow()
        {
            return new GameFlowSearchWindow();
        }

        public override void OnStart(GraphViewDataBase data)
        {
            base.OnStart(data);
            Data = data as GameFlowData;
        }
    }
}