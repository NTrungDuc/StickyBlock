using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originalPlayer : MonoBehaviour
{
  

    private Rigidbody rb;

    [SerializeField] bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = PlayerManager.Instance.PlayerMat;
        PlayerManager.Instance.collidedList.Add(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }
    void Grounded()
    {
        isGrounded = true;
        PlayerManager.Instance.playerState = PlayerManager.PlayerState.Move;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1);
    }
}
