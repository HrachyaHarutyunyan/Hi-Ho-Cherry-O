using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglesPlayersCount : MonoBehaviour {

	public Toggle onePlayerToggle;
	public Toggle twoPlayersToggle;
	public Toggle threePlayersToggle;
	public Toggle fourPlayersToggle;


	public void ActiveToggle(){
		int activeTogglesCount = 0;
		if (onePlayerToggle.isOn) {
			activeTogglesCount = 1;
			if (twoPlayersToggle.isOn) {
				activeTogglesCount++;
			}
			if (threePlayersToggle.isOn) {
				activeTogglesCount++;
			}
			if (fourPlayersToggle.isOn) {
				activeTogglesCount++;
			}
			if (activeTogglesCount > 1) {
				gameObject.GetComponent<LoadSceneOnClick> ().InitGameMode (activeTogglesCount);
				gameObject.GetComponent<LoadSceneOnClick> ().LoadByIndex (1);
			} else {
				Debug.Log ("eli siktir elar...");
			}
		} else {
			Debug.Log ("siktir elar...");
		}



	}

}
