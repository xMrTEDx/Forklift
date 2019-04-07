using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarriageInputSettings
{
    [Header("Maszt")]

    [SerializeField]
    private string goDownAxis;
    [SerializeField]
    private string leftRightAxis;
    [SerializeField]
    private string rotationAxis;
    [Header("Steering")]
    [SerializeField]
    private KeyCode lights;

    [Space]
    [Header("Speeds")]
    [SerializeField]
    private float goDownSpeed = 1;
    [SerializeField]
    private float leftRightSpeed = 1;
    [SerializeField]
    private float rotationSpeed = 1;

    public float UpDownValue
    {
        get
        {
            return Input.GetAxis("KaretkaGoraDol") * goDownSpeed * Time.deltaTime;
            //return Input.GetAxis(goDownAxis) * goDownSpeed * Time.deltaTime;
        }
    }
    public float LeftRightValue
    {
        get
        {
            //return ((float)(GameManager.Instance.InputManager.GetKeyDown(InputManager.InputAction.karetkaPrawo) == true ? 1: 0) - (float)(GameManager.Instance.InputManager.GetKeyDown(InputManager.InputAction.karetkaLewo)==true?1:0))  * leftRightSpeed * Time.deltaTime;
            return Input.GetAxis("KaretkaLewoPrawo") * leftRightSpeed * Time.deltaTime;
        }
    }
    public float rotationValue
    {
        get
        {
            //return GameManager.Instance.InputManager.GetAxis(InputManager.InputAction.masztPochylenie)* rotationSpeed * Time.deltaTime;
            return Input.GetAxis("MasztPochylenie") * rotationSpeed * Time.deltaTime;
        }
    }
}
