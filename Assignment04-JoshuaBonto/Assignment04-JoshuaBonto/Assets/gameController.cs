using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	private Grid myGrid;
	public int co, ro;
	// Use this for initialization
	void Start () {
		myGrid = GetComponent<Grid> ();
		myGrid.estGrid (ro, co);
		myGrid.Populate ();
		myGrid.Render ();
		myGrid.touch (2, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
