using UnityEngine;

public class GameControl : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
	        Application.Quit();
    }
}
