﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : Photon.MonoBehaviour {

	public enum GameMode
	{
		MULTI_TWO_PLAYER = 2,
		MULTI_THREE_PLAYER,
		MULTI_FOUR_PLAYER,
		SINGLE_TWO_PLAYER,
		SINGLE_THREE_PLAYER,
		SINGLE_FOUR_PLAYER,
	}

	List<int> seasonIndices = new List<int> ();

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
		for (int i = 0; i < 4; i++) {
			seasonIndices.Add (i);
		}
	}

	public void CreateGameBoard() {
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

	public void InitSinglePlayer(GameMode mode) {
		GameObject playerObj = PhotonNetwork.Instantiate ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0);
		playerObj.name = PhotonNetwork.playerName;
		PlayerBehaviour player = playerObj.GetComponent<Player> ();
		player.playerName = PhotonNetwork.playerName;
		player.photonView.RPC ("SetEmpty", PhotonTargets.AllBuffered, false);
		players.Add (player);
		int index = UnityEngine.Random.Range (0, seasonIndices.Count);
		photonView.RPC ("SetPlayerSeason", PhotonTargets.All, new object[] {0, seasonIndices[index]});
		seasonIndices.Remove (index);
		int size = 0;
		switch (mode) {
		case GameMode.SINGLE_TWO_PLAYER:
			size = 2;
			break;
		case GameMode.SINGLE_THREE_PLAYER:
			size = 3;
			break;
		case GameMode.SINGLE_FOUR_PLAYER:
			size = 4;
			break;
		}
		for (int i = 1; i < size; i++) {
			playerObj = PhotonNetwork.Instantiate ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0);
			player = playerObj.GetComponent<Player> ();
			player.playerName = "EmptyPlayer" + i;
			player.name = "EmptyPlayer";
			players.Add (player);
			index = UnityEngine.Random.Range (0, seasonIndices.Count);
			photonView.RPC ("SetPlayerSeason", PhotonTargets.All, new object[] {i, seasonIndices[index]});
			seasonIndices.Remove (index);
		}
		Debug.Log ("single players loaded");
	}

	public void InitMultiPlayers(GameMode mode) {
		if (PhotonNetwork.isMasterClient) {
			GameObject playerObj = PhotonNetwork.Instantiate ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0);
			playerObj.name = PhotonNetwork.playerName;
			PlayerBehaviour player = playerObj.GetComponent<Player> ();
			player.playerName = PhotonNetwork.playerName;
			player.photonView.RPC ("SetEmpty", PhotonTargets.AllBuffered, false);
			players.Add (player);
			int index = UnityEngine.Random.Range (0, seasonIndices.Count);
			photonView.RPC ("SetPlayerSeason", PhotonTargets.All, new object[] {0, seasonIndices[index]});
			seasonIndices.Remove (index);
			int size = 0;
			switch (mode) {
			case GameMode.MULTI_TWO_PLAYER:
				size = 2;
				break;
			case GameMode.MULTI_THREE_PLAYER:
				size = 3;
				break;
			case GameMode.MULTI_FOUR_PLAYER:
				size = 4;
				break;
			}
			for (int i = 1; i < size; i++) {
				playerObj = PhotonNetwork.Instantiate ("Prefabs/Player", Vector3.zero, Quaternion.identity, 0);
				player = playerObj.GetComponent<Player> ();
				player.playerName = "EmptyPlayer" + i;
				player.name = "EmptyPlayer";
				players.Add (player);
				index = UnityEngine.Random.Range (0, seasonIndices.Count);
				photonView.RPC ("SetPlayerSeason", PhotonTargets.All, new object[] {i, seasonIndices[index]});
				seasonIndices.Remove (index);
			}
		} else {
			EventManager.StopListening (EventManager.ROULETTE_CREATED, CreateGame);
			Player[] players = GameObject.FindObjectsOfType<Player> ();
			foreach (var item in players) {
				this.players.Add (item);
			}
			bool itemTaken = false;
			foreach (var item in players) {
				if (item.isEmpty && !itemTaken) {
					itemTaken = true;
					Debug.Log ("item.issceneview = " + item.photonView.owner);
					item.playerName = PhotonNetwork.playerName; 
					item.photonView.RequestOwnership ();
					item.photonView.RPC ("SetEmpty", PhotonTargets.AllBuffered, false);
					item.photonView.RPC ("ChangePLayerName", PhotonTargets.AllBuffered, PhotonNetwork.playerName);
				} else {
					item.name = "master";
					item.playerName = item.name;
				}
				item.InitSeason ();
			}
		}
	}

	public void CreateGame() {
		GameMode mode = ArgumentManager.instance != null ? (GameMode)ArgumentManager.instance.arguments [ArgumentManager.GAME_MODE] : GameMode.SINGLE_FOUR_PLAYER;
		if ((int)mode < 5) {
			InitMultiPlayers (mode);
		} else {
			InitSinglePlayer (mode);
		}
		if (PhotonNetwork.isMasterClient) {
			CreateGameBoard ();
		}
	}

	public void StartGame() {
		if (PhotonNetwork.isMasterClient) {
			int playerIndex = UnityEngine.Random.Range (0, players.Count);
			PlayerBehaviour tmp = players [0];
			players [0] = players [playerIndex];
			players [playerIndex] = tmp;

			currentPlayerIndex = 0;
			players [currentPlayerIndex].StartTurn ();
		}
	}

	[PunRPC]
	private void SetPlayerSeason(int playerIndex, int seasonIndex) {
		players[playerIndex].season = (SeasonType)Enum.GetValues (typeof(SeasonType)).GetValue (seasonIndex);
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
