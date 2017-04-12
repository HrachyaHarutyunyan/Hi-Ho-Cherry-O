using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine && myTurn) {
			if (Input.GetMouseButtonDown (0)) {
				photonView.RPC ("SpinRoulette", PhotonTargets.MasterClient, null);
			}
		}
	}

	[PunRPC]
	private void RouletteSpinResult() {
		Roulette.RouletteAction currentAction = GameManager.instance.board.roulette.currentAction;
		int fillCount = 0;
		int emptyCount = 0;
		switch (currentAction) {
		case Roulette.RouletteAction.ONE_CHERRY:
			fillCount = 1;
			break;
		case Roulette.RouletteAction.TWO_CHERRIES:
			fillCount = 2;
			break;
		case Roulette.RouletteAction.THREE_CHERRIES:
			fillCount = 3;
			break;
		case Roulette.RouletteAction.FOUR_CHERRIES:
			fillCount = 4;
			break;
		case Roulette.RouletteAction.DOG:
		case Roulette.RouletteAction.BIRD:
			emptyCount = 2;
			break;
		case Roulette.RouletteAction.SPILLED_BASKET:
			emptyCount = basket.cherries.Count;
			break;
		}
		while (basket.cherries.Count > 0 && emptyCount > 0) {
			emptyCount--;
			Cherry item = basket.cherries [0];
			basket.cherries.Remove (item);
			tree.cherries.Add (item);
			item.MoveToTree (ConstantsManager.instance.cherrysCordination["tree"+tree.index][item.index]);
			item.transform.parent = tree.transform;
		}
		while (tree.cherries.Count > 0 && fillCount > 0) {
			fillCount--;
			Cherry item = tree.cherries [0];
			tree.cherries.Remove (item);
			basket.cherries.Add (item);
			item.MoveToBasket (basket);
			item.transform.parent = basket.transform;
		}
		Debug.Log (playerName + " action is " + currentAction + " tree = " + tree.cherries.Count + " basket = " + basket.cherries.Count);
		if (CheckForWinner ()) {
			Debug.Log (playerName + " hi ho cherry o!!");
			DialogManager.instance.ShowGameOver ();
		} else {
			EndTurn ();
		}
	}

	[PunRPC]
	private void ChangePLayerName(string name) {
		this.name = name;
	}

	[PunRPC]
	public void SpinRoulette() {
		if (PhotonNetwork.isMasterClient) {
			GameManager.instance.board.roulette.SpinRoullette ();
		}
	}

	protected override void RegisterListeners ()
	{
		base.RegisterListeners ();
		EventManager.StartListening (EventManager.PLAYER_SPINED_ROULETTE, GameManager.instance.board.roulette.SpinRoullette);
	}

	protected override void UnregisterListeners ()
	{
		base.UnregisterListeners ();
		EventManager.StopListening (EventManager.PLAYER_SPINED_ROULETTE, GameManager.instance.board.roulette.SpinRoullette);
	}

	[PunRPC]
	public void StartTurnRPC() {
		Debug.Log (playerName + " started his turn with " + tree.cherries.Count + " cherries on tree");
		if (photonView.isMine) {
			myTurn = true;
			RegisterListeners ();
		}
	}
}
