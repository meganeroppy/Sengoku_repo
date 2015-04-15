using UnityEngine;
using System.Collections;

public class FriendView : ScrollController {
	
	protected override void Start(){
		num = 32;
	}
	
	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.FRIEND ? true : false;
	} 
	
	protected override string SetMessage(){
		return " フレンドがいません。";
	}
	
	protected override void AddCommand(GameObject target, int index){
		target.SendMessage("SetIndex", index);
	}
}
