using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        _body.useGravity = true;
        _timer = 15.0f;

        if (collision.collider.tag == "Arrow" && !_dead)
        {
            DuckSpawner.Score++;
            _dead = true;
        }
    }

    private Rigidbody _body;
    private float _timer = 0.0f;
    private float _lifeTime = 60.0f;
    private bool _dead = false;
}
