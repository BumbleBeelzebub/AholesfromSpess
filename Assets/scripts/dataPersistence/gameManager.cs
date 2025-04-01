using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gameManager : MonoBehaviour
{
    //private static gameManager instance;
    [SerializeField]
    public static gameManager Instance;
    //{
    //    get
    //    {
    //        if (!Application.isPlaying)
    //        {
    //            return null;
    //        }
    //        if (instance == null)
    //        {
    //            Instantiate(Resources.Load<gameManager>("gameManager"));
    //        }
    //        return instance;
    //    }
    //}
    public saveLoadTester tester;



    private void Awake()
    {
        //if (Instance != null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        Instance = this;
        Debug.Log("awake");
    }

    private void Update()
    {
        if ( Input.GetKey(KeyCode.P))
        {
            saveSystem.Save();
            Debug.Log("boop");
        }

        if (Input.GetKey(KeyCode.O))
        {
            saveSystem.Load();
            Debug.Log("unboop");
        }
    }

}

