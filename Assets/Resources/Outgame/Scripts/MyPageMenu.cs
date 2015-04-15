using UnityEngine;
using System.Collections;

public class MyPageMenu : PageHundler {

	protected override bool CheckDisplayFlug ()
	{
		if(GameManager.cur_page == GameManager.PAGE.MYPAGE 
		   || GameManager.cur_page == GameManager.PAGE.PRESENT
		   || GameManager.cur_page == GameManager.PAGE.INFO){
			return true;
		}else{
			return false;
		}
	}
}
