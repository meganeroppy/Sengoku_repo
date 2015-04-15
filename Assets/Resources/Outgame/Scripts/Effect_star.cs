using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Effect_star : MonoBehaviour {

   	private float m_timer = 0.0f;
	private float interval = 3.5f;
	private float offsetMax = 20.0f;
	// Use this for initialization
	void Start () {
		m_timer = Random.Range(0.0f, interval);
		if(GetComponent<Image>()){
			//Debug.Log(GetComponent<Image>().mainTexture.width * GetComponent<RectTransform>().localScale.x);
			offsetMax = (GetComponent<Image>().mainTexture.width * GetComponent<RectTransform>().localScale.x) * 0.25f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_timer > interval){
			m_timer = 0.0f;

			int num = 1;//Random.Range(0,3) >= 2 ? 2 : 1;

			do{
			GameObject obj = Instantiate(Resources.Load("Outgame/Prefab/Star")) as GameObject;
			float offsetX = Random.Range(-offsetMax, offsetMax);
			float offsetY = Random.Range(-offsetMax, offsetMax);
			obj.transform.position = transform.position + new Vector3(offsetX, offsetY, 0);
			obj.transform.SetParent(transform);

				num--;
			}while(num > 0);

		}else{
			m_timer += Time.deltaTime;
		}
	}
}
