using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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
		PlayerBehaviour player = new GameObject ("Player").AddComponent<Player> ();
		player.playerName = "player";
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
		for (int i = 1; i < size; i++) {
			player = new GameObject ("PLayerAI").AddComponent<PlayerAI> ();
			player.playerName = "ai-" + i;
			players.Add (player);
		}
	}

	public void CreateGame() {
		CreateGameBoard ();
		GameMode mode = ArgumentManager.instance != null ? (GameMode)ArgumentManager.instance.arguments [ArgumentManager.GAME_MODE] : GameMode.FOUR_PLAYER;
		InitPlayers (mode);
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
