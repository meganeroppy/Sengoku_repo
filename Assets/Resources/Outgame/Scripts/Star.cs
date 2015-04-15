using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Star : MonoBehaviour {

	private float lifeTime = 1.0f;
	private float m_timer = 0.0f;
	private float m_alpha = 0.0f;
	private Image pic;

	private bool forTouch = false;
	public float rotateSpeed = 1.0f;
	private Vector3 m_baseScale = Vector3.zero;
	private float m_curScaleRate = 1.0f;
	// Use this for initialization
	void Start () {
		m_timer = lifeTime;
		pic = GetComponent<Image>();
		if(m_baseScale == Vector3.zero){
			m_baseScale = transform.localScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		m_timer -= Time.deltaTime;
		if(m_timer <= 0.0f ){
			Destroy(this.gameObject);
		}else{
			m_alpha = Mathf.Lerp(0, 1, m_timer);
			SetAlpha(m_alpha);

			//rotation and minimization
			if(forTouch){
				transform.Rotate(0,0,rotateSpeed);
				m_curScaleRate = m_alpha;
				Vector3 newScale = new Vector3(m_baseScale.x * m_curScaleRate, m_baseScale.y * m_curScaleRate, 1);
				transform.localScale = newScale;
			}
		}
	}

	private void SetAlpha(float val){
		Color col = pic.color;
		pic.color = new Color(col.r, col.g, col.b, val);

	}

	private void SetAsRotating(bool val){
		forTouch = val;
		if(m_baseScale == Vector3.zero){
			m_baseScale = transform.localScale;
		}
	}
}
