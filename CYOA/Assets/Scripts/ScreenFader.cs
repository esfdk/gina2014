using UnityEngine;
using System.Collections;

/// <summary>
/// A class for fading the screen to black.
/// </summary>
public class ScreenFader : MonoBehaviour 
{
    public Texture ScreenFaderTexture;
    public float FadeSpeed = 12f;

    private static bool _fading;
    private static float _fadeTimer;
    private float _alpha;
    private Color _originalColor, _alphaColor;

	// Use this for initialization
	void Start ()
	{
        _originalColor = GUI.color;
        _alphaColor = Color.clear;
        _alphaColor.a = 0.99f;
	    _alpha = _alphaColor.a;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_fading)
        {
            FadeToBlack();

            _fadeTimer -= Time.deltaTime;
            if (_fadeTimer <= 0f) _fading = false;
        }
        else
        {
            FadeToClear();
        }
	}

    /// <summary>
    /// Fades the screen towards clear.
    /// </summary>
    void FadeToClear()
    {
        if (_alpha <= 0.01f) return;
        _alpha -= FadeSpeed * Time.deltaTime;
        _alphaColor.a = _alpha;
    }

    /// <summary>
    /// Fades the screen towards black.
    /// </summary>
    void FadeToBlack()
    {
        if (_alpha >= 0.99f) return;
        _alpha += FadeSpeed * Time.deltaTime;
        _alphaColor.a = _alpha;
    }

    // Updates the GUI.
    void OnGUI()
    {
        GUI.color = _alphaColor;
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), ScreenFaderTexture);
        GUI.color = _originalColor;
    }

    /// <summary>
    /// Resets the screen.
    /// </summary>
    public static void Fade()
    {
        _fading = true;
        _fadeTimer = 1f;
    }
}
