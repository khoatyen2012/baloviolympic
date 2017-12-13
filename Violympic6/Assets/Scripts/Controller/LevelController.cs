using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelController : MonoBehaviour {

    public Level levelPrefab;

    public float startPositonCreate;
    public float distanceTreeCreate;
    private tk2dSprite sprite;

    private tk2dSprite spriteLevel;

    #region Singleton
    private static LevelController _instance;

    public static LevelController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<LevelController>();
            return _instance;
        }
    }
    #endregion



    public void nhapnhay()
    {
        spriteLevel.SetSprite("nhapnhay");
    }

  


    void CreateLevel(float positionCreate,int i,bool level)
    {
 
        Level levelCreate = levelPrefab.Spawn<Level>
            (
               new Vector3(462f, positionCreate, 90f),
             levelPrefab.transform.rotation
            );

        sprite = levelCreate.GetComponent<tk2dSprite>();

        if(i==1)
        {
            levelCreate.setText("2:400");
        }

        if (i == 2)
        {
            levelCreate.setText("3:600");
        }

        if (i == 3)
        {
            levelCreate.setText("4:1000");
        }

        if (i == 4)
        {
            levelCreate.setText("5:2000");
        }

        if (i == 5)
        {
            levelCreate.setText("6:3000");
        }

        if (i == 6)
        {
            levelCreate.setText("7:6000");
        }

        if (i == 7)
        {
            levelCreate.setText("8:10.000");
        }

        if (i == 8)
        {
            levelCreate.setText("9:14.000");
        }

        if (i == 9)
        {
            levelCreate.setText("10:22.000");
        }


        if (i == 10)
        {
            levelCreate.setText("11:30.000");
        }


        if (i == 11)
        {
            levelCreate.setText("12:40.000");
        }


        if (i == 12)
        {
            levelCreate.setText("13:60.000");
        }


        if (i == 13)
        {
            levelCreate.setText("14:85.000");
        }


        if (i == 14)
        {
            levelCreate.setText("15:150.000");
        }




        if (level)
        {
            spriteLevel = sprite;
            sprite.SetSprite("levelchon");
            
        }
        else if ( (i == 4) || (i == 9) || (i == 14))
        {
            sprite.SetSprite("quantrong");
        }
        else
        {
            sprite.SetSprite("komau");
        }

        levelCreate.transform.parent = this.gameObject.transform;

    }

    void Create(int level)
    {
        float positionCreate = startPositonCreate;
        
        for (int i = 0; i < 15; i++)
        {
            bool ok = false;
            if (level == (i + 1))
            {
                ok = true;
            }
            CreateLevel(positionCreate, i, ok);
            positionCreate += distanceTreeCreate;
        }
    }


    public void setEmptyChild(int level)
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            children.Add(child.gameObject);
        }


        foreach (GameObject item in children)
        {
            item.transform.parent = null;
            item.transform.Recycle();
        }

        Create(level);
      
    }

	// Use this for initialization
	void Start () {
        //Create(1);
       
	}
	
	// Update is called once per frame
	void Update () {

        
	}
}
