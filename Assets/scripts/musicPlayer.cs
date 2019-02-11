using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class musicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        Invoke("loadFirstScene", 3f);
    }
	

    void loadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
