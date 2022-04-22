using LoneStar.Graph.Base.Runtime.Data;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace LoneStar.Graph.Base.Editor
{
    public abstract class GraphWindowBase : EditorWindow
    {
        #region 配置项

        #endregion

        protected VisualElement _graphArea;
        
        private GraphViewBase graphView;

        protected Toolbar _toolbar;
        protected Button _saveBtn;



        /// <summary>
        /// Unity自动调用
        /// </summary>
        public virtual void OnEnable()
        {
            _graphArea = new VisualElement();
            rootVisualElement.Add(_graphArea);
            _graphArea.StretchToParentSize();
            
            _toolbar = new Toolbar();
            _saveBtn = new Button(Save) {text = "Save"};
            _toolbar.Add(_saveBtn);
            rootVisualElement.Add(_toolbar);
        }

        /// <summary>
        /// 框架调用
        /// </summary>
        public virtual void OnStart()
        {
            Load();
        }

        public void Load() { }

        public void Save()
        {
            graphView.Save();
        }

        public T GetOrCreateGraphView<T>(GraphViewDataBase data)where T : GraphViewBase, new()
        {
            if (graphView != null)
            {
                rootVisualElement.Remove(graphView);
            }
            graphView = new T();

            _graphArea.Add(graphView);
            graphView.StretchToParentSize();
            graphView.OnStart(data);
            return graphView as T;
        }

        public void OnDisable()
        {
            /*if (graphView != null)
            {
                rootVisualElement.Remove(graphView);
            }*/
        }
    }
}