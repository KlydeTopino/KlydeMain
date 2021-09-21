using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private NavMeshAgent KokoPlayer;
    public GameObject MovePoint;
    public float Distance;


    public Animator KokoAnimator;
    public bool IsRunning;

    // Start is called before the first frame update
    void Start()
    {
        KokoPlayer = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
            RaycastHit HitInfo;
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Input.GetMouseButtonDown(0))
            {


                if (Physics.Raycast(Ray, out HitInfo))
                {
                    KokoPlayer.destination = HitInfo.point;
                    MovePoint.transform.position = HitInfo.point;
                    MovePoint.SetActive(true);
                }
            }

            Distance = Vector3.Distance(KokoPlayer.transform.position, MovePoint.transform.position);

            if (Distance < 1)
            {
                MovePoint.SetActive(false);
            }

            if (KokoPlayer.remainingDistance <= KokoPlayer.stoppingDistance)
        {
            IsRunning = false;
        }
            else
        {
            IsRunning = true;
        }

        KokoAnimator.SetBool("IsRunning", IsRunning);
    }
}
