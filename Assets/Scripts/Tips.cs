using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tips : MonoBehaviour {
    private Text _tips;
    private float _timer;
    private bool _gazed;
    private bool _canShow;
	// Use this for initialization
	void Start () {
        _tips = GetComponent<Text>();
        _timer = 0;
        _gazed = false;
        _canShow = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (_gazed)
        {
            _timer += Time.deltaTime;
            if (_timer >= 3 && _canShow)
            {
                GameController.instance.isAdd = true;
                StartCoroutine(ShowTips());
                _canShow = false;
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
    public void SetGazedExit()
    {
        _gazed = false;
        _canShow = true;
    }

    IEnumerator ShowTips()
    {
        _tips.color = new Color(255, 0, 0, 255);
        yield return new WaitForSeconds(2);
        _tips.color = new Color(255, 0, 0, 0);
    }
}
