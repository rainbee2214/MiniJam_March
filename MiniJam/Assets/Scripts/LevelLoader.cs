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
    public string loadButton = "Submit";

    void Update()
    {
        if (allowButtonLoad && Input.GetButtonDown(loadButton))
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
