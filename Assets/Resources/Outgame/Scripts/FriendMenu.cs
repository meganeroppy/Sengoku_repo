using UnityEngine;
using System.Collections;

public class FriendMenu : PageHundler {

	protected override bool CheckDisplayFlug ()
	{
		return GameManager.cur_page == GameManager.PAGE.FRIEND ? true : false;
	}
}
