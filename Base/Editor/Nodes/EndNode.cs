namespace LoneStar.Graph.Base.Editor.Nodes
{
    public class EndNode : GraphNodeViewBase
    {
        private EndNode(int guid) : base(guid)
        {
            
        }

        public override bool IsUniqueNode => true;

        public override GraphNodeViewBase CreateToGraphView(int guid)
        {
            var node = new EndNode(guid);
            return node;
        }
    }
}