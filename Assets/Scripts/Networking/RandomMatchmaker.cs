using UnityEngine;
using Photon;

public class RandomMatchmaker : PunBehaviour
{
	// Use this for initialization
	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom(null);
	}

	public override void OnJoinedRoom ()
	{
		base.OnJoinedRoom ();
		if (PhotonNetwork.isMasterClient) {
			PhotonNetwork.playerName = "master";
			GameManager.instance.CreateGame ();
		} else {
			PhotonNetwork.playerName = "margarita";
			EventManager.StartListening (EventManager.ROULETTE_CREATED, GameManager.instance.CreateGame);
		}
	}

	public override void OnPhotonInstantiate (PhotonMessageInfo info)
	{
		base.OnPhotonInstantiate (info);
		Debug.Log ("OnPhotonInstantiate + " + info.photonView.name);
	}
}