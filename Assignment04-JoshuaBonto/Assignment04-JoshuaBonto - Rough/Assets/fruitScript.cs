using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fruitScript : MonoBehaviour {
	public gameController gC;
	public Grid g;
	private bool canM = true;
	// Use this for initialization
	void Start () {
		//transform.Translate (0, -1, Time.deltaTime);
		//StartCoroutine(downWards());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void moveDown(){
		StartCoroutine (downWards ());
	}
	IEnumerator downWards(){
		g.setMove (1);
		for (int i = 0; i < 20; i++) {
			yield return new WaitForSeconds (.1f);
			transform.Translate (0f, -.05f,0f);
		}
		g.setMove (-1);
	}

	void OnMouseDown(){
		
		if (g.getMove() == 0) {
			g.fruitFall ((int)transform.position.x, (int)transform.position.y);
			gC.clickmsg ();
			//StartCoroutine (downWards ());
			Destroy (this.gameObject);
		} else {
			Debug.Log ("wait for them to stop");
		}

	}
}
