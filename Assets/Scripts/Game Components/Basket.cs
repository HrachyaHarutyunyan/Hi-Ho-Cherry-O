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
		if (PhotonNetwork.isMasterClient) {
			spriteRenderer.sprite = Resources.Load<Sprite> ("Textures/dzmer1v");
			transform.position = ConstantsManager.instance.basketCordination["dzmer1v"];
		} else {
			spriteRenderer.sprite = Resources.Load<Sprite> ("Textures/garun_v");
			transform.position = ConstantsManager.instance.basketCordination["garun_v"];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
