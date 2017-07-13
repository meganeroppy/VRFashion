using UnityEngine;
using System.Collections;

public class Pay : MonoBehaviour {
    private float _timer;
    private bool _gazed;

    void Start()
    {
        _gazed = false;
        _timer = 0;
    }
    void Update()
    {
        if (_gazed)
        {
            _timer += Time.deltaTime;
            if (_timer >= 3)
            {
                _gazed = false;
                GameController.instance.isPay = true;            
            }
        }
        else
        {
            _timer = 0;
        }
    }
    public void SetGazedAt(bool gazed)
    {
        _gazed = gazed;
    }


}
