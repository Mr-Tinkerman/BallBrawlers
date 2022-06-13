using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(PlatformSpawnConfig))]
public class PlatformSpawnConfigInspector : Editor
{
    private ReorderableList m_groupList;
    private ReorderableList[] m_typeLists;

    private SerializedProperty m_platformGroupList;
    private SerializedProperty[] m_platformTypeLists;
    private SerializedProperty m_platformMat;

    SerializedProperty pMesh;
    SerializedProperty pBehaviour;

    private int m_gIndex = 0;

    private void OnEnable()
    {
        Setup();
        Undo.undoRedoPerformed += Setup;
    }

    private void OnDisable()
    {
        Undo.undoRedoPerformed -= Setup;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update(); // Update the array property's representation in the inspector

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
        EditorGUI.EndDisabledGroup();

        m_groupList.DoLayoutList();

        EditorGUILayout.PropertyField(m_platformMat);
    }

    private void Setup()
    {
        m_platformMat = serializedObject.FindProperty("platformMaterial");
        m_platformGroupList = serializedObject.FindProperty("platformGroups");

        m_groupList = new ReorderableList(serializedObject, m_platformGroupList, true, true, true, true);

        m_platformTypeLists = new SerializedProperty[m_platformGroupList.arraySize];
        m_typeLists = new ReorderableList[m_platformGroupList.arraySize];

        for (int i = 0; i < m_platformGroupList.arraySize; ++i)
        {
            m_platformTypeLists[i] = m_platformGroupList.GetArrayElementAtIndex(i).FindPropertyRelative("platforms");

            m_typeLists[i] = new ReorderableList(serializedObject, m_platformTypeLists[i], true, false, true, true);

            m_typeLists[i].drawElementCallback = DrawTypeItems;
            m_typeLists[i].elementHeight = 2.2f * EditorGUIUtility.singleLineHeight;
        }

        m_groupList.drawElementCallback = DrawGroupItems;

        m_groupList.drawHeaderCallback = rect =>
        {
            EditorGUI.LabelField(rect, "Platforms");
        };

        m_groupList.onAddCallback = list =>
        {
            list.serializedProperty.arraySize++;
            var prop = list.serializedProperty.GetArrayElementAtIndex(list.serializedProperty.arraySize - 1).FindPropertyRelative("platforms");
            prop.ClearArray();

            m_platformTypeLists = new SerializedProperty[list.count];
            m_typeLists = new ReorderableList[list.count];

            for (int i = 0; i < list.count; ++i)
            {
                m_platformTypeLists[i] = m_platformGroupList.GetArrayElementAtIndex(i).FindPropertyRelative("platforms");

                m_typeLists[i] = new ReorderableList(serializedObject, m_platformTypeLists[i], true, false, true, true);

                m_typeLists[i].drawElementCallback = DrawTypeItems;
                m_typeLists[i].elementHeight = 2.2f * EditorGUIUtility.singleLineHeight;
            }

            serializedObject.ApplyModifiedProperties();
        };

        m_groupList.elementHeightCallback = index =>
        {
            if (index < m_typeLists.Length)
                return m_typeLists[index].GetHeight() + 20;

            else
                return 100;
        };
    }

    private void DrawGroupItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        if (index >= m_typeLists.Length)
            Setup();
        // if (m_groupList.count == 0)
        //     return;

        Rect tempRect = rect;
        float height = EditorGUIUtility.singleLineHeight;

        tempRect.height = height;

        EditorGUI.DrawRect(tempRect, (EditorGUIUtility.isProSkin) ? new Color(0, 0, 0, 0.6f) : new Color(1, 1, 1, 0.6f));
        if (index == 0)
            EditorGUI.LabelField(tempRect, "Base Platforms", EditorStyles.boldLabel);
        else
            EditorGUI.LabelField(tempRect, "Difficulty " + index.ToString(), EditorStyles.boldLabel);


        tempRect.y += height;

        m_gIndex = index;


        m_typeLists[index].DoList(tempRect);
    }

    private void DrawTypeItems(Rect rect, int index, bool isActive, bool isFocused)
    {
        float lineHeight = EditorGUIUtility.singleLineHeight;

        Rect tempRect = rect;
        pMesh = m_platformTypeLists[m_gIndex].GetArrayElementAtIndex(index).FindPropertyRelative("mesh");
        pBehaviour = m_platformTypeLists[m_gIndex].GetArrayElementAtIndex(index).FindPropertyRelative("behaviour");

        tempRect.height = lineHeight * 0.9f;
        tempRect.y += lineHeight * 0.2f;

        EditorGUI.PropertyField(tempRect, pMesh, GUIContent.none);

        tempRect.y += lineHeight;

        EditorGUI.PropertyField(tempRect, pBehaviour, GUIContent.none);

        serializedObject.ApplyModifiedProperties();
    }
}
