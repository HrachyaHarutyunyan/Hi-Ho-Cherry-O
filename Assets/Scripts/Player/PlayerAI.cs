using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : PlayerBehaviour {

	public override void StartTurn ()
	{
		base.StartTurn ();
		GameManager.instance.board.roulette.SpinRoullette ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
