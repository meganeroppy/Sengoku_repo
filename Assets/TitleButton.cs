using UnityEngine;
using System.Collections;

public class TitleButton : CommandButton {

	protected override void ExecuteCommand(){
		if(GameObject.FindWithTag("Announce")){
			return;
		}
		GameObject obj = Instantiate(announceWindow) as GameObject;
		obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
		string str = "称号を表示しています。";
		obj.SendMessage("Init", str);
	}
}
