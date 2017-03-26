using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Roulette : MonoBehaviour {

	public enum RouletteAction {
		ONE_CHERRY = 1,
		TWO_CHERRIES,
		THREE_CHERRIES,
		FOUR_CHERRIES,
		DOG,
		BIRD,
		SPILLED_BASKET
	}

	public RouletteAction currentAction;

	private int sectionCount;

	// Use this for initialization
	void Start () {
		sectionCount = Enum.GetValues (typeof(RouletteAction)).Length;
		EventManager.TriggerEvent (EventManager.CHERRIES_CREATED);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpinRoullette() {
		currentAction = (RouletteAction)UnityEngine.Random.Range (1, sectionCount + 1);
		EventManager.TriggerEvent (EventManager.ROULETTE_SPIN_ENDED);
	}
}
