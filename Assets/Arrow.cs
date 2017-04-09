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
	public bool startSpin;

	private Vector3 finalRotation;

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
		if (!startSpin) {
			finalRotation = Vector3.zero;
			startSpin = true;
			stopAcceleration = Random.Range (MIN_STOP_ACCELERATION, MAX_STOP_ACCELERATION);
			speed = Random.Range (MIN_SPEED, MAX_SPEED);
			photonView.RPC ("SpinRPC", PhotonTargets.AllViaServer, new object[]{ stopAcceleration, speed });
		}
	}

	[PunRPC]
	public void SpinRPC(float stopAcceleration, float speed) {
		arrowStoped = false;
		Debug.Log ("speed = " + speed);
		Debug.Log ("stopAcceleration = " + stopAcceleration);
		this.stopAcceleration = stopAcceleration;
		this.speed = speed;
	}
	 
	private void ArrowRotate() {
		if (!arrowStoped) {
			if (speed > 0) {
				transform.Rotate (Vector3.back, speed * Time.deltaTime);
				speed -= stopAcceleration * Time.deltaTime;
			} else {
				if (PhotonNetwork.isMasterClient) {
					Debug.Log ("stop arrow !!!!!!!!!!!!");
					photonView.RPC ("ArrowStop", PhotonTargets.AllViaServer, transform.rotation.eulerAngles);
				} else if(finalRotation != Vector3.zero) {
					Quaternion rot = transform.rotation;
					rot.eulerAngles = finalRotation;
					transform.rotation = rot;
				}
				startSpin = false;
				arrowStoped = true;
				GameManager.instance.board.roulette.currentAction = currentSector.GetComponent<Sector> ().action;
				EventManager.TriggerEvent (EventManager.ROULETTE_SPIN_ENDED);
			}
		}
	}

	[PunRPC]
	private void ArrowStop(Vector3 rotation) {
		finalRotation = rotation;
		if (arrowStoped) {
			Quaternion rot = transform.rotation;
			rot.eulerAngles = finalRotation;
			transform.rotation = rot;
		}
	}

//	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
//		if (stream.isWriting) {
//			stream.SendNext (transform.rotation);
//		} else {
//			transform.rotation =  Quaternion.Lerp(transform.rotation,(Quaternion)stream.ReceiveNext (),Time.deltaTime*speed);
//		}
//	}
}
