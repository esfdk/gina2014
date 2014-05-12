using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour 
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Application.LoadLevel("EndScreen");
    }
}
