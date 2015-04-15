using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GachaMenu : PageHundler {

	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.GACHA ? true : false;
	} 
}
