using UnityEngine;
using System.Collections;

public class ShopMenu : PageHundler {

	protected override bool CheckDisplayFlug(){
		return GameManager.cur_page == GameManager.PAGE.SHOP ? true : false;
	} 
}
