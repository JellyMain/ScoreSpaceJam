using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] GameObject explodeParticles;
    [SerializeField] int particlesCount = 5;
    [SerializeField] float explodeTime = 2f;
    private int angle = 0;
    private int angleGap;
    private float timer = 0f;

    private void Start()
    {
        angleGap = 360 / particlesCount;
        StartCoroutine(ExplodeTimer());
    }


    IEnumerator ExplodeTimer()
    {
        while (timer < explodeTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Explode();
    }

    private void Explode()
    {
        Destroy(gameObject);


        for (int i = 0; i < particlesCount; i++)
        {
            Bullet particles = Instantiate(explodeParticles, transform.position, Quaternion.identity).GetComponent<Bullet>();


            angle += angleGap;

            Vector2 direction = ConvertAngleToVector();

            particles.SetBulletDirection(direction);
        }

    }


    private Vector2 ConvertAngleToVector()
    {
        float angleInRadians = angle * Mathf.Deg2Rad;
        Vector2 direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        return direction;
    }
}
