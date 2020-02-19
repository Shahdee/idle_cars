using UnityEngine;
using System.IO;
using System.Collections;
using UnityEngine.Events;

public class DataLoader 
{
    GameData gameData;

    const string dataFileName = "data.json";

    public DataLoader(){

    }

    public GameData GetGameData(){
        return gameData;
    }

    public IEnumerator LoadGameData (UnityAction callback)
    {   
        string filePath = Path.Combine(Application.streamingAssetsPath, dataFileName); 
        string dataAsJson;

        if (filePath.Contains ("://") || filePath.Contains (":///")) 
        {
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get (filePath);
            yield return www.SendWebRequest();
            dataAsJson = www.downloadHandler.text;
        } else 
        {
            dataAsJson = File.ReadAllText (filePath);
        }

        Debug.Log(dataAsJson);                    
        gameData = JsonUtility.FromJson<GameData>(dataAsJson);

        if (callback != null)                
            callback();
    }
}
