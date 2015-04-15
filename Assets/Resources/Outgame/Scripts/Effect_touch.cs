using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Effect_touch : MonoBehaviour {

	private float m_timer = 0.0f;
	private float m_lifeTimer = 1.0f;
	private float interval = 0.03f;
	private float offsetMax = 20.0f;
	private GameObject star;

	// Use this for initialization
	void Start () {
		//m_timer = Random.Range(0.0f, interval);
		if(GetComponent<Image>()){
			//Debug.Log(GetComponent<Image>().mainTexture.width * GetComponent<RectTransform>().localScale.x);
			offsetMax = (GetComponent<Image>().mainTexture.width * GetComponent<RectTransform>().localScale.x) * 0.25f;
		}

		int num = Random.Range(6,9);

		star = Resources.Load("Outgame/Prefab/Star") as GameObject;

		do{
			GameObject obj = Instantiate(star) as GameObject;
			float offsetX = Random.Range(-offsetMax, offsetMax);
			float offsetY = Random.Range(-offsetMax, offsetMax);
			obj.transform.position = transform.position + new Vector3(offsetX, offsetY, 0);
			obj.transform.SetParent(transform.parent);
			obj.SendMessage("SetAsRotating", true);
			num--;
		}while(num > 0);

		//Remove()
	}

	void Remove(){
		transform.DetachChildren();
		Destroy(this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		//for touch & hold
		if(m_timer > interval){
			m_timer = 0.0f;
			
			int num = 1;//Random.Range(0,3) >= 2 ? 2 : 1;
			
			do{
				GameObject obj = Instantiate(Resources.Load("Outgame/Prefab/Star")) as GameObject;
				float offsetX = Random.Range(-offsetMax, offsetMax);
				float offsetY = Random.Range(-offsetMax, offsetMax);
				obj.transform.position = transform.position + new Vector3(offsetX, offsetY, 0);
				obj.transform.SetParent(transform.parent);
				obj.SendMessage("SetAsRotating", true);
				
				num--;
			}while(num > 0);
			
		}else{
			m_timer += Time.deltaTime;
			m_lifeTimer -= Time.deltaTime;
			if(m_lifeTimer < 0.0f){
				Remove();
			}
		}
	}

	protected void PostponeLife(){
		m_lifeTimer = 1.0f;
	}
}
