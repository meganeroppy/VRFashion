using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModelRotation : MonoBehaviour {
    public Transform Target;
    public bool Left = true;
    public bool Right = true;

    private bool IsTurn = false;
    private float TurnSpeed = 3;

    // Update is called once per frame
    void Update ()
    {
        if (IsTurn)
        {
            if (Left)
            {
                Target.RotateAroundLocal(-Vector3.up, TurnSpeed * Time.deltaTime);
            }
            if (Right)
            {
                Target.RotateAroundLocal(Vector3.up, TurnSpeed * Time.deltaTime);
            }
        }
	}


    public void SetRotation(bool gazed)
    {
        IsTurn = gazed;
    }
    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter()
    {
        SetRotation(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit()
    {
        SetRotation(false);
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger()
    {

    }

    #endregion

}
