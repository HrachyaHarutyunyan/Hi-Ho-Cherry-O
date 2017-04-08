using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

	public GameObject gameOverPanel;

	public static DialogManager instance;


	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

	public void ShowGameOver(){
		gameOverPanel.SetActive (true);
	}

	public void HideGameOver(){
		gameOverPanel.SetActive (false);
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
