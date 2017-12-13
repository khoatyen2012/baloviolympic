using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    private GameObject bough;
    private tk2dTextMesh txtLevel;

    void Awake()
    {
        bough = this.gameObject.transform.GetChild(0).gameObject;
        txtLevel = bough.GetComponent<tk2dTextMesh>();
    }

	// Use this for initialization
	void Start () {
    
      
	}

   public  void setText(string mLevel)
    {
        txtLevel.text =  mLevel;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
