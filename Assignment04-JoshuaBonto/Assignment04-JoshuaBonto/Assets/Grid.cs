using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public enum fruitList { Apple, Lemon, Lime, Blueberry}
	public fruitList myList;
	private int columns, rows, tadd;
	public int[,] fscreen;
	public GameObject Apple, Lemon, Lime, Blueberry;
	void Update(){
		
	}
	public Grid(int c, int r){//columns rows
		columns = c;
		rows = r;
		fscreen = new int[c, r];
	}
	public void estGrid(int c, int r){//columns rows
		columns = c;
		rows = r;
		fscreen = new int[c, r];
	}
	public void Populate(){
		Debug.Log ("Populating");
		for (int co = 0; co < columns; co++) {
			for (int ro = 0; ro < rows; ro++) {
				tadd= Random.Range (0, 4);
				fscreen [co, ro] = tadd;
				//Debug.Log ("co"+co+"ro" + ro+"nu" + getFruit(fscreen[co,ro]));
			}
		}
	}

	public void Render(){
		Debug.Log ("Rendering");
		for (int co = 0; co < columns; co++) {
			for (int ro = 0; ro < rows; ro++) {
				Vector3 fruitPos = new Vector3 (co, ro, 0);
				//Debug.Log (fruitPos);
				Instantiate(spawnFruit(fscreen[co,ro]), fruitPos, this.transform.rotation);
			}
		}
	}
	public void touch(int x, int y){
		Debug.Log ("X: " + (x+0) + " Y: " + (y+0) + " " + getFruit(fscreen[x,y]));
	}
	string getFruit(int f){
		if (f == 0) {
			return "apple";
		} else if (f == 1) {
			return "lemon";
		} else if (f == 2) {
			return "lime";
		} else if (f == 3) {
			return "blueberry";
		}
		return "error";
	}

	GameObject spawnFruit(int f){
		if (f == 0) {
			return Apple;
		} else if (f == 1) {
			return Lemon;
		} else if (f == 2) {
			return Lime;
		} else if (f == 3) {
			return Blueberry;
		}
		return null;
	}
}
