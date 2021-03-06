﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Board : MonoBehaviour {
	public List<Basket> baskets = new List<Basket>();
	public List<Tree> trees = new List<Tree>();
	public Roulette roulette;

	// Use this for initialization
	void Start () {
		InitBoard ();
	}

	private void InitBoard () {
		foreach (var item in GameManager.instance.players) {
			Tree tree = new GameObject ("Tree").AddComponent<Tree> ();
			item.tree = tree;
			tree.transform.parent = transform;
			trees.Add (tree); 
			tree.index = trees.Count - 1;

			SpriteRenderer spriteRenderer = tree.gameObject.AddComponent<SpriteRenderer> ();
			spriteRenderer.sprite =  Resources.Load<Sprite>(item.GetTexturePath ());
			spriteRenderer.sortingOrder = 1;
			tree.gameObject.transform.position = ConstantsManager.instance.treesCordination["tree"+tree.index];
			tree.gameObject.transform.localScale = ConstantsManager.instance.treesScales["tree"+tree.index];
//			tree.gameObject.transform.Rotate(ConstantsManager.instance.treesRotation["tree"+tree.index]);
			tree.Init ();
			Basket basket = new GameObject ("Basket").AddComponent<Basket> ();
			item.basket = basket;
			basket.transform.parent = transform;
			basket.player = item;
			baskets.Add (basket);
		}

		if (PhotonNetwork.isMasterClient) {
			GameObject obj = PhotonNetwork.InstantiateSceneObject ("Prefabs/Roulette", Vector3.zero, Quaternion.identity, 0, null);
			roulette = obj.GetComponent<Roulette> ();
		} else {
			roulette = GameObject.FindObjectOfType<Roulette> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
