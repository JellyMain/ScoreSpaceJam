using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerVisuals : MonoBehaviour
{
    private const string IS_DASHING = "isDashing";

    [SerializeField] Rigidbody2D rb;
    [SerializeField] ParticleSystem playerParticles;
    [SerializeField] Animator animator;
    private TrailRenderer playerTrailRenderer;
    private Vector2 lastVelocity;

    private void Awake()
    {
        playerTrailRenderer = GetComponent<TrailRenderer>();
    }


    private void FixedUpdate()
    {
        HandleDeformation();
        SetDashingEffects();
    }


    private void SetDashingEffects()
    {
        playerTrailRenderer.emitting = Player.Instance.isDashing;
        if (Player.Instance.isDashing)
        {
            animator.SetTrigger(IS_DASHING);
        }
    }


    private void HandleDeformation()
    {
        Vector2 currentVelocity = rb.velocity;

        if (lastVelocity == Vector2.zero && currentVelocity != Vector2.zero)
        {

            StartDeforming();
            playerParticles.Play();

        }
        else if (lastVelocity != Vector2.zero && currentVelocity == Vector2.zero)
        {
            StopDeforming();
            playerParticles.Stop();
        }
        lastVelocity = currentVelocity;
    }

    private void StartDeforming()
    {
        transform.DOScale(new Vector3(0.7f, 1, 1), 0.2f);
    }


    private void StopDeforming()
    {
        transform.DOScale(new Vector3(1, 1, 1), 0.2f);
    }


}
