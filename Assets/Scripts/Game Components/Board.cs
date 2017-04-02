using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board : Photon.MonoBehaviour {
	public List<Basket> baskets = new List<Basket>();
	public List<Tree> trees = new List<Tree>();
	public Roulette roulette;

	// Use this for initialization
	void Start () {
		InitBoard ();
	}

	private void InitBoard() {
		foreach (var item in GameManager.instance.players) {
			Tree tree = new GameObject ("Tree").AddComponent<Tree> ();
			item.tree = tree;
			tree.transform.parent = transform;
			trees.Add (tree);

			Basket basket = new GameObject ("Basket").AddComponent<Basket> ();
			item.basket = basket;
			basket.transform.parent = transform;
			baskets.Add (basket);
		}
		GameObject obj = PhotonNetwork.Instantiate ("Prefabs/Roulette", Vector3.zero, Quaternion.identity, 0);
		roulette = obj.GetComponent<Roulette> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
