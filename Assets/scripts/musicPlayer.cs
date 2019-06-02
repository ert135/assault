using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int numMusicPlayers = FindObjectsOfType<musicPlayer>().Length;
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject)
        } else
        {
            DontDestroyOnLoad(this);
        }
    }
}
