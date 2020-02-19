using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMan : MonoBehaviour
{
    public GUIMan guiMan;

    public EntityMan entityMan;
    
    ItemMan itemMan;

    public LevelMan levelMan;
    DataLoader dataLoader;
    Player player;

    static GameMan _instance;
    public static GameMan instance{
        get{return _instance;}
        private set{_instance = value;}
    }

    public EntityMan GetEntityMan(){
        return entityMan;
    }

    public LevelMan GetLevelMan(){
        return levelMan;
    }

    public GUIMan GetGUIMan(){
        return guiMan;
    }

    public ItemMan GetItemMan(){
        return itemMan;
    }

    public Player GetPlayer(){
        return player;
    }

    void Start()
    {
        instance = this;

        itemMan = new ItemMan();
        dataLoader = new DataLoader();
        player = new Player();

        StartCoroutine(dataLoader.LoadGameData(onDataLoaded));

        guiMan.Init();
    }

    void onDataLoaded(){
        Debug.Log("data loaded");
        var gameData = dataLoader.GetGameData();
        itemMan.PrepareItems(gameData);
        player.Setup(gameData.player);
    }

    void FixedUpdate(){
        levelMan.UpdatePhysics(Time.fixedDeltaTime);
    }
    
    void Update()
    {
        levelMan.UpdateMe(Time.deltaTime);       
        guiMan.UpdateMe(Time.deltaTime);
    }
}
