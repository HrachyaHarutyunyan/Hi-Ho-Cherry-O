using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour {

	public enum GameMode
	{
		TWO_PLAYER,
		THREE_PLAYER,
		FOUR_PLAYER,
		MULTIPLAYER
	}

	public static GameManager instance;

	public List<PlayerBehaviour> players = new List<PlayerBehaviour>();
	public int currentPlayerIndex;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
		InitPlayers (GameMode.FOUR_PLAYER);
		StartGame ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void RegisterListeners() {
		EventManager.StartListening (EventManager.TURN_ENDED, TurnEnded);
	}

	public void InitPlayers(GameMode mode) {
		int size = 0;
		players.Add (new GameObject("Player").AddComponent<Player> ());
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
		for (int i = 1; i < size; i++) {
			players.Add (new GameObject("PLayerAI").AddComponent<PlayerAI> ());
		}
	}

	public void StartGame() {
		int playerIndex = Random.Range (0, players.Count - 1);
		PlayerBehaviour tmp = players [0];
		players [0] = players [playerIndex];
		players [playerIndex] = tmp;

		currentPlayerIndex = 0;
		players [currentPlayerIndex].StartTurn ();
	}

	public void TurnEnded() {
		currentPlayerIndex++;
		if (currentPlayerIndex == players.Count) {
			currentPlayerIndex = 0;
		}
		players [currentPlayerIndex].StartTurn ();
	}
}
