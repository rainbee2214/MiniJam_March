/**********************************************************************
 * Sacred Seed Studio
 * LevelLoader
 * v0.1.0
 *
 * A simple scene loader
 *
 * Created: February 5 2016
 * Modified: February 5 2016
 *********************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string sceneToLoad = "Main";
    public bool allowButtonLoad = false;
    public string loadButton = "Drop";

    void Update()
    {
        if (allowButtonLoad && Input.GetButtonDown(loadButton))
        {
            GameController.controller.ChangeState(State.Level1);
        }
    }

    public void LoadScene(string s)
    {
        GameController.controller.ChangeState(s);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
