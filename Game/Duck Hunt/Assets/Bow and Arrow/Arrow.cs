using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        _body = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(_body.velocity);
    }

    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifeTimer)
        {
            Destroy(gameObject);
        }

        if (!_hasHitSomething)
        {
            transform.rotation = Quaternion.LookRotation(_body.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Arrow" && !_hasHitSomething)
        {
            _hasHitSomething = true;
            Stick();
        }

        if (collision.collider.tag == "duck")
        {
            _hasHitSomething = true;
            //add to score
        }
    }

    private void Stick()
    {
        _body.constraints = RigidbodyConstraints.FreezeAll;
        SoundManagerScript.Play("hit");
    }

    private Rigidbody _body;
    private float _lifeTimer = 5f;
    private float _timer;
    private bool _hasHitSomething = false;
}
