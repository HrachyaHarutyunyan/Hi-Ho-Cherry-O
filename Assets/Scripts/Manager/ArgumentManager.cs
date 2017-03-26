using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArgumentManager : MonoBehaviour {

	public static string GAME_MODE = "game_mode";

	public static ArgumentManager instance;

	public Dictionary<string, object> arguments = new Dictionary<string, object>();

	void Awake () {
		if (instance == null) {
			DontDestroyOnLoad (transform.gameObject);
			instance = this;
		} else {
			Destroy (this);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
