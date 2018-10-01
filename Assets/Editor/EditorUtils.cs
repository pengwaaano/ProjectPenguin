using Controllers;
using Malee.Editor;
using UnityEditor;
using UnityEngine;

public class EditorUtils : MonoBehaviour
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(LocationController))]
    public class LocationTemplateInspector : Editor
    {
        private ReorderableList locationTemplates;

        void OnEnable()
        {
            setReorderableList(ref locationTemplates, "locations", "name");
        }

        private void setReorderableList(ref ReorderableList list, string propertyName, string elementNameTitle)
        {
            SerializedProperty prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;
            list = new ReorderableList(prop);
            list.elementNameProperty = elementNameTitle;
        }

        public override void OnInspectorGUI()
        {
            displayReorderableList(ref locationTemplates);
        }

        private void displayReorderableList(ref ReorderableList list)
        {
            if (list == null)
                return;
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }

    [CanEditMultipleObjects]
    [CustomEditor(typeof(CurrencyController))]
    public class CurrencyDenominationsInspector : Editor
    {
        private ReorderableList denominationsList;

        void OnEnable()
        {
            setReorderableList(ref denominationsList, "denominations", "name");
        }

        private void setReorderableList(ref ReorderableList list, string propertyName, string elementNameTitle)
        {
            SerializedProperty prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;
            list = new ReorderableList(prop);
            list.elementNameProperty = elementNameTitle;
        }

        public override void OnInspectorGUI()
        {
            displayReorderableList(ref denominationsList);
        }

        private void displayReorderableList(ref ReorderableList list)
        {
            if (list == null)
                return;
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    [CanEditMultipleObjects]
    [CustomEditor(typeof(PenguinController))]
    public class PenguinTemplateInspector : Editor
    {
        private ReorderableList penguinTemplates;

        void OnEnable()
        {
            setReorderableList(ref penguinTemplates, "penguins", "name");
        }

        private void setReorderableList(ref ReorderableList list, string propertyName, string elementNameTitle)
        {
            SerializedProperty prop = serializedObject.FindProperty(propertyName);
            if (prop == null)
                return;
            list = new ReorderableList(prop);
            list.elementNameProperty = elementNameTitle;
        }

        public override void OnInspectorGUI()
        {
            displayReorderableList(ref penguinTemplates);
        }

        private void displayReorderableList(ref ReorderableList list)
        {
            if (list == null)
                return;
            serializedObject.Update();
            list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}