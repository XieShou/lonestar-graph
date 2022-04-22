using System.Collections.Generic;
using LoneStar.Graph.Base.Editor;
using LoneStar.Graph.GameFlow.Editor.Nodes;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace LoneStar.Graph.GameFlow.Editor
{
    public class GameFlowSearchWindow : GraphSearchWindowBase
    {
        protected override void AddCustomEntries(SearchWindowContext context)
        {
            ConstructGroupEntry("Game Flow", 1);
            ConstructEntry("Logic Node", 2, new LogicNode(0));
        }
    }
}