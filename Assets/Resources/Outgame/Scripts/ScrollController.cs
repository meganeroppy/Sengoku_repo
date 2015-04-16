using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollController : MonoBehaviour {

	protected int num = 16;

	protected bool m_awake = false;
	protected bool m_displayingNotice = false;
	protected bool reloadFlug = false;

	protected float reloadWait = 0;
	protected const float RELOAD_INTERVAL_MIN = 1f;

	protected UIGrid myUIGrid;
	protected UIScrollView myUIScrollView;
	
	[SerializeField]
	protected Transform node = null;

	/// <for uGUI>
	[SerializeField]
	protected RectTransform node_U = null;

	/// </for uGUI>


	// Use this for initialization
	protected virtual void Start ()
    {
		m_awake = true;
		myUIGrid = GetComponent<UIGrid>();
		myUIScrollView = GetComponent<UIScrollView>();
    }

	// Update is called once per frame
	protected virtual void Update () {
		if(m_awake){
			if(!CheckDisplayFlug()){// awake -> sleep
				m_awake = false;

				for(int i = 0 ; i < transform.childCount ; i++ ){
					Destroy(transform.GetChild(transform.childCount - (i+1) ).gameObject);
				}

				if(m_displayingNotice){
					m_displayingNotice = false;
					 
					Transform myParent = transform.parent;
					for(int i=0 ; i < myParent.childCount ; i++){
						GameObject obj = myParent.GetChild(i).gameObject;
						if(obj.name.Contains("Window")){
							Destroy(obj);
						}
					}
				}
			}else{
				if(transform.childCount == 0){	// Scroll View has no child
					if(!m_displayingNotice){
						m_displayingNotice = true;

						GameObject obj = Instantiate(Resources.Load("Outgame/Prefab/AnnounceWindow" + (GameManager.isWithUGUI ? "" : "NGUI"))) as GameObject;
						obj.transform.SetParent(GameObject.Find("AnnounceLayer").transform);
						string text = SetMessage();
						obj.SendMessage("Init", text);
						//obj.SendMessage("SetAsNotRemovable");
					}
				}
			}
		}else{
			if(CheckDisplayFlug()){ //sleep -> awake
				m_awake = true;
				m_displayingNotice = false;

				CreateNodes();
			}

		}

		if(reloadWait > 0){
			reloadWait -= Time.deltaTime;
		}
	}

	protected virtual bool CheckDisplayFlug(){
		return false;
	} 

	protected virtual string SetMessage(){
		return "Message not defined.";
	}

	protected virtual void AddCommand(GameObject target, int index){
		return;
	}

	protected virtual void CreateNodes(){
		for(int i = 0 ; i < num ; i++){
			if(GameManager.isWithUGUI){
				RectTransform item = GameObject.Instantiate(node) as RectTransform;
				item.SetParent(transform, false);
				AddCommand(item.gameObject, i);
			}else{
				Transform item = GameObject.Instantiate(node) as Transform;
				if(myUIGrid == null){
					myUIGrid = GetComponent<UIGrid>();
				}
				myUIGrid.AddChild(item);
				item.transform.localScale = Vector3.one;
				AddCommand(item.gameObject, i);
			}
		}

	}

	protected virtual void Reload(){

		if(reloadWait > 0){
			return;
		}

		// memorize scroll pos 
		if(myUIScrollView == null){
			myUIScrollView = GetComponent<UIScrollView>();
		}
		Vector3 scrollPosBeforeReload = myUIScrollView.transform.localPosition;

		// delete all nodes
		for(int i = transform.childCount-1 ; i > -1 ; i--){

			if(!GameManager.isWithUGUI){
				if(myUIGrid == null){
					myUIGrid = GetComponent<UIGrid>();
				}
				myUIGrid.RemoveChild(transform.GetChild(i));
			}
			Destroy(transform.GetChild(i).gameObject);
		}
		

		//myUIScrollView.ResetPosition();
		//myUIScrollView.SetDragAmount( 0f, 0f, false );

		// create nodes again
		CreateNodes();

		if(myUIGrid == null){
			myUIGrid = GetComponent<UIGrid>();
		}
		myUIGrid.enabled = true;

		// apply scroll pos from before relaod
		myUIScrollView.transform.localPosition = scrollPosBeforeReload;
		Debug.Log("Reload() : scrollPos of " + this.gameObject.name + " = " + myUIScrollView.transform.localPosition.y.ToString());

		reloadWait = RELOAD_INTERVAL_MIN;
	}

	protected void SetScrollPosY(float val){
		if (myUIScrollView == null){
			myUIScrollView = GetComponent<UIScrollView>();
		}
		Vector3 pos = myUIScrollView.transform.localPosition;
		Vector3 newPos = new Vector3(pos.x, val, pos.z);
		myUIScrollView.transform.localPosition = newPos;
	}
	
	protected float GetScrollPosY(){
		if (myUIScrollView == null){
			myUIScrollView = GetComponent<UIScrollView>();
		}
		return myUIScrollView.transform.localPosition.y;
	}

	protected void SetReloadFlug(){
		reloadFlug = true;
	}
}
