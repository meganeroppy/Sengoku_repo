using UnityEngine;
using System.Collections;

public class CommandButton : MonoBehaviour {
	
	protected GameObject window;
		
	// Use this for initialization
	protected virtual void Start () {
		if(GameManager.isWithUGUI){
			window = Resources.Load("Outgame/Prefab/ConfirmWindow") as GameObject;
		}else{
			window = Resources.Load("Outgame/Prefab/ConfirmWindowNGUI") as GameObject;
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}
	
	public void Press(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}

		ExecuteCommand();
	}

	protected virtual void ExecuteCommand(){

	}
}
