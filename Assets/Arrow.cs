using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Photon.MonoBehaviour {

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
		stopAcceleration = Random.Range (MIN_STOP_ACCELERATION, MAX_STOP_ACCELERATION);
		speed = Random.Range (MIN_SPEED, MAX_SPEED);
		photonView.RPC ("SpinRPC", PhotonTargets.AllViaServer, new object[]{stopAcceleration, speed});
	}

	public void SpinRPC(float stopAcceleration, float speed) {
		arrowStoped = false;
		this.stopAcceleration = stopAcceleration;
		this.speed = speed;
	}

	private void ArrowRotate() {
		if (!arrowStoped) {
			if (speed > 0) {
				transform.Rotate (Vector3.back, speed * Time.deltaTime);
				speed -= stopAcceleration * Time.deltaTime;
			} else {
				photonView.RPC ("ArrowStop", PhotonTargets.All, null);
			}
		}
	}

	[PunRPC]
	private void ArrowStop() {
		arrowStoped = true;
		GameManager.instance.board.roulette.currentAction = currentSector.GetComponent<Sector> ().action;
		EventManager.TriggerEvent (EventManager.ROULETTE_SPIN_ENDED);
	}

//	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
//		if (stream.isWriting) {
//			stream.SendNext (transform.rotation);
//		} else {
//			transform.rotation =  Quaternion.Lerp(transform.rotation,(Quaternion)stream.ReceiveNext (),Time.deltaTime*speed);
//		}
//	}
}
