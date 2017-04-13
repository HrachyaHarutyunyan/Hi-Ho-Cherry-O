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
		PhotonNetwork.JoinOrCreateRoom ("23", new RoomOptions(), TypedLobby.Default);
	}

	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom("23");
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
	}

	public override void OnPhotonPlayerConnected (PhotonPlayer newPlayer)
	{
		base.OnPhotonPlayerConnected (newPlayer);
		if (PhotonNetwork.playerList.Length == 2) {
			Invoke ("StartGame", 2f);
		}
	}

	private void StartGame() {
		Debug.Log ("Game Started !!!!!");
		EventManager.TriggerEvent (EventManager.CHERRIES_CREATED);
	}
}