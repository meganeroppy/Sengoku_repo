using UnityEngine;
using System.Collections;

public class CommandButton : MonoBehaviour {
	
	protected GameObject confirmWindow;
	protected GameObject announceWindow;

	// Use this for initialization
	protected virtual void Start () {
		if(GameManager.isWithUGUI){
			confirmWindow = Resources.Load("Outgame/Prefab/ConfirmWindow") as GameObject;
			announceWindow = Resources.Load("Outgame/Prefab/AnnounceWindow") as GameObject;
		}else{
			confirmWindow = Resources.Load("Outgame/Prefab/ConfirmWindowNGUI") as GameObject;
			announceWindow = Resources.Load("Outgame/Prefab/AnnounceWindowNGUI") as GameObject;
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
