using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PreferenceManager : MonoBehaviour {
       

		
		public static PreferenceManager instance;
		

		void Awake () {
			DontDestroyOnLoad(transform.gameObject);
			if (instance == null) {
				instance = this;
			} else {
				Destroy (this);
			}
		}
		
}

