using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class ConstantsManager : MonoBehaviour {

	public static ConstantsManager instance;

	public  Dictionary<string,Vector2> treesCordination = new Dictionary<string,Vector2>();
	public  Dictionary<string,Vector3> treesRotation = new Dictionary<string,Vector3>();
	public  Dictionary<string,Vector2> treesScales = new Dictionary<string,Vector2>();
	public  Dictionary<string,Vector2> basketCordination = new Dictionary<string,Vector2>();

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

		treesCordination.Add ("tree0",new Vector2(9.4f,-5.6f));
		treesCordination.Add ("tree1",new Vector2(-11.9f,-4.8f));
		treesCordination.Add ("tree2",new Vector2(-9.3f,5.6f));
		treesCordination.Add ("tree3",new Vector2(11.8f,5f));

		treesRotation.Add ("tree0",new Vector3(0,0,0));
		treesRotation.Add ("tree1",new Vector3(0,0,0));
		treesRotation.Add ("tree2",new Vector3(0,0,-43.52f));
		treesRotation.Add ("tree3",new Vector3(0,0,-73.85f));

		treesScales.Add ("tree0",new Vector2(1f,1f));
		treesScales.Add ("tree1",new Vector2(1f,1f));
		treesScales.Add ("tree2",new Vector2(-1f,-1f));
		treesScales.Add ("tree3",new Vector2(-1f,-1f));

		/////////////////////////////////////////////////////////////////////
		/////////////////////////////cherrys//////////////////////////////////////

		List<Vector2> trees0CherrysCordsList = new List<Vector2> ();

		trees0CherrysCordsList.Add (new Vector2(3.19f, 3.9f));
		trees0CherrysCordsList.Add (new Vector2(-0.38f, 1.5f));
		trees0CherrysCordsList.Add (new Vector2(3.95f, 0.1f));
		trees0CherrysCordsList.Add (new Vector2(-1.52f, 3.2f));
		trees0CherrysCordsList.Add (new Vector2(1.2f, 4.4f));
		trees0CherrysCordsList.Add (new Vector2(1.72f, -0.3f));
		trees0CherrysCordsList.Add (new Vector2(1.91f, 2f));
		trees0CherrysCordsList.Add (new Vector2(-1.71f, -0.15f));
		trees0CherrysCordsList.Add (new Vector2(3f, -1f));
		trees0CherrysCordsList.Add (new Vector2(4f, 2.3f));

		cherrysCordination.Add ("tree0",trees0CherrysCordsList);

		List<Vector2> trees1CherrysCordsList = new List<Vector2> ();
		trees1CherrysCordsList.Add (new Vector2(4.5f, -2.7f));
		trees1CherrysCordsList.Add (new Vector2(5f, 1.6f));
		trees1CherrysCordsList.Add (new Vector2(0.5f, 1.5f));
		trees1CherrysCordsList.Add (new Vector2(3.8f, -0.5f));
		trees1CherrysCordsList.Add (new Vector2(6f, -0.75f));
		trees1CherrysCordsList.Add (new Vector2(4f, 3.3f));
		trees1CherrysCordsList.Add (new Vector2(6.6f, 0.85f));
		trees1CherrysCordsList.Add (new Vector2(2.32f, 3.1f));
		trees1CherrysCordsList.Add (new Vector2(2.6f, 1.3f));
		trees1CherrysCordsList.Add (new Vector2(2.47f, -0.4f));

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

		basketCordination.Add ("Textures/winterB", new Vector2(5.716f, -8.869f));
		basketCordination.Add ("Textures/summerB", new Vector2(5.716f, -8.869f));
		basketCordination.Add ("Textures/autumnB", new Vector2(5.716f, -8.869f));
		basketCordination.Add ("Textures/springB", new Vector2(5.716f, -8.869f));

		basketCordination.Add ("Textures/winterRB", new Vector2(-16.17f, -5.24f));
		basketCordination.Add ("Textures/summerRB", new Vector2(-16.17f, -5.24f));
		basketCordination.Add ("Textures/autumnRB", new Vector2(-16.17f, -5.24f));
		basketCordination.Add ("Textures/springRB", new Vector2(-16.17f, -5.24f));
	}
}
