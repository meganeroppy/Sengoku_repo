using UnityEngine;
using System.Collections;

public class CursorEffectLayer : MonoBehaviour {

	private GameObject m_effect;
	private bool m_hasCursor;
	private float m_timer = 0.0f;
	// Use this for initialization
	void Start () {
		m_hasCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	protected void SetEffect(Vector3 pos){
		if(pos == Vector3.zero){
			if(m_hasCursor){
				m_hasCursor = false;

				for(int i=0 ; i < transform.childCount ; i++){
					GameObject obj = transform.GetChild(i).gameObject;
					if(obj.name.Contains("Effect_touch")){
						obj.SendMessage("Remove");
					}
				}
			}
		}else{
			if(!m_hasCursor){
				m_hasCursor = true;
				m_effect = Instantiate(Resources.Load("Outgame/Prefab/Effect_touch")) as GameObject;
				m_effect.transform.SetParent(transform);

			}

			m_effect.transform.position = pos;
			if(m_timer > 0.5f){
				m_timer = 0;
				m_effect.SendMessage("PostponeLife");
			}else{
				m_timer += Time.deltaTime;
			}
		}		
	}
}
