using UnityEngine;
using System.Collections;


public class Sha : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int chon = UnityEngine.Random.Range(0, 3);
        if (chon == 0)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            this.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
