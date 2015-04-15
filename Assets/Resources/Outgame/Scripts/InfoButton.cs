using UnityEngine;
using System.Collections;

public class InfoButton : MonoBehaviour {

	private bool m_awake;

	// Use this for initialization
	void Start () {
		m_awake = true;
	}
	
	// Update is called once per frame
	void Update () {
		switch(GameManager.cur_page){
		case GameManager.PAGE.INFO :
			if(m_awake){
				m_awake = false;
				
			}
			
			break;		
		default :
			if(!m_awake){
				m_awake = true;
				
			}
			break;
		}
	}

	public void Press(){
		if(!m_awake){
			return;
		}

		GameManager.cur_page = GameManager.PAGE.INFO;

	}
}
