using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {

	public int index;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveToBasket(Basket basket){
		Vector3 basketPosition = basket.transform.position;
		iTween.MoveTo (gameObject,iTween.Hash("x",basketPosition.x,"y",basketPosition.y,"z",basketPosition.z,"oncomplete","CherryInBasket"));
	}

	public void CherryInBasket(){
		Debug.Log ("+======CherryInBasket");
	}
}
