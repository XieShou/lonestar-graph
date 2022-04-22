using LoneStar.Graph.Base.Editor;

namespace LoneStar.Graph.GameFlow.Editor.Nodes
{
    public class LogicNode : GraphNodeViewBase
    {
        public override bool IsUniqueNode => false;

        public override bool CheckCanCreate(GraphViewBase graphViewBase)
        {
            return graphViewBase is GameFlowView;
        }

        public override GraphNodeViewBase CreateToGraphView(int guid)
        {
            return new LogicNode(guid);
        }

        public LogicNode(int guid) : base(guid)
        {
        }
    }
}