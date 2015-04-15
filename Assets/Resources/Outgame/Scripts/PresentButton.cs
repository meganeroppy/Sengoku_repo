using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PresentButton : MonoBehaviour {
	public GameObject infoWindow;
	
	// Use this for initialization
	void Start () {
		//Debug.Log("PresentButton:" + GetComponent<RectTransform>().position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Press(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}

		GameManager.cur_page = GameManager.PAGE.PRESENT;
		
	}
}
