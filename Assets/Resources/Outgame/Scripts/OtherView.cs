using UnityEngine;
using System.Collections;

public class OtherView : ScrollController {

	protected override void Start(){
		num = 9;
	}
	
	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.OTHER ? true : false;
	} 
	
	protected override string SetMessage(){
		return " 項目がありません。";
	}
	
	protected override void AddCommand(GameObject target, int index){
		target.SendMessage("SetIndex", index);
	}
}
