using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransitionButton : MonoBehaviour {

	public void Press(){

		//Debug.Log("Press : " + gameObject.name.ToString())
			;		
		if(GameObject.FindWithTag("Announce")){
			Destroy(GameObject.FindWithTag("Announce"));
		}
			
		SetPage();

		//GameObject.Find("MyPageContents").SendMessage("Activate", false);
		
	}

	protected virtual void SetPage(){
		GameManager.cur_page = GameManager.PAGE.MYPAGE;
		GameManager.subpageIsOpen = false;
	} 
}
