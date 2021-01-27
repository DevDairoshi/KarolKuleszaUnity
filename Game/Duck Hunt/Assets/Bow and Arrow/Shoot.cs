using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject ArrowPrefab;
    public Transform ArrowSpawn;
    public Image Power;
    public float ArrowVelocity { get; set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _shootPower += 1.0f;
            ArrowVelocity = 0.0f;

            if (_shootPower > 100.0f)
            {
                ShootArrow();
            }
        }
        else if (_shootPower > 10.0f)
        {
            ShootArrow();
        }
        else
        {
            _shootPower = 0.0f;
        }

        Power.rectTransform.localScale = new Vector3(0.2f, _shootPower / 100, 0.0f);
    }

    void ShootArrow()
    {
        ArrowVelocity = _shootPower * 0.6f;
        GameObject go = Instantiate(ArrowPrefab, ArrowSpawn.position, Quaternion.identity);
        Rigidbody rb = go.GetComponent<Rigidbody>();
        rb.velocity = MainCamera.transform.forward * ArrowVelocity;
        SoundManagerScript.Play("shoot");
        _shootPower = 0.0f;
        Power.rectTransform.localScale = new Vector3(0.2f, _shootPower / 100, 0.0f);
    }

    private float _shootPower = 0.0f;
}
