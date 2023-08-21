using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MuYu : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D myRigidbody;
    public float jumpHeight = 5.0f;
    private Camera mainCamera;
    private Animator _animator;
    void Start()
    {
        _animator=GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
                Knock();
        }
        else
        {
            Fall();
        }
        
    }

    void Knock()
    {
        _animator.SetBool("knock",true);
        myRigidbody.velocity = Vector2.up * jumpHeight;
    }
    void Fall()
    {
        _animator.SetBool("knock",false);
    }
    
}
