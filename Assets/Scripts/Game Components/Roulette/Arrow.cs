using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Photon.MonoBehaviour {

	public  Collider2D currentSector;
	public bool arrowStoped = true;
	public  float eulerAngle  = 0;

	private readonly float MIN_EULERANGLE = 3;
	private readonly float MAX_EULERANGLE = 7;
	private float oneRotateTime = 1f;
	private float rotateTime = 1f;
	public bool startSpin;

	public void StartSpin() {
		if (!startSpin) {
			startSpin = true;
			eulerAngle = Random.Range (MIN_EULERANGLE, MAX_EULERANGLE);
			oneRotateTime = Random.Range (0.8f, 1.4f);
			photonView.RPC ("SpinRPC", PhotonTargets.AllViaServer, new object[] { eulerAngle, oneRotateTime });
		}
	}

	[PunRPC]
	private void SpinRPC(float eulerAngle, float oneRotateTime) {
		rotateTime = eulerAngle * oneRotateTime;
		GameObject rouletteGameObject = GameManager.instance.board.roulette.gameObject;
		iTween.ScaleTo (rouletteGameObject,iTween.Hash("x",1.5f,"y",1.5f,"time",2,"oncomplete","SpinComplete"));
		iTween.RotateBy (gameObject,iTween.Hash("z",-eulerAngle,"time",rotateTime,"oncomplete","SpinComplete"));
	}

	public void SpinComplete() {
		startSpin = false;
		arrowStoped = true;
		GameManager.instance.board.roulette.currentAction = currentSector.GetComponent<Sector> ().action;
		EventManager.TriggerEvent (EventManager.ROULETTE_SPIN_ENDED);
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
