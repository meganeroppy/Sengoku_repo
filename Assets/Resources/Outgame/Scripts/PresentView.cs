using UnityEngine;
using System.Collections;

public class PresentView : ScrollController {
	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.PRESENT ? true : false;
	} 

	protected override string SetMessage(){
		return "プレゼントはありません。";
	}
}
