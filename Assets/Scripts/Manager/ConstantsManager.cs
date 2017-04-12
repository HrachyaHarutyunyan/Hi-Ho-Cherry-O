using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantsManager : MonoBehaviour {

	public static ConstantsManager instance;

	public  Dictionary<string,Vector2> treesCordination = new Dictionary<string,Vector2>();
	public  Dictionary<string,Vector3> treesRotation = new Dictionary<string,Vector3>();
	public  Dictionary<string,Vector2> treesScales = new Dictionary<string,Vector2>();

	public  Dictionary<string,List<Vector2>> cherrysCordination = new Dictionary<string,List<Vector2>>();

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
		/////////////////////////tree/////////////////////////////////////////

		treesCordination.Add ("tree0",new Vector2(-2.35f,0.93f));
		treesCordination.Add ("tree1",new Vector2(2.2f,-1.17f));
		treesCordination.Add ("tree2",new Vector2(2.97f,1.73f));
		treesCordination.Add ("tree3",new Vector2(2.86f,1.63f));

		treesRotation.Add ("tree0",new Vector3(0,0,0));
		treesRotation.Add ("tree1",new Vector3(0,0,0));
		treesRotation.Add ("tree2",new Vector3(0,0,-43.52f));
		treesRotation.Add ("tree3",new Vector3(0,0,-73.85f));

		treesScales.Add ("tree0",new Vector2(0.25f,-0.25f));
		treesScales.Add ("tree1",new Vector2(0.25f,0.25f));
		treesScales.Add ("tree2",new Vector2(0.25f,-0.25f));
		treesScales.Add ("tree3",new Vector2(0.25f,0.25f));

		/////////////////////////////////////////////////////////////////////
		/////////////////////////////cherrys//////////////////////////////////////

		List<Vector2> cherrysCordsList = new List<Vector2> ();
		cherrysCordsList.Add (new Vector2(-0.5f,0.93f));
		cherrysCordsList.Add (new Vector2(0.5f,1f));
		cherrysCordsList.Add (new Vector2(-1f,1.4f));
		cherrysCordsList.Add (new Vector2(-1.5f,1.8f));
		cherrysCordsList.Add (new Vector2(-2f,2f));
		cherrysCordsList.Add (new Vector2(-2.3f,2.23f));
		cherrysCordsList.Add (new Vector2(-2.6f,2.4f));
		cherrysCordsList.Add (new Vector2(-3.2f,2f));
		cherrysCordsList.Add (new Vector2(-3.3f,2.3f));
		cherrysCordsList.Add (new Vector2(-3.6f,1.2f));

		cherrysCordination.Add ("tree0",cherrysCordsList);
		cherrysCordination.Add ("tree1",cherrysCordsList);
		cherrysCordination.Add ("tree2",cherrysCordsList);
		cherrysCordination.Add ("tree3",cherrysCordsList);


	}



	
}
