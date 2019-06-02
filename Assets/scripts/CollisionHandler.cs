using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        print("Player hit something Trigger");
        this.SendMessage("stopInput");
        deathFx.SetActive(true);
        Invoke("reloadScene", levelLoadDelay);
    }

    private void reloadScene()
    {
        SceneManager.LoadScene(1);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
