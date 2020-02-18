using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class GameDataEditor : EditorWindow
{
    string gameDataProjectFilePath = "/StreamingAssets/data.json";
    public GameData gameData;

    [MenuItem("Window/Data json editor")]
    static void Init(){
        GameDataEditor window = (GameDataEditor)EditorWindow.GetWindow(typeof(GameDataEditor));
        window.Show();
    }

    void OnGUI(){
        if (gameData != null){

            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("gameData");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save game data")){
                SaveGameData();
            }   
                    
        }
        
        if (GUILayout.Button("Load game data")){
            LoadGameData();
        }
    }

    void LoadGameData(){
        string filePath = Application.dataPath + gameDataProjectFilePath;
        if (File.Exists(filePath)){
            string dataAsJson = File.ReadAllText(filePath);

            Debug.Log(dataAsJson);

            gameData = JsonUtility.FromJson<GameData>(dataAsJson);
        }
        else{
            gameData = new GameData();
        }
    }

    void SaveGameData(){
        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
}
