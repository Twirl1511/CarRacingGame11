using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleCounterForUI : MonoBehaviour
{
    private GameObject Player1_Blue;
    private GameObject Player2_Red;


    private Vector2 CenterVector;
    [SerializeField] private GameObject StartPlayer1;
    [SerializeField] private GameObject StartPlayer2;


    [SerializeField] private GameObject BlueCarObj;
    [SerializeField] private GameObject BlueMotoObj;
    [SerializeField] private GameObject BlueMonsterObj;
    [SerializeField] private Text BlueTextForInt;
    [SerializeField] private Text BlueTextForFloat;

    [SerializeField] private GameObject RedCarObj;
    [SerializeField] private GameObject RedMotoObj;
    [SerializeField] private GameObject RedMonsterObj;

    public float Player1_BlueFloat;
    public float Player1_BlueFloat1;

    void Start()
    {
        WhichRacerIsActive();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        BlueTextForInt.text = Player1_Blue.GetComponent<CircleCounter>().PlayerCircleCounter.ToString();
        AngleForPlayer1_Blue();
        
    }

    private void WhichRacerIsActive()
    {
        if (BlueCarObj.activeSelf) Player1_Blue = BlueCarObj;
        if (BlueMotoObj.activeSelf) Player1_Blue = BlueMotoObj;
        if (BlueMonsterObj.activeSelf) Player1_Blue = BlueMonsterObj;

        if (RedCarObj.activeSelf) Player2_Red = RedCarObj;
        if (RedMotoObj.activeSelf) Player2_Red = RedMotoObj;
        if (RedMonsterObj.activeSelf) Player2_Red = RedMonsterObj;
    }
    public float TEST = 36;

    public bool LeftStartFlag = false;
    public bool RightStartFlag = false;
    private void AngleForPlayer1_Blue()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
