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
		if (photonView.isMine) {
			myTurn = false;
			UnregisterListeners ();
			EventManager.TriggerEvent (EventManager.TURN_ENDED);
		}
	}

	protected bool CheckForWinner() {
		return tree.cherries.Count == 0;
	}

	protected virtual void RegisterListeners() {
		EventManager.StartListening (EventManager.ROULETTE_SPIN_ENDED, RouletteSpiningEnded);
	}

	protected virtual void UnregisterListeners() {
		EventManager.StopListening (EventManager.ROULETTE_SPIN_ENDED, RouletteSpiningEnded);
	}

	private void RouletteSpiningEnded() {
		photonView.RPC ("RouletteSpinResult", PhotonTargets.AllViaServer, null);
	}
}
