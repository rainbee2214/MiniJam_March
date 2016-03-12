using UnityEngine;
using System.Collections;

public class StartBackgroundMusic : MonoBehaviour
{

    public BGMusic musicType = BGMusic.Title;

	void Start ()
    {
        AudioController.controller.PlaySong(musicType);
	}

}
