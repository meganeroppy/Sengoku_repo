using UnityEngine;
using System.Collections;

public class ShopView : ScrollController {

	protected override void Start(){
		num = 7;
	}

	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.SHOP ? true : false;
	} 
	
	protected override string SetMessage(){
		return " アイテムがありません。";
	}

	protected override void AddCommand(GameObject target, int index){
		target.SendMessage("SetIndex", index);
	}
}
