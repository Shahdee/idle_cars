/// @creator: Slipp Douglas Thompson
/// @license: WTFPL
/// @purpose: Slimmed-down Inspector UI for `NonDrawingGraphic` class.
/// @why: Because this functionality should be built-into Unity.
/// @usage: Add a `NonDrawingGraphic` component to the GameObject you want clickable, but without its own image/graphics.
/// @intended project path: Assets/Plugins/Editor/UnityEngine UI Extensions/NonDrawingGraphicEditor.cs
/// @interwebsouce: https://gist.github.com/capnslipp/349c18283f2fea316369

using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.UI;


[CanEditMultipleObjects, CustomEditor(typeof(NonDrawingGraphic), false)]
public class NonDrawingGraphicEditor : GraphicEditor
{
	public override void OnInspectorGUI ()
	{
		base.serializedObject.Update();
		EditorGUILayout.PropertyField(base.m_Script);
		// skipping AppearanceControlsGUI
		base.RaycastControlsGUI();
		base.serializedObject.ApplyModifiedProperties();
	}

    [MenuItem("GameObject/UI/NonDrawingGraphic", false, 1)]
    static void CreateNonDrawingGraphic(MenuCommand menuCommand)
    {
        var go = menuCommand.context as GameObject;
        if(go== null)
            return;
        var non = go.GetComponent<NonDrawingGraphic>();
        var graphic = go.GetComponent<Graphic>();
        if (non == null && graphic==null)
        {
            non = go.AddComponent<NonDrawingGraphic>();
            Undo.RegisterCreatedObjectUndo(non, "Add NonDrawingGraphic to" + go.name);
            Selection.activeObject = go;
        }
    }
}
