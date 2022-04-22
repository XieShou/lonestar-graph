namespace LoneStar.Graph.Base.Editor.Nodes
{
    public class StartNode : GraphNodeViewBase
    {
        public override bool IsUniqueNode => true;


        public override GraphNodeViewBase CreateToGraphView(int guid)
        {
            var node = new StartNode(guid);
            return node;
        }

        public StartNode(int guid) : base(guid)
        {
            
        }
    }
}