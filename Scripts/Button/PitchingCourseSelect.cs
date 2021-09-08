using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchingCourseSelect : ButtonManager
{
    private Vector3 coursePos;
    private float coursePosX;
    private float coursePosY;
    private Vector3 startPos;

    private GameObject ball;
    private BallController ballCon;
    private Rigidbody ballRb;

    public GameObject[] strike = new GameObject[9];
    private Vector3[] strikeScale = new Vector3[9];
    private Vector3[] strikePos = new Vector3[9];

    [SerializeField]
    private PitchingAutoController autoCon;
    [SerializeField]
    private BatControllerAnimation batCon;
    [SerializeField]
    private GameObject swingJudge;
    private Vector3 startJudgePos;

    void Start()
    {
        ball = GameObject.Find("Ball");
        ballCon = ball.GetComponent<BallController>();
        ballRb = ball.GetComponent<Rigidbody>();
        startPos = ball.transform.position;
        startJudgePos = swingJudge.transform.position;
        
        for(int i = 0; i < strike.Length; i++)
        {
            strike[i] = GameObject.Find("Strike" + i);
            strikePos[i] = strike[i].transform.position;
            strikeScale[i] = strike[i].transform.localScale;
        }
    }

    protected override void OnClick(string buttonName)
    {
        float maxY = 0f;
        float minY = 0f;
        float maxX = 0f;
        float minX = 0f;

        // 右バッター基準
        if (buttonName.Equals("OutCourse"))
        {
            maxY = strikePos[0].y + strikeScale[0].y / 2;
            minY = strikePos[2].y - strikeScale[2].y / 2;
            maxX = strikePos[0].x + strikeScale[0].x / 2;
            minX = strikePos[0].x - strikeScale[0].x / 2;        
        }
        else if(buttonName.Equals("InCourse"))
        {
            maxY = strikePos[6].y + strikeScale[6].y / 2;
            minY = strikePos[8].y - strikeScale[8].y / 2;
            maxX = strikePos[6].x + strikeScale[6].x / 2;
            minX = strikePos[6].x - strikeScale[6].x / 2;
        }
        else if(buttonName.Equals("HighCourse"))
        {
            maxY = strikePos[0].y + strikeScale[0].y / 2;
            minY = strikePos[0].y - strikeScale[0].y / 2;
            maxX = strikePos[0].x + strikeScale[0].x / 2;
            minX = strikePos[6].x - strikeScale[6].x / 2;
        }
        else if(buttonName.Equals("LowCourse"))
        {
            maxY = strikePos[2].y + strikeScale[2].y / 2;
            minY = strikePos[2].y - strikeScale[2].y / 2;
            maxX = strikePos[2].x + strikeScale[2].x / 2;
            minX = strikePos[8].x - strikeScale[8].x / 2;
        }

        coursePosX = Random.Range(minX, maxX);
        coursePosY = Random.Range(minY, maxY);
        coursePos = new Vector3(coursePosX, coursePosY, strikePos[0].z);

        if (buttonName.Equals("Reset"))
        {
            ballRb.useGravity = false;
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            FlagManager.instance.isStrike = false;
            ball.transform.position = startPos;
            swingJudge.transform.position = startJudgePos;
            autoCon.IdleAnimation();
            batCon.SwingIdle();
            return;
        }
        else if(buttonName.Equals("Center"))
        {
            coursePos = strikePos[4];
        }

        autoCon.ThrowAnimation();
        Invoke("Throw", 0.6f);
    }

    private void Throw()
    {
        ballCon.Throw(coursePos);
    }
}
