using UnityEngine;
using System.Collections;

public class EventSystemLauncher : MonoBehaviour {
		
	private void Activate(){
		transform.FindChild("EventSystem").gameObject.SetActive(true);
	}

}
