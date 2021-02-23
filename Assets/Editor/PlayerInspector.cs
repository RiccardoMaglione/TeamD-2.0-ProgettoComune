using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SwordGame;
using UnityEngine.UI;

[CustomEditor(typeof(PlayerController))]
public class PlayerInspector : Editor
{
    Color BGColor;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        PlayerController PC = (PlayerController)target;

        #region GUIStyle - TextField
        GUIStyle StyleTextFieldCustom;
        StyleTextFieldCustom = GUI.skin.textField;
        StyleTextFieldCustom.alignment = TextAnchor.MiddleCenter;
        #endregion

        BGColor = GUI.backgroundColor;
        
        #region PlayerManager Inspector
        #region Character Type
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Character Type Management", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("TypeCharacter", StyleTextFieldCustom);
        Rect typeRect = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect, new GUIContent("", "Permette di selezionare la tipologia del player"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.TypeCharacter = (TypePlayer)EditorGUILayout.EnumPopup(PC.TypeCharacter);
        EditorGUILayout.EndHorizontal();
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        #endregion
        
        EditorGUILayout.Space(10);

        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        //GUI.backgroundColor = Color.black;
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Life System - Value Management", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        //GUI.backgroundColor = BGColor;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Health Slider");
        Rect typeRect1 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect1, new GUIContent("", "Slider riferito alla vita nella UI"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.HealthSlider = (HealthBar)EditorGUILayout.ObjectField(PC.HealthSlider, typeof(HealthBar), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Max Health");
        Rect typeRect2 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect2, new GUIContent("", "Valore massimo della vita del player"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.MaxHealth = EditorGUILayout.IntField(PC.MaxHealth);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(10);
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        //GUI.backgroundColor = Color.black;
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Energy System - Value Management", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        //GUI.backgroundColor = BGColor;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Energy Bar");
        Rect typeRect3 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect3, new GUIContent("", "Immagine che rappresenta la barra d'energia"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.EnergyBar = (Image)EditorGUILayout.ObjectField(PC.EnergyBar, typeof(Image), true);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Max Energy");
        Rect typeRect4 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect4, new GUIContent("", "Valore massimo della energia del player"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.MaxEnergy = EditorGUILayout.IntField(PC.MaxEnergy);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space(5);
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        //GUI.backgroundColor = Color.black;
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Attack Energy System - Value Management", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        //GUI.backgroundColor = BGColor;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Light Energy Amount");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.LightEnergyAmount = EditorGUILayout.IntField(PC.LightEnergyAmount);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Heavy Energy Amount");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.HeavyEnergyAmount = EditorGUILayout.IntField(PC.HeavyEnergyAmount);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Special Energy Amount");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.SpecialEnergyAmount = EditorGUILayout.IntField(PC.SpecialEnergyAmount);
        EditorGUILayout.EndHorizontal();
        #endregion
        
        EditorGUILayout.Space(20);

        #region Reference Rigidbody2D
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Reference Rigidbody 2D del Player", StyleTextFieldCustom);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        PC.rb = (Rigidbody2D)EditorGUILayout.ObjectField(PC.rb, typeof(Rigidbody2D), true);
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        #endregion

        EditorGUILayout.Space(20);

        #region Movement Struct
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        //GUI.backgroundColor = Color.black;
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Movement Struct", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        //GUI.backgroundColor = BGColor;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Acceleration");
        Rect typeRect5 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect5, new GUIContent("", "It's an acceleration of player"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueMovement.Acceleration = EditorGUILayout.FloatField(PC.ValueMovement.Acceleration);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Speed");
        Rect typeRect6 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect6, new GUIContent("", "It's a velocity of player on right and left way"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueMovement.Speed = EditorGUILayout.FloatField(PC.ValueMovement.Speed);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Max Speed");
        Rect typeRect7 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect7, new GUIContent("", "It's a max speed of player"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueMovement.MaxSpeed = EditorGUILayout.FloatField(PC.ValueMovement.MaxSpeed);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);

        #region Jump Struct
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        //GUI.backgroundColor = Color.black;
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Jump Struct", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        //GUI.backgroundColor = BGColor;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Jump Force");
        Rect typeRect8 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect8, new GUIContent("", "It's a force of player's jump"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueJump.jumpForce = EditorGUILayout.FloatField(PC.ValueJump.jumpForce);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Fall Multiplier");
        Rect typeRect9 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect9, new GUIContent("", "It's value of gravity fall"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueJump.fallMultiplier = EditorGUILayout.FloatField(PC.ValueJump.fallMultiplier);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Low Jump Multiplier");
        Rect typeRect10 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect10, new GUIContent("", "It's a value for progressive jump"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.ValueJump.lowJumpMultiplier = EditorGUILayout.FloatField(PC.ValueJump.lowJumpMultiplier);
        EditorGUILayout.EndHorizontal();
        #endregion
        
        EditorGUILayout.Space(20);
        
        #region Platform Reset
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Platform Reset", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Timer Rotation Offset");
        Rect typeRect11 = GUILayoutUtility.GetLastRect();
        GUI.Label(typeRect11, new GUIContent("", "It's a time of change rotation offset of platform"));
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.TimeDoublePlatform = EditorGUILayout.FloatField(PC.TimeDoublePlatform);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(5);

        #region Stagger Reset
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Stagger Value", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Max Value of Poise");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.MaxPoisePlayer = EditorGUILayout.IntField(PC.MaxPoisePlayer);
        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(10);

        #region Dash Management
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Dash Management", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Limit Timer Dash");
        GUI.enabled = true;
        PC.LimitTimerDash = EditorGUILayout.FloatField(PC.LimitTimerDash);
        GUI.enabled = false;
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Timer Cooldown Dash");
        GUI.enabled = true;
        PC.TimerCooldownDash = EditorGUILayout.FloatField(PC.TimerCooldownDash);
        EditorGUILayout.EndHorizontal();
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        #endregion

        EditorGUILayout.Space(1);
        
        #region Dash Effect Management
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Dash Management: Effect", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;
        EditorGUILayout.BeginHorizontal();

        if (PC.TypeCharacter == TypePlayer.FatKnight)
        {
            EditorGUILayout.TextField("Effect Fat Knight - Damage");
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
            GUI.enabled = true;
            PC.DashDamageFatKnight = EditorGUILayout.IntField(PC.DashDamageFatKnight);
        }
        else if (PC.TypeCharacter == TypePlayer.Babushka)
        {
            EditorGUILayout.TextField("Effect Babushka - Collider");
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
            GUI.enabled = true;
            PC.DashColliderBabushka = (GameObject)EditorGUILayout.ObjectField(PC.DashColliderBabushka, typeof(GameObject), true);
        }
        else if (PC.TypeCharacter == TypePlayer.BoriousKnight)
        {
            EditorGUILayout.TextField("Effect - Reference Null");
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
            GUI.enabled = true;
            Debug.Log("Effect Borius Knight");
        }
        else if (PC.TypeCharacter == TypePlayer.Thief)
        {
            EditorGUILayout.TextField("Effect - Invulnerability");
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
            GUI.enabled = true;
            GUI.enabled = false;
            PC.Invulnerability = EditorGUILayout.Toggle(PC.Invulnerability);
            GUI.enabled = true;
        }

        EditorGUILayout.EndHorizontal();
        #endregion

        EditorGUILayout.Space(20);
        
        #region Animation Clip Speed Animator
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        StyleTextFieldCustom.fontStyle = FontStyle.BoldAndItalic;
        EditorGUILayout.TextField("Animator Speed", StyleTextFieldCustom);
        StyleTextFieldCustom.fontStyle = FontStyle.Normal;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Idle Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerIdleSpeed = EditorGUILayout.FloatField(PC.PlayerIdleSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Move Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerMoveSpeed = EditorGUILayout.FloatField(PC.PlayerMoveSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Dash Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerDashSpeed = EditorGUILayout.FloatField(PC.PlayerDashSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Fall Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerFallSpeed = EditorGUILayout.FloatField(PC.PlayerFallSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Dash Fall Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerDashFallSpeed = EditorGUILayout.FloatField(PC.PlayerDashFallSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Jump Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerJumpSpeed = EditorGUILayout.FloatField(PC.PlayerJumpSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Die Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerDieSpeed = EditorGUILayout.FloatField(PC.PlayerDieSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Stagger Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerStaggerSpeed = EditorGUILayout.FloatField(PC.PlayerStaggerSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Light Attack Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerLightAttackSpeed = EditorGUILayout.FloatField(PC.PlayerLightAttackSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Heavy Attack Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerHeavyAttackSpeed = EditorGUILayout.FloatField(PC.PlayerHeavyAttackSpeed);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUI.enabled = false;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a * 2f);
        EditorGUILayout.TextField("Special Attack Speed");
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, GUI.color.a / 2f);
        GUI.enabled = true;
        PC.PlayerSpecialAttackSpeed = EditorGUILayout.FloatField(PC.PlayerSpecialAttackSpeed);
        EditorGUILayout.EndHorizontal();
        #endregion

        StyleTextFieldCustom.alignment = TextAnchor.MiddleLeft;

        serializedObject.ApplyModifiedProperties();
    }
}


//---Player Controller

//StaticSpeed
//Per il momento no TempPlatform -> è stato sostituito da una lista
//Mancano vari tooltip