﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Photon.MonoBehaviour {

	public enum GameMode
	{
		TWO_PLAYER = 2,
		THREE_PLAYER,
		FOUR_PLAYER,
		MULTIPLAYER
	}

	public static GameManager instance;

	public List<PlayerBehaviour> players = new List<PlayerBehaviour>();
	public Board board;
	public int currentPlayerIndex;

	private int playersEndedCount = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
		RegisterListeners ();
	}

	private void CreateGameBoard() {
		board = new GameObject ("Board").AddComponent<Board> ();
		board.gameObject.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/background");
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void CherriesCreated() {
		StartGame ();
	}

	private void RegisterListeners() {
		EventManager.StartListening (EventManager.TURN_ENDED, TurnEnded);
		EventManager.StartListening (EventManager.CHERRIES_CREATED, CherriesCreated);
	}

	public void InitPlayers(GameMode mode) {
		if (PhotonNetwork.isMasterClient) {
			GameObject playerObj = PhotonNetwork.Instantiate ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0);
			playerObj.name = PhotonNetwork.playerName;
			PlayerBehaviour player = playerObj.GetComponent<Player> ();
			player.playerName = PhotonNetwork.playerName;
			players.Add (player);
			int size = 0;
			switch (mode) {
			case GameMode.TWO_PLAYER:
				size = 2;
				break;
			case GameMode.THREE_PLAYER:
				size = 3;
				break;
			case GameMode.FOUR_PLAYER:
				size = 4;
				break;
			case GameMode.MULTIPLAYER:
				size = 1;
				break;
			}
			size = 2;
			for (int i = 1; i < size; i++) {
				playerObj = PhotonNetwork.InstantiateSceneObject ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0, null);
				player = playerObj.GetComponent<Player> ();
				player.playerName = "EmptyPlayer" + i;
				player.name = "EmptyPlayer";
				players.Add (player);
			}
		} else {
			EventManager.StopListening (EventManager.ROULETTE_CREATED, CreateGame);
			Player[] players = GameObject.FindObjectsOfType<Player> ();
			foreach (var item in players) {
				this.players.Add (item);
			}
			foreach (var item in players) {
				if (item.photonView.isSceneView) {
					item.playerName = PhotonNetwork.playerName;
					item.photonView.TransferOwnership (PhotonNetwork.player);
					item.photonView.RPC ("ChangePLayerName", PhotonTargets.All, PhotonNetwork.playerName);
				} else {
					item.name = "master";
					item.playerName = item.name;
				}
			}
		}
	}

	public void CreateGame() {
		CreateGameBoard ();
		GameMode mode = ArgumentManager.instance != null ? (GameMode)ArgumentManager.instance.arguments [ArgumentManager.GAME_MODE] : GameMode.FOUR_PLAYER;
		InitPlayers (mode);
	}

	public void StartGame() {
		if (PhotonNetwork.isMasterClient) {
			int playerIndex = Random.Range (0, players.Count);
			PlayerBehaviour tmp = players [0];
			players [0] = players [playerIndex];
			players [playerIndex] = tmp;

			currentPlayerIndex = 0;
			players [currentPlayerIndex].StartTurn ();
		}
	}

	public void TurnEnded() {
		photonView.RPC ("TurnEndedRPC", PhotonTargets.MasterClient, null);
	}

	[PunRPC]
	private void TurnEndedRPC() {
		playersEndedCount++;
		if (playersEndedCount == players.Count) {
			playersEndedCount = 0;
			currentPlayerIndex++;
			if (currentPlayerIndex == players.Count) {
				currentPlayerIndex = 0;
			}

			players [currentPlayerIndex].StartTurn ();
		}
	}
}
