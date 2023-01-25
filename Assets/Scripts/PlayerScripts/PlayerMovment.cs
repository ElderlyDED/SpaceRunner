using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public static PlayerMovment instance;
    [SerializeField] Vector3 targetPos;
    [SerializeField] float laneOffsetZ;
    [SerializeField] float laneOffsetY;
    [SerializeField] float laneChangeSpeed;
    [SerializeField] bool PlayerMove;
    [SerializeField] bool PlayerMoveY;
    [SerializeField] Animator ShipAnimator;

    public bool OnOffMove;
    private void Awake()
    {
        PlayerMovment.instance = this;
    }
    void Start()
    {
        OnOffMove = true;
        targetPos = transform.position;
    }

    void Update()
    {
        LeftRightMove();
    }

    void LeftRightMove()
    {
        if (OnOffMove == true)
        {
            CheckMove();
            if (Input.GetKeyDown(KeyCode.A) && targetPos.z > -laneOffsetZ && PlayerMove == false)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y, targetPos.z - laneOffsetZ);
                StartCoroutine(ShipAnimDelay("Left"));
            }
            if (Input.GetKeyDown(KeyCode.D) && targetPos.z < laneOffsetZ && PlayerMove == false)
            {
                targetPos = new Vector3(transform.position.x, transform.position.y, targetPos.z + laneOffsetZ);
                StartCoroutine(ShipAnimDelay("Right"));
            }
            if (Input.GetKeyDown(KeyCode.S) && targetPos.y > -laneOffsetY && PlayerMove == false)
            {
                targetPos = new Vector3(transform.position.x, targetPos.y - laneOffsetY, transform.position.z);
                StartCoroutine(ShipAnimDelay("Down"));
            }
            if (Input.GetKeyDown(KeyCode.W) && targetPos.y < laneOffsetY && PlayerMove == false)
            {
                targetPos = new Vector3(transform.position.x, targetPos.y + laneOffsetY, transform.position.z);
                StartCoroutine(ShipAnimDelay("Top"));
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, laneChangeSpeed * Time.deltaTime);
        }
    }

    IEnumerator ShipAnimDelay(string AnimID)
    {
        ShipAnimator.SetBool(AnimID, true);
        yield return new WaitForSeconds(0.1f);
        ShipAnimator.SetBool(AnimID, false);

    }

    void CheckMove()
    {
        if(transform.position != targetPos)
        {
            PlayerMove = true;
        }
        else
        {
            PlayerMove= false;
        }
    }
}

