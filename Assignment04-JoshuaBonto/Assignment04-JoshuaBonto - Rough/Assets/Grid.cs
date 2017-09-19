using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
	public enum fruitList { Apple, Lemon, Lime, Blueberry}
	public fruitList myList;
	private int columns, rows, tadd;
	public int[,] fscreen;
	public GameObject Apple, Lemon, Lime, Blueberry;
	private Collider[] balls;
	public int curMoving = 0;
	private bool isMove;
	private Vector3 nextFP;
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
		GameObject lastSpawn;
		for (int co = 0; co < columns; co++) {
			for (int ro = 0; ro < rows; ro++) {
				Vector3 fruitPos = new Vector3 (co, ro, 0);
				//Debug.Log (fruitPos);
				lastSpawn = Instantiate(spawnFruit(fscreen[co,ro]), fruitPos, this.transform.rotation);
			
			}
		}
		//Collider[] balls = Physics.OverlapSphere(new Vector3(2f,2f,0f), .1f);
		//Destroy(balls[0].gameObject);
	}
	public void touch(int x, int y){
		//Debug.Log ("X: " + (x+0) + " Y: " + (y+0) + " " + getFruit(fscreen[x,y]));

	}
	public void fruitFall(int x, int y){
		Debug.Log (y + 1);
		//Debug.Log ("X: " + (x+0) + " Y: " + (y+0) + " " + getFruit(fscreen[x,y]));
		if ((y + 1) != rows) {
			//If the fruit ball clicked was below the top it causes all about it to fall
			for (int i = (y + 1); i < rows; i++) {
				balls = Physics.OverlapSphere (new Vector3 (x, i, 0f), .1f);
				balls [0].GetComponent<fruitScript> ().moveDown ();
				//Debug.Log(getFruit (fscreen[x,i]));
			} 
		} else {
			//If it was the top it just goes and spawns another immediately 
			tadd= Random.Range (0, 4);
			Instantiate(spawnFruit(tadd), new Vector3(x, (rows-1), 0f), this.transform.rotation);
		
		}
		tadd= Random.Range (0, 4);

		nextFP = new Vector3 (x, (rows - 1), 0f);
		//Instantiate(spawnFruit(tadd), new Vector3(x, (rows-1), 0f), this.transform.rotation);
	}

	public void setMove(int i){
		if (i == 1) {
			isMove = true;	
			curMoving++;
		}
		if (i == -1) {
			if (isMove) {
				Instantiate (spawnFruit (tadd), nextFP, this.transform.rotation);
			}
			curMoving = 0;
			isMove = false;
		} // the boolean shenanigans are to make sure only one fruit ball causing one to be instantiated at the top

	}
	public int getMove(){
		//Debug.Log ("return");
		return curMoving;
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
