using UnityEngine;


public abstract class PlayerBehaviour : MonoBehaviour {
	public Basket basket;

	public abstract void StartTurn();

	public void EndTurn() {
		EventManager.TriggerEvent (EventManager.TURN_ENDED);
	}
}
