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

	float timer = 0.1f;
	float TIME = 0.1f;

	GameObject preCalcArrow;

	void Awake(){
		arrowStoped = true;
		if(PhotonNetwork.isMasterClient) {
			preCalcArrow = new GameObject ();
			preCalcArrow.transform.parent = transform.parent;
		}
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
				preCalcArrow.transform.Rotate (Vector3.back, speed * Time.deltaTime);
				timer += Time.deltaTime;
				if (timer > TIME) {
					photonView.RPC ("RotateRPC", PhotonTargets.AllViaServer, preCalcArrow.transform.eulerAngles);
					timer = 0;
				}
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

	[PunRPC]
	private void RotateRPC(Vector3 eulerAngles) {
		transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, eulerAngles, Time.deltaTime * 150);
	}
}
