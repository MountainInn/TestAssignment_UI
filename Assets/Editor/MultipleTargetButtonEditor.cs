using UnityEditor;

[CustomEditor(typeof(MultipleTargetGraphicButton))]
public class MultipleTargetButtonEditor : UnityEditor.UI.ButtonEditor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty graphics = serializedObject.FindProperty("targetGraphics");

        EditorGUILayout.PropertyField(graphics);

        serializedObject.ApplyModifiedProperties();

        base.OnInspectorGUI();
    }
}
