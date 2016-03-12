using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[System.Serializable]
public enum State
{
    TitleScreen,
    Level1,
    Level2, 
    GameOver,
    ResetGame 
}

[System.Serializable]
public class GameParameters
{
    //things that we will start the game with for saved games, score, health, time etc
}
public class GameController : MonoBehaviour
{
    public static GameController controller;
    #region SceneNames
    public static string titleScreenName = "Title";
    public static string levelName = "Level";
    public static string gameOverName = "GameOver";
    public static string baseLevelName = "Base";
    #endregion

    //Have a set of properties that match fiels in game parameters (for saving)

    public void Awake()
    {
        if (controller == null)
        {
            controller = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        ChangeState(State.TitleScreen);
    }

    //All level loading is done through state changes
    public void ChangeState(State newState)
    {
        //Make one function per state change
        switch (newState)
        {
            case State.TitleScreen: TitleScreen(); break;
            case State.Level1: Level(1); break;
            case State.Level2: Level(2); break;
            case State.GameOver: GameOver(); break;
            case State.ResetGame: TitleScreen(); break;
        }
        foreach(Scene s in SceneManager.GetAllScenes())
        {
            Debug.Log(s.name);
        }
    }

    public void ChangeState(string newState)
    {
        //Make one function per state change
        switch (newState)
        {
            case "Title": ChangeState(State.TitleScreen); break;
            case "TitleScreen": ChangeState(State.TitleScreen); break;
            case "Level": ChangeState(State.Level1); break;
            case "Level1": ChangeState(State.Level1); break;
            case "Level2": ChangeState(State.Level1); break;
            case "GameOver": ChangeState(State.GameOver); break;
            case "ResetGame": ChangeState(State.TitleScreen); break;
        }
    }
    void TitleScreen()
    {
        //find references to canvases
        //SceneManager.LoadScene(baseLevelName);
        SceneManager.LoadScene(titleScreenName);
    }
    void Level(int level)
    {
        //Get the game parameters from the new game canvas
        SceneManager.LoadScene(levelName);
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverName);
    }

    void SetGameParameters(GameParameters parameters)
    {
        //extract the game controller properties from parameters
    }

    GameParameters LoadGameParametersFromSave()
    {
        //Not sure how to link this yet
        return new GameParameters();
    }
}
