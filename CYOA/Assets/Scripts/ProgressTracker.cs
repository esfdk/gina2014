using UnityEngine;

/// <summary>
/// A class that tracks the progress through the rooms.
/// </summary>
public class ProgressTracker : MonoBehaviour
{
    //public static ProgressTracker PT;

    private bool? _firstRoom;
    private bool? _secondRoom;
    private bool? _thirdRoom;
    private bool _endRoom;

    private SoundManager _soundManager;

	// Use this for initialization
	void Start ()
	{
        //PT = this;

	    _firstRoom = null;
	    _secondRoom = null;
	    _thirdRoom = null;

	    _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
	}

    AudioClip GetCorrectAudioClip()
    {
        AudioClip resultClip = null;

        if (_endRoom) resultClip = _soundManager.EndRoom;

        // If only room one has been "completed"
        else if (_thirdRoom == null && _secondRoom == null && _firstRoom != null)
        {
            resultClip = ((_firstRoom == true) ? _soundManager.T : _soundManager.F);
        }

        // If room one and two have been "completed"
        else if (_thirdRoom == null && _secondRoom != null && _firstRoom != null)
        {
            if (_secondRoom == true)
            {
                resultClip = ((_firstRoom == true) ? _soundManager.TT : _soundManager.FT);
            }
            else
            {
                resultClip = ((_firstRoom == true) ? _soundManager.TF : _soundManager.FF);
            }
        }

        // If room one, two and three have been "completed"
        else if (_thirdRoom != null && _secondRoom != null && _firstRoom != null)
        {
            if (_thirdRoom == true)
            {
                if (_secondRoom == true)
                    resultClip = ((_firstRoom == true) ? _soundManager.TTT : _soundManager.FTT);
                else
                    resultClip = ((_firstRoom == true) ? _soundManager.TFT : _soundManager.FFT);
            }
            else
            {
                if (_secondRoom == true)
                    resultClip = ((_firstRoom == true) ? _soundManager.TTF : _soundManager.FTF);
                else
                    resultClip = ((_firstRoom == true) ? _soundManager.TFF : _soundManager.FFF);
            }
        }

        return resultClip;
    }

    /// <summary>
    /// Determines if it is time to go to the last room.
    /// </summary>
    /// <returns>True if it is time for the last room; false otherwise.</returns>
    public bool LastRoom()
    {
        return _endRoom;
    }

    /// <summary>
    /// Adds progress to the tracker and plays the correct sound based on the progress.
    /// </summary>
    /// <param name="door">The "correctness" of the door passed through.</param>
    public void Progress(bool door)
    {
        if (_firstRoom == null)
            _firstRoom = door;
        else if (_secondRoom == null)
            _secondRoom = door;
        else if (_thirdRoom == null)
            _thirdRoom = door;
        else if (!_endRoom)
            _endRoom = true;

        _soundManager.Play(GetCorrectAudioClip());
    }
}
