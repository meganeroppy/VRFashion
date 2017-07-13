using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {

    private bool _plus;
    private bool _minus;
	
	// Update is called once per frame
	void Update ()
    {
        if (_plus && transform.localPosition.z > -0.5f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z - 0.05f));
        }
        if (_minus && transform.localPosition.z < 6.0f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (transform.localPosition.z + 0.05f));
        }

    }

    public void Plus(bool plus)
    {
        _plus = plus;
    }
    public void Minus(bool minus)
    {
        _minus = minus;
    }
}
