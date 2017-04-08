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
				EventManager.TriggerEvent (EventManager.PLAYER_SPINED_ROULETTE);
			}
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
		if (photonView.isMine) {
			Debug.Log (playerName + " started his turn with " + tree.cherries.Count + " cherries on tree");
			myTurn = true;
			RegisterListeners ();
		}
	}
}
