using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	public Transform obj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider Other){
		Other.transform.position = obj.position;
			
	}
}
