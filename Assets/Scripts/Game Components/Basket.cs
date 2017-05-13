using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public PlayerBehaviour player;
	public List<Cherry> cherries = new List<Cherry>();

	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.AddComponent<SpriteRenderer> ();
		string texturePath = player.GetTexturePath () + "B";
		spriteRenderer.sprite = Resources.Load<Sprite> (texturePath);
		transform.position = ConstantsManager.instance.basketCordination [texturePath];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
