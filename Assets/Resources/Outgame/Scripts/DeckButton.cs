using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeckButton : TransitionButton {

	protected override void SetPage(){
		GameManager game = GameObject.Find("Main Camera").GetComponent<GameManager>();
		game.SendMessage("CloseSubpage");	
		GameManager.cur_page = GameManager.PAGE.DECK;
	} 
}
