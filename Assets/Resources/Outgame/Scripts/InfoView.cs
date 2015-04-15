using UnityEngine;
using System.Collections;

public class InfoView : ScrollController {

	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.INFO ? true : false;
	} 

	protected override string SetMessage(){
		return "新しいお知らせはありません。";
	}
}
