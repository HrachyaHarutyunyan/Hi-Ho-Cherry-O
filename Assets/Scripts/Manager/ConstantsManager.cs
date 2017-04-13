using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

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

		List<Vector2> trees0CherrysCordsList = new List<Vector2> ();

		trees0CherrysCordsList.Add (new Vector2(-0.5f,0.93f));
		trees0CherrysCordsList.Add (new Vector2(0.5f,1f));
		trees0CherrysCordsList.Add (new Vector2(-1f,1.4f));
		trees0CherrysCordsList.Add (new Vector2(-1.5f,1.8f));
		trees0CherrysCordsList.Add (new Vector2(-2f,2f));
		trees0CherrysCordsList.Add (new Vector2(-2.3f,2.23f));
		trees0CherrysCordsList.Add (new Vector2(-2.6f,2.4f));
		trees0CherrysCordsList.Add (new Vector2(-3.2f,2f));
		trees0CherrysCordsList.Add (new Vector2(-3.3f,2.3f));
		trees0CherrysCordsList.Add (new Vector2(-3.6f,1.2f));

		cherrysCordination.Add ("tree0",trees0CherrysCordsList);

		List<Vector2> trees1CherrysCordsList = new List<Vector2> ();
		trees1CherrysCordsList.Add (new Vector2(-0.5f,0.93f));
		trees1CherrysCordsList.Add (new Vector2(0.5f,1f));
		trees1CherrysCordsList.Add (new Vector2(-1f,1.4f));
		trees1CherrysCordsList.Add (new Vector2(-1.5f,1.8f));
		trees1CherrysCordsList.Add (new Vector2(-2f,2f));
		trees1CherrysCordsList.Add (new Vector2(-2.3f,2.23f));
		trees1CherrysCordsList.Add (new Vector2(-2.6f,2.4f));
		trees1CherrysCordsList.Add (new Vector2(-3.2f,2f));
		trees1CherrysCordsList.Add (new Vector2(-3.3f,2.3f));
		trees1CherrysCordsList.Add (new Vector2(-3.6f,1.2f));

		cherrysCordination.Add ("tree1",trees1CherrysCordsList);

		List<Vector2> trees2CherrysCordsList = new List<Vector2> ();
		trees2CherrysCordsList.Add (new Vector2(-0.5f,0.93f));
		trees2CherrysCordsList.Add (new Vector2(0.5f,1f));
		trees2CherrysCordsList.Add (new Vector2(-1f,1.4f));
		trees2CherrysCordsList.Add (new Vector2(-1.5f,1.8f));
		trees2CherrysCordsList.Add (new Vector2(-2f,2f));
		trees2CherrysCordsList.Add (new Vector2(-2.3f,2.23f));
		trees2CherrysCordsList.Add (new Vector2(-2.6f,2.4f));
		trees2CherrysCordsList.Add (new Vector2(-3.2f,2f));
		trees2CherrysCordsList.Add (new Vector2(-3.3f,2.3f));
		trees2CherrysCordsList.Add (new Vector2(-3.6f,1.2f));

		cherrysCordination.Add ("tree2",trees2CherrysCordsList);

		List<Vector2> trees3CherrysCordsList = new List<Vector2> ();
		trees3CherrysCordsList.Add (new Vector2(-0.5f,0.93f));
		trees3CherrysCordsList.Add (new Vector2(0.5f,1f));
		trees3CherrysCordsList.Add (new Vector2(-1f,1.4f));
		trees3CherrysCordsList.Add (new Vector2(-1.5f,1.8f));
		trees3CherrysCordsList.Add (new Vector2(-2f,2f));
		trees3CherrysCordsList.Add (new Vector2(-2.3f,2.23f));
		trees3CherrysCordsList.Add (new Vector2(-2.6f,2.4f));
		trees3CherrysCordsList.Add (new Vector2(-3.2f,2f));
		trees3CherrysCordsList.Add (new Vector2(-3.3f,2.3f));
		trees3CherrysCordsList.Add (new Vector2(-3.6f,1.2f));

		cherrysCordination.Add ("tree3",trees3CherrysCordsList);


	}
}
