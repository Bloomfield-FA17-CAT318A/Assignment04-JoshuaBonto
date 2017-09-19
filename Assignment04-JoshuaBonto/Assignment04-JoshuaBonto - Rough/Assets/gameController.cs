using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameController : MonoBehaviour {
	private Grid myGrid;
	public int co, ro;
	public Text uiText;
	private float score = 0;
	// Use this for initialization
	void Start () {
		myGrid = GetComponent<Grid> ();
		myGrid.estGrid (ro, co);
		myGrid.Populate ();
		myGrid.Render ();
		myGrid.touch (2, 3);
		uiText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void clickmsg(){
		
		score += 50;
		uiText.text = score.ToString();
	}
}
