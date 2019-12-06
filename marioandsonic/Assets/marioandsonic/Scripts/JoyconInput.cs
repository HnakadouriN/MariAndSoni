using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class JoyconInput : MonoBehaviour
{
    private float value;
    private static readonly Joycon.Button[] _buttons = Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];
    private List<Joycon> _joycons;
    private Joycon _joyconL;
    private Joycon _joyconR;
    //糖衣
    private Joycon.Button? _pressedButtonL;
    private Joycon.Button? _pressedButtonR;

    private Vector3 gyairo;
    private float[] sthick;

    // Start is called before the first frame update
    void Start()
    {
        //ジョイコンをリストに入れている
        _joycons = JoyconManager.Instance.j;
        //ジョイコンがなければここで止めている
        if (_joycons == null || _joycons.Count <= 0) return;

        //ここで右と左を判断している
        _joyconL = _joycons.Find(c => c.isLeft);
        _joyconR = _joycons.Find(c => !c.isLeft);
    }

    void Update()
    {

        var h1 = Input.GetAxis("Horizontal 1");
        var v1 = Input.GetAxis("Vertical 1");
        var h2 = Input.GetAxis("Horizontal 2");
        var v2 = Input.GetAxis("Vertical 2");

        this.transform.position += new Vector3(h1,0,v1);

        _pressedButtonL = null;
        _pressedButtonR = null;
        if (_joycons == null || _joycons.Count <= 0) return;

        //ここでジョイコンの押されたボタンを代入している
        //_pressedButtonにボタンの内容を入れている
        foreach(var button in _buttons)
        {
            if (_joyconL.GetButton(button))
            {
                _pressedButtonL = button;
            }
            if (_joyconR.GetButton(button))
            {
                _pressedButtonR = button;
            }
        }

        foreach(var joycon in _joycons)
        {
            gyairo = joycon.GetGyro();
            sthick = joycon.GetStick();
        }
        Debug.Log(h1);
        Inputkeycode();
    }
    public void Inputkeycode()
    {
        Debug.Log(_pressedButtonR);
        Debug.Log(_pressedButtonL);
        //Debug.Log(gyairo);
        Debug.Log("x座標" + sthick[0]);
        Debug.Log("y座標" + sthick[1]);
        if (Input.GetKey(KeyCode.Joystick1Button0))
        {
            Debug.Log("ジョイスティックの右のAが押されたよ");
        }
        //if (Input.GetKey(KeyCode.Joystick1Button1))
        //{
        //    Debug.Log("ジョイスティックの右のXが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button2))
        //{
        //    Debug.Log("ジョイスティックの右のBが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button3))
        //{
        //    Debug.Log("ジョイスティックの右のYが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button4))
        //{
        //    Debug.Log("ジョイスティックの右のSLが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button5))
        //{
        //    Debug.Log("ジョイスティックの右のSRが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button9))
        //{
        //    Debug.Log("ジョイスティックの+が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button14))
        //{
        //    Debug.Log("ジョイスティックの右のRが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick1Button15))
        //{
        //    Debug.Log("ジョイスティックの右のZRが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button0))
        //{
        //    Debug.Log("ジョイスティックの左の<-が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button1))
        //{
        //    Debug.Log("ジョイスティックの左の↓が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button2))
        //{
        //    Debug.Log("ジョイスティックの左の↑が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button3))
        //{
        //    Debug.Log("ジョイスティックの左の->が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button4))
        //{
        //    Debug.Log("ジョイスティックの左のSLが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button5))
        //{
        //    Debug.Log("ジョイスティックの左のSRが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button8))
        //{
        //    Debug.Log("ジョイスティックの左の-が押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button14))
        //{
        //    Debug.Log("ジョイスティックの左のLが押されたよ");
        //}
        //if (Input.GetKey(KeyCode.Joystick2Button15))
        //{
        //    Debug.Log("ジョイスティックの左のZLが押されたよ");
        //}
    }
}
