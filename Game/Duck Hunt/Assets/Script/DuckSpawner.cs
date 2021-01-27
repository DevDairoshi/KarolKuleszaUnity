using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckSpawner : MonoBehaviour
{
    public GameObject DuckPrefab;
    public Text ScoreText = null;

    public float DuckVelocity = 3.0f;

    public static int Score;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _spawnTime)
        {
            Spawn();
        }
        ScoreText.text = $"SCORE: {Score}";
    }

    void Spawn()
    {
        Vector3 pos = new Vector3((float)(_rnd.Next(600) + 200), (float)(_rnd.Next(60) + 20), (float)(_rnd.Next(600) + 200));
        GameObject go = Instantiate(DuckPrefab, pos, Quaternion.identity);
        Rigidbody rb = go.GetComponent<Rigidbody>();

        Vector3 vel = new Vector3((float)(_rnd.Next(7)-3), 0, (float)(_rnd.Next(7)-3));
        rb.velocity = vel * DuckVelocity;
        go.transform.rotation = Quaternion.LookRotation(rb.velocity);

        _timer = 0.0f;
    }

    private float _spawnTime = 6.0f;
    private float _timer;
    private readonly System.Random _rnd = new System.Random();
}
