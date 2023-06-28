using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    [SerializeField] Vector3 offset;
    // Start is called before the first frame update
    public void LateUpdate()
    {
        if (PlayerManager.Instance.levelState == PlayerManager.LevelState.NotFinished)
        {
            Vector3 desiredPos = target.position + offset;
            transform.position = new Vector3(transform.position.x, transform.position.y, desiredPos.z);
        }
    }
}
