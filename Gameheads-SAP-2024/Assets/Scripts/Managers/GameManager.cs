using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Class
    // Maybe move logic regarding mana and emeis to separate script
    // to avoid mess
    public static GameManager instance;
    private ArrayList manaList;
    private ArrayList enemyList;

    [SerializeField] int maxNumMana;
    [SerializeField] int maxNumEnemies;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        manaList = new ArrayList();
        enemyList = new ArrayList();
    }

    public void addToList(GameObject gO)
    {
        cleanUpLists();
        if(gO.GetComponent<InteractableObject>().getObjectType() == "enemy")
        {
            if(enemyList.Count < maxNumEnemies)
            {
                enemyList.Add(gO);
            }
            else
            {
                Destroy(gO);
            }
        }
        if (gO.GetComponent<InteractableObject>().getObjectType() == "mana")
        {
            if(manaList.Count < maxNumMana)
            {
                manaList.Add(gO);
            }
            else
            {
                Destroy(gO);
            }
        }
    }

    private void cleanUpLists()
    {
        // Remove destroyed objects from manaList
        for (int i = manaList.Count - 1; i >= 0; i--)
        {
            GameObject obj = (GameObject)manaList[i];
            if (obj == null || obj.Equals(null))
            {
                manaList.RemoveAt(i);
            }
        }

        // Remove destroyed objects from enemyList
        for (int i = enemyList.Count - 1; i >= 0; i--)
        {
            GameObject obj = (GameObject)enemyList[i];
            if (obj == null || obj.Equals(null))
            {
                enemyList.RemoveAt(i);
            }
        }
    }
}
