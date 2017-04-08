using UnityEngine;
using System;

public abstract class PlayerBehaviour : Photon.MonoBehaviour {
	public Basket basket;
	public Tree tree;
	public string playerName;
	public bool myTurn;

	public virtual void StartTurn() {
		photonView.RPC ("StartTurnRPC", PhotonTargets.AllViaServer, null);
	}

	public void EndTurn() {
		myTurn = false;
		UnregisterListeners ();
		EventManager.TriggerEvent (EventManager.TURN_ENDED);
	}

	private void RouletteSpiningEnded() {
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
			item.transform.parent = tree.transform;
		}
		while (tree.cherries.Count > 0 && fillCount > 0) {
			fillCount--;
			Cherry item = tree.cherries [0];
			tree.cherries.Remove (item);
			basket.cherries.Add (item);
			item.transform.parent = basket.transform;
		}
		Debug.Log (playerName +  " action is " + currentAction + " tree = " + tree.cherries.Count + " basket = " + basket.cherries.Count);
		if (CheckForWinner ()) {
			Debug.Log (playerName + " hi ho cherry o!!");
		} else {
			EndTurn ();
		}
	}

	private bool CheckForWinner() {
		return tree.cherries.Count == 0;
	}

	protected virtual void RegisterListeners() {
		EventManager.StartListening (EventManager.ROULETTE_SPIN_ENDED, RouletteSpiningEnded);
	}

	protected virtual void UnregisterListeners() {
		EventManager.StopListening (EventManager.ROULETTE_SPIN_ENDED, RouletteSpiningEnded);
	}
}
