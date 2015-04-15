using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnnounceLayer : MonoBehaviour {

	private Image myImage;
	private bool m_awake;
	
	// Use this for initialization
	void Start () {
		m_awake = false;
		
		myImage = GetComponent<Image>();
		
		myImage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.childCount == 0){
			if(m_awake){
				m_awake = false;
				myImage.enabled = false;
			}
		}else{
			if(!m_awake){
				m_awake = true;
				myImage.enabled = true;
			}
		}
	}
}
