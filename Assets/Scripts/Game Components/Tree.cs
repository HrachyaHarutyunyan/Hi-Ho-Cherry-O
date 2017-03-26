using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public static int CHERRY_COUNT = 10;

	public List<Cherry> cherries = new List<Cherry>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < CHERRY_COUNT; i++) {
			Cherry cherry = new GameObject ("Cherry").AddComponent<Cherry> ();
			cherry.transform.parent = transform;
			cherries.Add (cherry);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
