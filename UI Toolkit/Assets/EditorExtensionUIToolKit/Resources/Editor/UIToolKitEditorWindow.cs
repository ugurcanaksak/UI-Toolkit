using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class UIToolKitEditorWindow : EditorWindow
{
    Color matColor = Color.white;
    private Button buttonRot;
    private ColorField cf;
    private Button buttonColor;

    [MenuItem("Ugurcan Aksak/UIWindow")]

    public static void OpenWindow()
    {
        GetWindow<UIToolKitEditorWindow>().Show();
    }

    private void CreateGUI()
    {
        VisualElement root=rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/EditorExtensionUIToolKit/Resources/UIDocument/WindowDocument.uxml");

        VisualElement tree=visualTree.Instantiate();
        root.Add(tree);

        buttonRot=root.Q<Button>("buttonRotate");
        buttonColor=root.Q<Button>("colorChanger");
        cf=root.Q<ColorField>("ColorField");

        buttonRot.clicked += Rotate;

        buttonColor.clicked += changeColor;
    }
    private void Rotate()
    {
        if (Selection.activeGameObject)
            Selection.activeGameObject.transform.Rotate(Vector3.up * 3000.0f * Time.deltaTime);
    }

        private void changeColor()
    {
        if (Selection.activeGameObject){

            Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
            Selection.activeGameObject.GetComponent<Renderer>().sharedMaterial.color=newColor;



        }



    }

}
