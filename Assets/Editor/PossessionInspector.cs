using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SwordGame;

//[CustomEditor(typeof(PossessionV2))]
public class PossessionInspector : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        serializedObject.Update();

        PossessionV2 possession = (PossessionV2)target;
        
        //EditorGUILayout.Space(5);
        
        #region GUIStyle - TextField

        GUIStyle StyleTextFieldCustom;
        StyleTextFieldCustom = GUI.skin.textField;
        StyleTextFieldCustom.alignment = TextAnchor.MiddleCenter;
        #endregion

        #region GUIStyle - Label
        GUIStyle StyleLabelCustom;
        StyleLabelCustom = GUI.skin.label;
        StyleLabelCustom.alignment = TextAnchor.MiddleCenter;
        #endregion

        #region Radius Area
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Radius Area", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.RadiusArea = EditorGUILayout.FloatField(possession.RadiusArea);
        #endregion

        EditorGUILayout.Space(5);
        
        #region Prompt Command
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Prompt Command", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.PromptCommand = (GameObject)EditorGUILayout.ObjectField(possession.PromptCommand, typeof(GameObject), true);
        EditorGUILayout.EndHorizontal();
        #endregion

        #region Player Detect
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Player Detect", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        possession.PlayerDetect = (GameObject)EditorGUILayout.ObjectField(possession.PlayerDetect, typeof(GameObject), true);
        GUI.enabled = true;
        EditorGUILayout.EndHorizontal();
        #endregion

        #region CC2D
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Circle Collider 2D - CC2D", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        possession.CC2D = (CircleCollider2D)EditorGUILayout.ObjectField(possession.CC2D, typeof(CircleCollider2D), true);
        GUI.enabled = true;
        EditorGUILayout.EndHorizontal();
        #endregion

        //is player solo lettura - posso non metterlo
        //player detect array inspector solo lettura

        EditorGUILayout.Space(5);

        #region Time Destroy Last Player
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Time Destroy Last Player", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.TimeDestroyLastPlayer = EditorGUILayout.FloatField(possession.TimeDestroyLastPlayer);
        #endregion


        EditorGUILayout.Space(25);

        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Switch between player and Enemy", StyleTextFieldCustom);
        GUI.enabled = true;

        EditorGUILayout.Space(10);

        #region Physics Material2D
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Material2D", StyleTextFieldCustom);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextArea("Player:", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.MaterialNoFriction = (PhysicsMaterial2D)EditorGUILayout.ObjectField(possession.MaterialNoFriction, typeof(PhysicsMaterial2D), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextArea("Enemy:");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.MaterialYesFriction = (PhysicsMaterial2D)EditorGUILayout.ObjectField(possession.MaterialYesFriction, typeof(PhysicsMaterial2D), true);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(5);

        #region Color
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Color", StyleTextFieldCustom);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextArea("Player:", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.PlayerColor = EditorGUILayout.ColorField(possession.PlayerColor);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextArea("Enemy:");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.EnemyColor = EditorGUILayout.ColorField(possession.EnemyColor);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(5);

        #region Animator
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.LabelField("Animator Override", StyleTextFieldCustom);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextArea("Player:", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.PlayerAnimator = (RuntimeAnimatorController)EditorGUILayout.ObjectField(possession.PlayerAnimator, typeof(RuntimeAnimatorController), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextArea("Enemy:");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        possession.EnemyAnimator = (RuntimeAnimatorController)EditorGUILayout.ObjectField(possession.EnemyAnimator, typeof(RuntimeAnimatorController), true);
        EditorGUILayout.EndHorizontal();
        #endregion

        StyleTextFieldCustom.alignment = TextAnchor.MiddleLeft;

        serializedObject.ApplyModifiedProperties();
    }
}
