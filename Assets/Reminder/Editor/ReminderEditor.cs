using System;
using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace @internal.NF.NFEditor.Editor
{
    public class ReminderEditor : EditorWindow
    {
        string myString = "Hello World";
        private bool opened = false;

        private ReminderInfo info;
    
        // Add menu item named "My Window" to the Window menu
        [MenuItem("Window/Activity reminder")]
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            EditorWindow.GetWindow(typeof(ReminderEditor), true, "Activity reminder");
        }

        private void OnEnable()
        {
            info = Resources.Load("reminderinfo") as ReminderInfo;
            myString = info.text;
        }

        void OnGUI()
        {
            var style = new GUIStyle();
            
            EditorGUI.BeginChangeCheck();
            
            GUILayout.Label ("Reminder", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextArea(myString);

            if (EditorGUI.EndChangeCheck())
            {
                info.text = myString;
                info.isRead = false;
                EditorUtility.SetDirty(info);
            }
            
            GUILayout.FlexibleSpace();

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Close"))
            {
                AssetDatabase.SaveAssets();
                this.Close();
            }
            
            if(GUILayout.Button("Mark as read"))
            {
                info.isRead = true;
                EditorUtility.SetDirty(info);
                AssetDatabase.SaveAssets();
                this.Close();
            }
            
            GUILayout.EndHorizontal();
            
            GUILayout.Space(10);
        }
        
        //Open on startup
        
        [InitializeOnLoadMethod]
        private static void InitializeOnLoad() => EditorApplication.delayCall += InitializeWelcomeScreen;
        private static void InitializeWelcomeScreen()
        {
            EditorApplication.delayCall += UpdateWelcomeWindow;
        }
        private static void UpdateWelcomeWindow()
        {
            if (SessionState.GetBool("EDITOR_OPEN", false)) return;
            if (((ReminderInfo)Resources.Load("reminderinfo")).isRead) return;
            
            SessionState.SetBool("EDITOR_OPEN", true);
            EditorWindow.GetWindow(typeof(ReminderEditor), true, "Activity reminder");
        }
        
        //Toolbar buttons
        [InitializeOnLoad]
        public class SceneSwitchLeftButton
        {
            static SceneSwitchLeftButton()
            {
                ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
            }

            static void OnToolbarGUI()
            {
                GUILayout.FlexibleSpace();

                // create a style based on the default label style
                GUIStyle myStyle = new GUIStyle (GUI.skin.button); 
                // do whatever you want with t$$anonymous$$s style, e.g.:
                myStyle.padding=new RectOffset(1,1,3,3);
                myStyle.fixedHeight = 20;
                
                if(GUILayout.Button(new GUIContent(image: (Texture)Resources.Load("EditorIcons/reminder_icon")), 
                       style:myStyle,
                       new GUILayoutOption[]{GUILayout.MaxWidth(30)}))
                {
                    EditorWindow.GetWindow(typeof(ReminderEditor), true, "Activity reminder");
                }
                
                GUILayout.Space(10);
            }
        }
    }
}
