#pragma warning disable 0219

using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("TouchCount = " + Input.touchCount);

        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(_touch.position);

            if (_touch.phase == TouchPhase.Began)
            {
                Application.LoadLevel("Outgame");
            }
        }
    }
}
