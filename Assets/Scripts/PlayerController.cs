using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
//using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public Camera camera;

    public NavMeshAgent agent;

    public Animator animator;

    [SerializeField]
    public PlayerMotor playerMotor;

    [Header("Do not modify")]
    [SerializeField]
    private Interactable focus; //enemy, kofre, pickup,
    public LayerMask interactionMask, groundMask;

    RaycastHit hit;
    bool hasHit;
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            hasHit = Physics.Raycast(ray, out hit, 1000f, groundMask);

            if (hasHit)
            {
                playerMotor.MoveToPoint(hit.point);
                SetFocus(null);
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            hasHit = Physics.Raycast(ray, out hit, 1000f, interactionMask);

            if(hasHit)
            {
                SetFocus(hit.collider.GetComponent<Interactable>());
                playerMotor.MoveToPoint(hit.point);
                float distance = Vector3.Distance(hit.transform.position, transform.position);
                if(distance < 2f)
                {
                    playerMotor.MoveToPoint(gameObject.transform.position);
                }
                Vector3 direction = (hit.transform.position - transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

                // transform.rotation = Quaternion.Slerp(transdorm.rotation, lookRotation, Time.deltaTime * 5f);
                transform.rotation = lookRotation;
            }
        }
    }

    private void LateUpdate()
    {
        if (hasHit) playerMotor.HandleTargetPointSprite(hit.point);
    }

    void SetFocus(Interactable newFocus)
    {
        // gure fokoa aldatzen den ala ez
        if(focus != newFocus && focus != null)
        {
            // jakinarazi gure previus fokusari ez dugula gehiago behar
            focus.OnDefocus();
        }

        // markatzen dugu klik egindako foko berri bat bezala
        // klikatutakoa ez bada interactable, ez du balio (null)
        focus = newFocus;

        if(focus != null)
        {
            // jakinarazi gure foko berriari fokuseatuta dagoela
            focus.OnFocused(gameObject.transform);
        }
    }
}