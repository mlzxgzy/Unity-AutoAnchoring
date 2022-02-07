using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace LP.AutoAnchoring.Editor
{
    public class MakePositionToAnchor : MonoBehaviour
    {
        [MenuItem("CONTEXT/RectTransform/MakePositionToAnchor")]
        static void MakePositionToAnchor_Menu(MenuCommand cmd)
        {
            Assert.IsTrue(cmd.context is RectTransform, "Please select RectTransform");
            RectTransform now = cmd.context as RectTransform;
            Do(now);
        }

        public static void Do(RectTransform target)
        {
            RectTransform now = target;
            RectTransform parent = now.parent.GetComponent<RectTransform>();

            Vector3[] nowPos = new Vector3[4];
            Vector3[] parentPos = new Vector3[4];

            now.GetWorldCorners(nowPos);
            parent.GetWorldCorners(parentPos);

            var parentRect = parent.rect;
            var nowRect = now.rect;

            var xMin = (nowPos[0] - parentPos[0]).x / parentRect.width;
            var xMax = 1 - (parentRect.width - ((nowPos[0] - parentPos[0]).x + nowRect.width)) / parentRect.width;

            var yMax = 1 - (parentPos[1] - nowPos[1]).y / parentRect.height;
            var yMin = (parentRect.height - ((parentPos[1] - nowPos[1]).y + nowRect.height)) / parentRect.height;

            now.anchorMin = new Vector2(xMin, yMin);
            now.anchorMax = new Vector2(xMax, yMax);
            now.anchoredPosition = Vector2.zero;
            now.sizeDelta = Vector2.zero;
        }
    }
}
