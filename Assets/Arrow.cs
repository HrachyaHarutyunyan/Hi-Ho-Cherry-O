using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	private readonly float MIN_SPEED = 400;
	private readonly float MAX_SPEED = 600;

	private readonly float MIN_STOP_ACCELERATION = 80;
	private readonly float MAX_STOP_ACCELERATION = 100;
	private float stopAcceleration;

	public  float speed  = 0;
	public  Collider2D currentSector;
	public bool arrowStoped = true;

	void Awake(){
		arrowStoped = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () { 
		ArrowRotate ();
	}

	public void StartSpin() {
		arrowStoped = false;
		stopAcceleration = Random.Range (MIN_STOP_ACCELERATION, MAX_STOP_ACCELERATION);
		speed = Random.Range (MIN_SPEED, MAX_SPEED);
	}

	private void ArrowRotate() {
		if (!arrowStoped) {
			if (speed > 0) {
				transform.Rotate (Vector3.back, speed * Time.deltaTime);
				speed -= stopAcceleration * Time.deltaTime;
			} else {
				ArrowStop ();
			}
		}
	}

	private void ArrowStop() {
		arrowStoped = true;
		GameManager.instance.board.roulette.currentAction = currentSector.GetComponent<Sector> ().action;
		EventManager.TriggerEvent (EventManager.ROULETTE_SPIN_ENDED);
	}
}
