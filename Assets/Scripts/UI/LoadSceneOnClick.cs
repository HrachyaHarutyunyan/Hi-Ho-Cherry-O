using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void InitGameMode(int playerCount,bool isMultiplayer) {
		GameManager.GameMode gameMode = (GameManager.GameMode)playerCount;
		if(ArgumentManager.instance.arguments.ContainsKey (ArgumentManager.GAME_MODE)) {
			ArgumentManager.instance.arguments.Remove (ArgumentManager.GAME_MODE);
		}
		ArgumentManager.instance.arguments.Add (ArgumentManager.GAME_MODE, gameMode);
	}

	public void LoadByIndex(int sceneIndex){
		
		SceneManager.LoadScene (sceneIndex);
	}


}
