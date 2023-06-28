using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Material PlayerMat;
    public PlayerState playerState;
    public LevelState levelState;
    public Transform partcilePrefab;
    public List<GameObject> collidedList;
    public Transform Player;
    public enum PlayerState
    {
        Stop,
        Move
    }
    public enum LevelState
    {
        NotFinished,
        Finished
    }
    public void CallMakeSphere()
    {
        foreach (GameObject obj in collidedList)
        {
            obj.GetComponent<CollectionObjController>().MakeSphere();
        }
    }
}
