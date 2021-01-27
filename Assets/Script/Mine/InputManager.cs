using System;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public float camZoomSensitivity = 0.1f;
    public float camPanSensitivity = 0.1f;

    bool _mouseDowned;
    Vector2 _mouseLastLoc;
    Camera _cam;

    void Start() {
        _cam = Camera.main;
    }

    void Update() {
        _cam.transform.position -= new Vector3(0, 0, Input.mouseScrollDelta.y * camZoomSensitivity);
        if (Input.GetMouseButtonDown(0)) {
            _mouseLastLoc = Input.mousePosition;
            _mouseDowned = true;
        } else if (Input.GetMouseButton(0)) {
            var delta = (Vector2) Input.mousePosition - _mouseLastLoc;
            var point = Camera.main.transform.TransformPoint(delta);
            var pointDelta = point - Camera.main.transform.position;
            _cam.transform.position -= pointDelta * camPanSensitivity;
        } else if (Input.GetMouseButtonUp(2)) {
            _mouseDowned = false;
        }
        if (_mouseDowned)
            _mouseLastLoc = Input.mousePosition;
    }
}