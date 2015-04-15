using UnityEngine;
using System.Collections;

public class ShopButton : TransitionButton {
	
	protected override void SetPage(){
		GameManager game = GameObject.Find("Main Camera").GetComponent<GameManager>();
		game.SendMessage("CloseSubpage");	
		GameManager.cur_page = GameManager.PAGE.SHOP;
	} 
}
