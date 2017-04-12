using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public int index;
	public static int CHERRY_COUNT = 10;

	public List<Cherry> cherries = new List<Cherry>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < CHERRY_COUNT; i++) {
			Cherry cherry = new GameObject ("Cherry").AddComponent<Cherry> ();
			cherry.transform.parent = transform;
			cherries.Add (cherry);
			cherry.index = cherries.Count - 1;
			SpriteRenderer spriteRenderer = cherry.gameObject.AddComponent<SpriteRenderer> ();
			spriteRenderer.sprite =  Resources.Load<Sprite>("Textures/cherry");
			spriteRenderer.sortingOrder = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
