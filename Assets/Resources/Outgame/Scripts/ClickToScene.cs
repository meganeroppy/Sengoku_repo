using UnityEngine;

public class ClickToScene : MonoBehaviour
{
    public string sceneName = null;

    void Start()
    {
    }
    void Update() { }

    public void Press()
    {
        if (sceneName != null)
        {
            Application.LoadLevel(sceneName);
        }
    }
}
