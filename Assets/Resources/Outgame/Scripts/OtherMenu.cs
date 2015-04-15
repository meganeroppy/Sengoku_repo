using UnityEngine;
using System.Collections;

public class OtherMenu : PageHundler {

	protected override bool CheckDisplayFlug ()
	{
		return GameManager.cur_page == GameManager.PAGE.OTHER ? true : false;
	}
}
