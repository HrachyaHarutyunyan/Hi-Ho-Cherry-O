using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  System.Collections.ObjectModel;
using UnityEditor;

public class ConstantsManager : MonoBehaviour {

	public static ConstantsManager instance;

	public  Dictionary<string,Vector2> treesCordination = new Dictionary<string,Vector2>();
	public  Dictionary<string,Vector2> treesRotation = new Dictionary<string,Vector2>();

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init(){
		
		treesCordination.Add ("tree0",new Vector2(-2.35f,0.93f));
		treesCordination.Add ("tree1",new Vector2(2.2f,-1.17f));
	
		treesCordination.Add ("tree2",new Vector2(-2.83f,-1.61f));
		treesCordination.Add ("tree3",new Vector2(2.86f,1.63f));

		treesRotation.Add ("tree0",new Vector2(2.86f,1.63f));
		treesRotation.Add ("tree1",new Vector2(2.86f,1.63f));
		treesRotation.Add ("tree2",new Vector2(2.86f,1.63f));
		treesRotation.Add ("tree3",new Vector2(2.86f,1.63f));

	}



	
}
