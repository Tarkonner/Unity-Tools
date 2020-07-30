using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Camera _camera;
    private Vector2 _dir;
    private float _degree;

    void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        //Variabels
        var position = transform.position;
        _dir = ((Vector2)_camera.ScreenToWorldPoint(Input.mousePosition)-(Vector2)position).normalized;
        //Set cannonsposition
        transform.position = (Vector2)position+_dir;
        //Calculate
        _degree = Mathf.Atan2(_dir.y,_dir.x)*Mathf.Rad2Deg; // Get degree
        Quaternion rotaQuaternion = Quaternion.AngleAxis(_degree,Vector3.forward); //Make quaternion in 2D
        //Set rotation
        transform.rotation = rotaQuaternion;
    }
}
