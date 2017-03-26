using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PreferenceManager : MonoBehaviour {
	
	public static PreferenceManager instance;

	void Awake () {
		if (instance == null) {
			DontDestroyOnLoad (transform.gameObject);
			instance = this;
		} else {
			Destroy (this);
		}
	}
}