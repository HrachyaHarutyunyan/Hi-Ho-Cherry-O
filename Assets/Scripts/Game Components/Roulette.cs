using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon;

public class Roulette : PunBehaviour {

	public enum RouletteAction {
		ONE_CHERRY = 1,
		TWO_CHERRIES,
		THREE_CHERRIES,
		FOUR_CHERRIES,
		DOG,
		BIRD,
		SPILLED_BASKET
	}

	public Arrow arrow;
	[SerializeField]
	public List<Sector> sector;


	public RouletteAction currentAction;

	private int sectionCount;

	// Use this for initialization
	void Start () {
		sectionCount = Enum.GetValues (typeof(RouletteAction)).Length;
		EventManager.TriggerEvent (EventManager.CHERRIES_CREATED);
		SpinRoullette ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SpinRoullette() {
		arrow.StartSpin ();
	}
}
