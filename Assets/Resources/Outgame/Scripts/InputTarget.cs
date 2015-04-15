using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputTarget : MonoBehaviour {
	
	//public Camera     m_camera;
	//public GameObject m_targetPanel;
	//public GameObject m_targetPrefab;

	private GameObject m_targetNode;


	void Start(){
		m_targetNode = GameObject.Find("CursorEffectLayer");
	}
	// Update is called once per frame
	void Update ()
	{

		Vector3 touchPos = Vector3.zero;

		if(Input.GetMouseButton(0)){
			touchPos = Input.mousePosition;
		}else{
		
		}

		//Debug.Log(touchPos);

		if(m_targetNode != null){
			m_targetNode.SendMessage("SetEffect", touchPos);
		}

	}

}