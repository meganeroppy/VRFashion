using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
//using Facebook.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;

    
    public GameObject scene1;
    public GameObject scene2;
    public Transform ItemPos;
    public GameObject[] Prefabs;
    public GameObject[] modles;
    public Transform spawnPos;
    public RectTransform CartTransform;
    public GameObject listPrefab;
    public Text nameText;
    public string[] NameStrings;

    public bool isCreate = true;
    public bool isAdd;
    public bool isPay = false;

    private float _turnTimer = 0;
    private float _backTimer = 0;

    private bool _isTurn = false;
    private bool _isBack = false;
    private GameObject _item;
    private int ItemID;
    private int Index = 0;
    private string str;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
		ChangeToScene1 ();
        isAdd = false;
    }
    void Update()
    {
        if (isAdd)
        {
            isAdd = false;
            GameObject go = Instantiate(listPrefab);
            go.transform.SetParent(CartTransform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localRotation = Quaternion.identity;
            go.transform.localScale = Vector3.one;
            go.GetComponentInChildren<Text>().text = NameStrings[ItemID];
            if (ItemID < 10)
            {
                go.name = "0" + Index;
            }
            else
            {
                go.name = "10";
            }
        }

        if (_isTurn && scene1.activeInHierarchy)
        {
            _turnTimer += Time.deltaTime;
            if (_turnTimer >= 3.0f)
            {
                ChangeToScene2();
                _item = Instantiate(Prefabs[ItemID]);
                _item.transform.parent = ItemPos.transform;
                _item.transform.localPosition = Vector3.zero;
                _item.transform.localRotation = Quaternion.identity;
                nameText.text = NameStrings[ItemID];
                _turnTimer = 0;
                _isTurn = false;
            }
        }
        else
        {
            _turnTimer = 0;
        }


        if (_isBack && scene2.activeInHierarchy)
        {
            _backTimer += Time.deltaTime;
            if (_backTimer >= 3.0f)
            {
                ChangeToScene1();
                Destroy(_item);
                ItemPos.transform.localPosition = new Vector3(ItemPos.transform.localPosition.x,ItemPos.transform.localPosition.y,0.0f);
                ItemPos.transform.localRotation = Quaternion.Euler(Vector3.zero);
                _backTimer = 0;
                _isBack = false;
            }
        }
        else
        {
            _backTimer = 0;
        }

        if (isCreate)
        {
            isCreate = false;
            CreateModle();
            Index++;
            if (Index >= modles.Length)
            {
                Index = 0;
            }
        }

        if (isPay)
        {
            isPay = false;
            if (CartTransform.childCount != 0)
            {
                string[] strArray = new string[CartTransform.childCount];
                string temp = null;
                for (int i = 0; i < CartTransform.childCount; i++)
                {
                    strArray[i] = CartTransform.GetChild(i).name;
                }
                for (int i = 0; i < strArray.Length-1; i++)
                {
                    temp += strArray[i] + ",";
                }
                str = temp + strArray[strArray.Length-1];
                Application.OpenURL("https://cart.kabuki-jp.co/carts/create?cid=" + str);
            }
        }
    }

    void ChangeToScene2()
    {
        scene1.SetActive(false);
        scene2.SetActive(true);
    }
    void ChangeToScene1()
    {
        scene1.SetActive(true);
        scene2.SetActive(false);
    }
    void CreateModle()
    {
        ItemID = Index;
        GameObject go = Instantiate(modles[Index]);
        go.transform.SetParent(spawnPos);
        go.transform.localPosition = Vector3.zero;
    }
    public void SetIsTurn(bool gazed)
    {
        _isTurn = gazed;
    }
    public void SetIsBack(bool gazed)
    {
        _isBack = gazed;
    }

    public void SetItemID(int id)
    {
        ItemID = id;
    }  
}
