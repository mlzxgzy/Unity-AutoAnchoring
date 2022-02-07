using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace LP.AutoAnchoring.Editor
{
    public class MakePositionToAnchorWindows : EditorWindow
    {
        [MenuItem("Tools/MakePositionToAnchorWindows")]
        private static void OpenWindows()
        {
            var teleportUtil = GetWindow<MakePositionToAnchorWindows>();
            teleportUtil.titleContent = new GUIContent("MPTA");
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Do it"))
            {
                Assert.IsNotNull(Selection.objects);
                foreach (var o in Selection.objects)
                {
                    Assert.IsTrue(o is GameObject);
                    var tmp = o as GameObject;
                    var tmpRect = tmp.GetComponent<RectTransform>();
                    MakePositionToAnchor.Do(tmpRect);
                }
            }
        }
    }
}
