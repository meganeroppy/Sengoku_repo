using UnityEngine;
using System.Collections;

public class PageHundler : MonoBehaviour {

	protected GameObject menuRoot;
	protected bool m_awake = false;

	protected virtual void Start(){
		menuRoot = transform.FindChild("BG").gameObject;
		m_awake = menuRoot.activeInHierarchy;
	}
	
	// Update is called once per frame
	protected void Update () {
		
		if(m_awake){
			if(!CheckDisplayFlug()){
				m_awake = false;
				menuRoot.SetActive(m_awake);
			}
		}else{
			if(CheckDisplayFlug()){
				m_awake = true;
				menuRoot.SetActive(m_awake);
			}
			
		}
	}
	
	protected virtual bool CheckDisplayFlug(){
		return false;
	} 
}
