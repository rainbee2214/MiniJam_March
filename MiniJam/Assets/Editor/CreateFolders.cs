using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;

public class CreateFolders : MonoBehaviour
{
    static string[] allFolders = { "Scripts", "Scenes", "Resources", "Prefabs", "Audio", "Animations", "Fonts", "Sprites" };
    [MenuItem("Folders/CreateAll")]
    private static void CreateAll()
    {
        for (int i = 0; i < allFolders.Length; i++)
        {
            if (!(AssetDatabase.IsValidFolder("Assets/" + allFolders[i]) || AssetDatabase.IsValidFolder("Assets/Resources/" + allFolders[i])))
            {
                AssetDatabase.CreateFolder("Assets", allFolders[i]);
            }
        }
    }
    [MenuItem("Folders/CreateResources")]
    private static void CreateResources()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Resources/"))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
        }
        for (int i = 3; i < allFolders.Length; i++)
        {
            if (!AssetDatabase.IsValidFolder("Assets/Resources/" + allFolders[i]))
            {
                AssetDatabase.CreateFolder("Assets/Resources", allFolders[i]);
            }
        }
    }

    //load assets in root folder and place them based on type
    //static int numberOfCharactersInPath = 82;
    //[MenuItem("Folders/MoveAssets")]
    //public static void GetAtPath()
    //{
    //    //string[] fileEntries = Directory.GetFiles(Application.dataPath);
    //    //{
    //    //    string i = fileName.Substring(numberOfCharactersInPath, fileName.IndexOf(".")-numberOfCharactersInPath);
    //    //    GameObject t = (GameObject)AssetDatabase.LoadAssetAtPath(i, typeof(GameObject));
    //    //    Debug.Log(i);
    //    //    Debug.Log(t);
    //    //}

    //    GameObject Board = (GameObject)AssetDatabase.LoadAssetAtPath("Board", typeof(GameObject));
    //    Debug.Log(Board.name);

    //}
}
