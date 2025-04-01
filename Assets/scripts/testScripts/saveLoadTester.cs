using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLoadTester : MonoBehaviour
{
    

    public void Save (ref PlayerSaveData data)
    {
        data.Position = transform.position;
    }
    public void Load ( PlayerSaveData data)
    {
        transform.position = data.Position;
    }
}
[System.Serializable]
public struct PlayerSaveData
{
    public Vector3 Position;
}