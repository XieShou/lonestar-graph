using System;
using GameFlow.Runtime.Data;
using LoneStar.Graph.Base.Editor;
using LoneStar.Graph.Base.Runtime.Data;
using UnityEditor;
using UnityEngine;

namespace LoneStar.Graph.GameFlow.Editor
{
    public class GameFlowWindow : GraphWindowBase
    {
        [UnityEditor.Callbacks.OnOpenAsset]
        public static bool OpenGameFlowData(int instanceId, int line)
        {
            string path = AssetDatabase.GetAssetPath(instanceId);
            Type type = AssetDatabase.GetMainAssetTypeAtPath(path);
            if (type == typeof(GameFlowData))
            {
                OpenGameFlowWindow(AssetDatabase.LoadAssetAtPath<GameFlowData>(path));
                return true;
            }

            return false;
        }
        
        [MenuItem("LoneStar/GameFlow")]
        public static void ShowWindow()
        {
            GameFlowWindow window = GetWindow<GameFlowWindow>();
            window.titleContent = new GUIContent("游戏流程");
            window.Show();
        }
        
        private static void OpenGameFlowWindow(GameFlowData gameFlowData)
        {
            GameFlowWindow window = GetWindow<GameFlowWindow>();
            window.titleContent = new GUIContent("游戏流程");
            window.gameFlowData = gameFlowData;
            window.Show();
            window.OnStart();
        }

        public GameFlowData gameFlowData { get; private set; }

        protected GameFlowView view { get; private set; }

        public override void OnEnable()
        {
            base.OnEnable();
            
        }

        public override void OnStart()
        {
            base.OnStart();
            view = GetOrCreateGraphView<GameFlowView>(gameFlowData);
        }
    }
}