using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float HorizontalAxis {get; private set;} = 0f;
    public float VerticalAxis {get; private set;} = 0f;
    public Vector2 Direction  {get; private set;} = new Vector2();
    public Vector2 MousePos {get; private set;} = new Vector2();

    public bool LeftMB {get; private set;} = false;

    public ActionKey DashKey {get; private set; } = new ActionKey(KeyCode.LeftShift);
    void Update()
    {
        LeftMB = Input.GetMouseButton(0);
        HorizontalAxis = (Input.GetKey(KeyCode.D)?1:0) - (Input.GetKey(KeyCode.A)?1:0);
        VerticalAxis = (Input.GetKey(KeyCode.W)?1:0) - (Input.GetKey(KeyCode.S)?1:0);
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Direction = new Vector2(HorizontalAxis, VerticalAxis).normalized;
        DashKey.Update();
    }

    public class ActionKey
    {
        private readonly KeyCode keyCode;
        private UnityEvent Pressed = new UnityEvent();
        private UnityEvent Released = new UnityEvent();
        public bool isDown;

        public ActionKey(KeyCode keyCode)
        {
            this.keyCode = keyCode;
        }

        public void SetPressedAction(UnityAction action)
        {
            Pressed.AddListener(action);
        }

        public void Update()
        {
            bool isDownNext = Input.GetKey(keyCode);
            if(!isDown && isDownNext)
            {
                Pressed.Invoke();
            }
            else if(isDown && !isDownNext)
            {
                Released.Invoke();
            }
            isDown = isDownNext;
        }
    }
}