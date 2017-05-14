using UnityEngine;
using System;

public enum SeasonType {
	WINTER,
	SPRING,
	SUMMER,
	AUTUMN
}

public abstract class PlayerBehaviour : Photon.MonoBehaviour {
	public Basket basket;
	public Tree tree;
	public string playerName;
	public bool myTurn;
	public SeasonType season;

	private string texturePath = "";

	public string GetTexturePath() {
		if (texturePath.Equals ("")) {
			texturePath += "Textures/";
			if (season == SeasonType.WINTER) {
				texturePath += "winter";
			} else if (season == SeasonType.SPRING) {
				texturePath += "spring";
			} else if (season == SeasonType.AUTUMN) {
				texturePath += "autumn";
			} else if (season == SeasonType.SUMMER) {
				texturePath += "summer";
			}
			if (GameManager.instance.players.IndexOf (this) % 2 != 0) {
				texturePath += "R";
			}
		}
		return texturePath;
	}

	public virtual void StartTurn() {
		photonView.RPC ("StartTurnRPC", PhotonTargets.AllViaServer, null);
	}

	public void EndTurn() {
		UnregisterListeners ();
//		if (photonView.isMine) {
			EventManager.TriggerEvent (EventManager.TURN_ENDED);
//		}
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

	public virtual void RouletteSpiningEnded() {
//		Debug.Log ("RouletteSpiningEndedRouletteSpiningEndedRouletteSpiningEndedRouletteSpiningEndedRouletteSpiningEnded");
		//		photonView.RPC ("RouletteSpinResult", PhotonTargets.AllViaServer, null);
	}

	public void InitSeason() {
		photonView.RPC ("RequestSeason", PhotonTargets.MasterClient, null);
	}


}
