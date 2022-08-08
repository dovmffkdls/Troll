using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace EditorTool.UGUIGenerator
{
    public static class UGUIGenerator
    {
        [MenuItem("GameObject/Generate UGUI", priority = 49)]
        private static void Selection_Generate_False() => Selection_Generate();

        private static void Selection_Generate()
        {
            if (!Selection.gameObjects.ExIsEmpty() && 1 < Selection.gameObjects.Length)
                EditorUtility.DisplayDialog("UGUIGenerator", "다중 선택은 지원되지 않습니다.\n1개만 선택해주세요.", "OK");
            else 
                Generate(Selection.gameObjects.ExIsEmpty() ? GetMain() : Selection.gameObjects[0]);
        }

        private static GameObject GetMain() => GameObject.Find("Main");

        private static void Generate(GameObject sourceObject)
        {
            var spriteRenderers = sourceObject.GetComponentsInChildren<SpriteRenderer>(true);
            foreach (var spriteRenderer in spriteRenderers)
            {
                Image imgae = spriteRenderer.gameObject.AddComponent<Image>();
                imgae.sprite = spriteRenderer.sprite;
                imgae.color = spriteRenderer.color;
                imgae.raycastTarget = false;

                spriteRenderer.enabled = false;
            }
        }
    }   
}
