using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public GUIMan guiMan;

    public EntityMan entityMan;
    
    ItemMan itemMan;

    public LevelMan levelMan;
    DataLoader dataLoader;
    Player player;

    public InputMan inputMan;

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

    public InputMan GetInputMan(){
        return inputMan;
    }

    public enum GameStates{
        Menu,
        Play,
        Over,
    }

    void Start()
    {
        instance = this;

        itemMan = new ItemMan();
        dataLoader = new DataLoader();
        player = new Player();

        onDataLoaded();

        guiMan.Init();
    }

    void onDataLoaded(){
        var gameData = dataLoader.GetGameData();
        itemMan.PrepareItems(gameData);
        player.Setup(gameData.player);
    }

    public void StartGame(){
        player.Restore();
        levelMan.StartLevel();
    }


    void FixedUpdate(){
        levelMan.UpdatePhysics(Time.fixedDeltaTime);
    }
    
    void Update()
    {
        inputMan.UpdateMe(Time.deltaTime);        
        levelMan.UpdateMe(Time.deltaTime);       
        guiMan.UpdateMe(Time.deltaTime);
    }
}
