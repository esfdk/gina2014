using UnityEngine;
using System.Collections;

/// <summary>
/// A class that takes care of switching to the correct room and updating the progress tracker.
/// </summary>
public class SwitchRoom : MonoBehaviour
{
    public GameObject NextRoom;
    public GameObject LastRoom;
    public bool CorrectDoor;

    private ProgressTracker _progressTracker;
    private Vector3 _nextRoomPosition;
    private Vector3 _lastRoomPosition;
    private GameObject _player;

	// Use this for initialization
	void Start ()
	{
	    _progressTracker = GameObject.FindGameObjectWithTag("Player").GetComponent<ProgressTracker>();

	    _nextRoomPosition = NextRoom.transform.FindChild("Room_Door_Entrance").FindChild("Hallway_Trigger").position;
        _lastRoomPosition = LastRoom.transform.FindChild("Room_Door_Entrance").FindChild("Hallway_Trigger").position;
	}

    // Happens when the trigger is triggered by a collider.
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        _player = other.gameObject;
        _progressTracker.Progress(CorrectDoor);

        ScreenFader.Fade();
        
        Invoke("MovePlayer", 0.5f);
    }

    /// <summary>
    /// Moves the player (delayed call through Invoke() in OnTriggerEnter)
    /// </summary>
    void MovePlayer()
    {
        _player.transform.position = (_progressTracker.LastRoom() ? _lastRoomPosition : _nextRoomPosition);
    }
}
