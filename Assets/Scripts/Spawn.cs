using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public void Create()
    {
        GameController.instance.isCreate = true;
        Destroy(this.transform.parent.gameObject);
    }
}
