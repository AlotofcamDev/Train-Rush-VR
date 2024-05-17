using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


#region Singleton
public class GameManager : MonoBehaviour
{
    public int credits = 0;

    public static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }


}
#endregion