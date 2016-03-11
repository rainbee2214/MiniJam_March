using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    //public Player player;

    void Awake()
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

        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }



}
