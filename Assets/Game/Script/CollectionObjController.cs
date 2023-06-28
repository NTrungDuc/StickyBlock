using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionObjController : MonoBehaviour
{
    [SerializeField] Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        sphere = transform.GetChild(0);
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;

            GetComponent<Renderer>().material = PlayerManager.Instance.PlayerMat;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cube")
        {
            if (!PlayerManager.Instance.collidedList.Contains(collision.gameObject))
            {
                collision.gameObject.tag = "Player";
                collision.transform.parent = PlayerManager.Instance.Player;
                PlayerManager.Instance.collidedList.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectionObjController>();
            }
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            DestroyCube();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            if (PlayerManager.Instance.levelState != PlayerManager.LevelState.Finished)
            {
                PlayerManager.Instance.levelState = PlayerManager.LevelState.Finished;
                PlayerManager.Instance.CallMakeSphere();
            }
        }
    }
    void DestroyCube()
    {
        PlayerManager.Instance.collidedList.Remove(gameObject);
        Destroy(gameObject);
        Transform partcile = Instantiate(PlayerManager.Instance.partcilePrefab, transform.position, Quaternion.identity);
        partcile.GetComponent<ParticleSystem>().startColor = PlayerManager.Instance.PlayerMat.color;
    }
    public void MakeSphere()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        sphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
        sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
        //sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;

        sphere.gameObject.GetComponent<Renderer>().material = PlayerManager.Instance.PlayerMat;
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().useGravity = true;

    }
}
