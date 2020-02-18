namespace UnityEngine.UI
{
    [UnityEditor.CustomEditor(typeof(ExtendedButton))]
    public class ExtendedButtonEditor : UnityEditor.UI.ButtonEditor 
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DrawDefaultInspector();
        }
    }
}

