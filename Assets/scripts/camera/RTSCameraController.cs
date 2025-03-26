using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class RTSCameraController : MonoBehaviour
{
    public static RTSCameraController Instance;

    // made using https://www.youtube.com/watch?v=mIgRfwzMkqM&list=PLtLToKUhgzwkCRQ9YAOtUIDbDQN5XXVAs&index=4


    // for camera to follow selected
    //    public void OnMouseDown()
    //    {
    //        CameraController.instance.followTransform = transform;
    //    }

    [Header("General")]
    [SerializeField] Transform cameraTransform;
    public Transform followTransform;
    private Vector3 newPosition;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    [Header("Optional Functionality")]
    [SerializeField] bool moveWithKeyboad = true;
    [SerializeField] bool moveWithEdgeScrolling = true;
    //[SerializeField] bool moveWithMouseDrag;

    [Header("Keyboard Movement")]
    [SerializeField] float normalSpeed = 0.01f;
    [SerializeField] float fastSpeed = 0.05f;
    [SerializeField] float cameraSensitivity = 5f;
    private float movementSpeed;

    [Header("Edge Scrolling")]
    [SerializeField] float edgeSize = 50f;
    bool isCursorSet = false;
    public Texture2D cursorArrowUp;
    public Texture2D cursorArrowDown;
    public Texture2D cursorArrowLeft;
    public Texture2D cursorArrowRight;

    
    
    CursorArrow currentCursor = CursorArrow.DEFAULT;
    enum CursorArrow
    {
        DEFAULT,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    private void Start()
    {
        Instance = this;
        newPosition = transform.position;
        movementSpeed = normalSpeed;

        
    }

    private void Update()
    {
        // camera follow target
        if (followTransform != null)
        {
            transform.position = followTransform.position;
        }
        else
        {
            HandleCameraMovement();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followTransform = null;
        }

    }

    private void HandleCameraMovement()
    {
        
        // mouse drag
        //if (moveWithMouseDrag)
        //{
        //    HandleMouseDraginput();
        //}

        //keyboard control ToDo (hardcoded, change to new input system)
        if (moveWithKeyboad)
        {
            if (Input.GetKey(KeyCode.LeftControl)) 
            {
                movementSpeed = fastSpeed;
            }
            else
            {
                movementSpeed = normalSpeed;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                newPosition += (transform.forward * movementSpeed);
            }                    
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) 
            {
                newPosition += (transform.forward * -movementSpeed);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                newPosition += (transform.right * movementSpeed);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                newPosition += (transform.right * -movementSpeed);
            }
        }

        // Edge scrolling ToDo (hardcoded, change to new input system)

        if (moveWithEdgeScrolling)
        {
            // right
            if (Input.mousePosition.x > Screen.width - edgeSize)
            {
                newPosition += (transform.right * movementSpeed);
                ChangeCursor(CursorArrow.RIGHT);
                isCursorSet = true;
            }
            // left
            else if (Input.mousePosition.x < edgeSize)
            {
                newPosition += (transform.right * -movementSpeed);
                ChangeCursor(CursorArrow.LEFT);
                isCursorSet = true;
            }
            // up
            else if (Input.mousePosition.y > Screen.height - edgeSize)
            {
                newPosition += (transform.forward * movementSpeed);
                ChangeCursor(CursorArrow.UP);
                isCursorSet = true;
            }
            // down
            else if (Input.mousePosition.y < edgeSize)
            {
                newPosition += (transform.forward * -movementSpeed);
                ChangeCursor(CursorArrow.DOWN);
                isCursorSet = true;
            }
            else
            {
                if (isCursorSet)
                {
                    ChangeCursor(CursorArrow.DEFAULT);
                    isCursorSet = false;
                }
            }
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * cameraSensitivity);

        // keeps cursor on screen while edge scrolling
        Cursor.lockState = CursorLockMode.Confined;
        
    }

    private void ChangeCursor(CursorArrow newCursor)
    {
        if (currentCursor != newCursor)
        {
            switch (newCursor)
            {
                case CursorArrow.UP:
                    Cursor.SetCursor(cursorArrowUp, Vector2.zero, CursorMode.Auto); 
                    break;

                case CursorArrow.DOWN:
                    Cursor.SetCursor(cursorArrowDown, new Vector2(cursorArrowDown.width , cursorArrowDown.height), CursorMode.Auto);
                    break;

                case CursorArrow.LEFT:
                    Cursor.SetCursor(cursorArrowLeft, Vector2.zero, CursorMode.Auto);
                    break;

                case CursorArrow.RIGHT:
                    Cursor.SetCursor(cursorArrowRight, new Vector2(cursorArrowRight.width, cursorArrowRight.height), CursorMode.Auto);
                    break;

                case CursorArrow.DEFAULT:
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
                    break;
            } 
            currentCursor = newCursor;
        }
    }

    //private void HandleMouseDraginput()
        //{
        //    throw new NotImplementedException();


}
