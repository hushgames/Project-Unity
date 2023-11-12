using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    private float speed = 10.0f;
    private float verticalInput;
    private float horizontalInput;
    private float xRange = 7.42f;
    private float forwardBoundary = 9.02f;
    private float backBoundary = -19.30f;
    public GameObject gun;
    public Camera mainCamera;
    public Camera firstPesonView;
    public Camera wideCamera;
    public KeyCode switchKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        } else if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < backBoundary) {
            transform.position = new Vector3(transform.position.x, transform.position.y, backBoundary);
        } else if (transform.position.z > forwardBoundary) {
            transform.position = new Vector3(transform.position.x, transform.position.y, forwardBoundary);
        }

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        
        if(Input.GetKeyDown(KeyCode.C)) {
            Instantiate(gun, transform.position, gun.transform.rotation);
        }

        if(Input.GetKeyDown(switchKey)) {
            if (!firstPesonView.enabled && !wideCamera.enabled) {
                mainCamera.enabled = !mainCamera.enabled;
                firstPesonView.enabled = !firstPesonView.enabled;
            } else if (!mainCamera.enabled && !wideCamera.enabled) {
                firstPesonView.enabled = !firstPesonView.enabled;
                wideCamera.enabled = !wideCamera.enabled;
            } else if (!mainCamera.enabled && !firstPesonView.enabled) {
                wideCamera.enabled = !wideCamera.enabled;
                mainCamera.enabled = !mainCamera.enabled;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            Destroy(collision.gameObject);
            health -= 1;
        }

        if(collision.gameObject.tag == "Enemy") {
            
        }
    }

    // void OnCollisionStay(Collision collision) {
    //     if(collision.gameObject.tag == "Wall") {
    //         transform.Translate(0, 0, 0.5f);
    //     }
    // }

    
}
