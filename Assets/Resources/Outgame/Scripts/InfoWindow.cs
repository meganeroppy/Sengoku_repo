using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoWindow : MonoBehaviour {
	private Image myImage;
	private Text myText;
	// Use this for initialization
	void Start () {
		myText = transform.GetChild(0).GetComponent<Text>();
		myText.enabled = false;
		myImage = GetComponent<Image>();
		myImage.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void Activate(bool val){
		myText.enabled = val;
		myImage.enabled = val;
		Debug.Log(GetComponent<RectTransform>());
	}

	public void Press(){
		myText.enabled = false;
		myImage.enabled = false;	
	}
	
}
