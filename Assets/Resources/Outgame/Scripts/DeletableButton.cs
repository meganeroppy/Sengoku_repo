using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeletableButton : MonoBehaviour {


	public void Activate(){
		Image image = GetComponent<Image>();
		image.enabled = true;
	}

	public void Press(){
		Image image = GetComponent<Image>();
		image.enabled = false;
	}
}
