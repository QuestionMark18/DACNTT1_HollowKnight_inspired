using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : OverrideMonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get => _instance; }

    private Vector3 _mousePosition;
    public Vector3 MousePosition { get => _mousePosition; }

    private float _mouseDown;
    public float MouseDown { get => _mouseDown; }

    private float _horizontal;
    public float Horizontal => _horizontal;

    private float _vertical;
    public float Vertical => _vertical;


    protected override void Awake()
    {
        InputManager._instance = this;
    }

    private void Update()
    {
        //GetMousePosition();
    }

    public virtual Vector3 GetMousePosition()
    {
        return this._mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public virtual float GetMouseDown()
    {
        return this._mouseDown = Input.GetAxis("Fire1");
    }

    public virtual float GetHorizontal()
    {
        return this._horizontal = Input.GetAxisRaw("Horizontal");
    }

    public virtual float GetVertical()
    {
        return this._vertical = Input.GetAxisRaw("Vertical");
    }
}
