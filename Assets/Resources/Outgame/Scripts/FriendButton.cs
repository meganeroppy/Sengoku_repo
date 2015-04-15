using UnityEngine;
using System.Collections;

public class FriendButton : TransitionButton {
	protected override void SetPage(){
		GameManager game = GameObject.Find("Main Camera").GetComponent<GameManager>();
		game.SendMessage("CloseSubpage");	
		GameManager.cur_page = GameManager.PAGE.FRIEND;
	} 
}
