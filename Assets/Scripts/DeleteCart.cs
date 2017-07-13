using UnityEngine;
using System.Collections;

public class DeleteCart : MonoBehaviour {

    private float _timer;
    private bool _gazed;
	// Use this for initialization
	void Start () {
        _timer = 0;
        _gazed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (_gazed)
        {
            _timer += Time.deltaTime;
            if (_timer >= 3)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
        else
        {
            _timer = 0;
        }
	}

    public void SetGazedAt()
    {
        _gazed = true;
    }
    public void SetGazedExit()
    {
        _gazed = false;
    }
}
