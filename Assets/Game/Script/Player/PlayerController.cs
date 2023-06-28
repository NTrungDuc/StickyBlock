using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3f;
    [SerializeField] float controlSpeed = 5f;
    [SerializeField] bool isTouching;

    float touchPosX;

    void Start()
    {

    }


    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {

            if (PlayerManager.Instance.playerState == PlayerManager.PlayerState.Move)
            {
                transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
            }
            if (isTouching)
            {
                touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
            }

            transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);

    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

}
