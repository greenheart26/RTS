using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _rotateSpeed = 1;

    private Quaternion _defaultRotation;
    void Start() {
        _defaultRotation = Camera.main.transform.rotation;
    }

    void Update() {
        TranslateCamera();
        //RotateCamera();
        //Camera.main.transform.LookAt(gameObject.transform);
    }

    private void TranslateCamera() {
        /***Position***/
        var cameraPos = Camera.main.transform.position;
        float speedX = cameraPos.x;
        float speedZ = cameraPos.z;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            speedX += _moveSpeed * Time.deltaTime * -1; //negative x          
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            speedX += _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            speedZ += _moveSpeed * Time.deltaTime; // negative y
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            speedZ += _moveSpeed * Time.deltaTime * -1;
        }
        Camera.main.transform.position = new Vector3(speedX, cameraPos.y, speedZ);
    }

    //TODO Finish this
    private void RotateCamera() {
        /***Rotation***/
        var cameraRot = Camera.main.transform.rotation;
        float angleY = cameraRot.y;

        float z = transform.eulerAngles.z; //Keeps camera flat along x-z

        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            Camera.main.transform.rotation = _defaultRotation;
        }
        if (Input.GetKey(KeyCode.Keypad4)) {
            angleY += _rotateSpeed * Time.deltaTime * -1; //Negative for left
        }
        if (Input.GetKey(KeyCode.Keypad6)) {
            angleY += _rotateSpeed * Time.deltaTime;
        }

       
    }
}
