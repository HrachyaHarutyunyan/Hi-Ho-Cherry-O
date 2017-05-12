using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public int index;
	public static int CHERRY_COUNT = 10;

	public List<Cherry> cherries = new List<Cherry>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init(){
		for (int i = 0; i < CHERRY_COUNT; i++) {
			Cherry cherry = new GameObject ("Cherry").AddComponent<Cherry> ();
			cherry.transform.parent = transform;
			cherries.Add (cherry);
			cherry.index = i;
			SpriteRenderer spriteRenderer = cherry.gameObject.AddComponent<SpriteRenderer> ();
			spriteRenderer.sprite =  Resources.Load<Sprite>("Textures/cherry");
			spriteRenderer.sortingOrder = 3;
			cherry.gameObject.transform.localPosition = ConstantsManager.instance.cherrysCordination["tree"+index][cherry.index];
		}
	}
}
