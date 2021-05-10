using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject brickWallPrefab;
    public GameObject spikePrefab;
    public GameObject lavaPrefab;
    public GameObject track;

    public ScoreScript score;

    private int _lastObstaclePosition = 0;
    private int _obstacleSpacing;
    private float _trackLength;
    private const float TrackWidth = 14;
    private const float TrackWallX = 7;

    // Start is called before the first frame update
    void Start()
    {
        _trackLength = track.GetComponent<Collider>().bounds.size.z - 10;

        score = new ScoreScript();
        _obstacleSpacing = 35 - score.get()*5;

        if (_obstacleSpacing < 5)
        {
            _obstacleSpacing = 5;
        }

        int startPos = 10 + _obstacleSpacing;

        for (int i = startPos; i < _trackLength; i += _obstacleSpacing)
        {
            var zLoc = _lastObstaclePosition + _obstacleSpacing;
            _lastObstaclePosition = zLoc;

            int obstactleType = Random.Range(0, 4);

            switch (obstactleType)
            {
                case 0:
                    GenerateBrickWall(zLoc);
                    break;
                case 1:
                    GenerateJump(zLoc);
                    break;
                case 2:
                    GenerateSpikes(zLoc);
                    break;
                case 3:
                    GenerateLava(zLoc);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBrickWall(int zLoc)
    {
        var leftWallLength = Random.Range(0f, 12f);
        var maxOpening = Mathf.Min(7, TrackWidth - leftWallLength);
        var opening = Random.Range(2, maxOpening);
        var rightWallLength = TrackWidth - opening - leftWallLength;

        var rightCenter = TrackWallX - rightWallLength / 2;
        var leftCenter = -1*(TrackWallX - leftWallLength / 2);

        if (leftWallLength > 0.5)
        {
            var leftWall = Instantiate(brickWallPrefab);
            leftWall.transform.localScale = new Vector3(leftWallLength, 4, 1);
            leftWall.transform.position = new Vector3(leftCenter, 2, zLoc);
        }
        
        if (rightWallLength > 0.5)
        {
            var rightWall = Instantiate(brickWallPrefab);
            rightWall.transform.localScale = new Vector3(rightWallLength, 4, 1);
            rightWall.transform.position = new Vector3(rightCenter, 2, zLoc);
        }
    }

    private void GenerateJump(int zLoc)
    {
        var height = Random.Range(1f, 2.5f);

        var wall = Instantiate(brickWallPrefab);
        wall.transform.localScale = new Vector3(TrackWidth, height, 1);
        wall.transform.position = new Vector3(0, height/2, zLoc);
    }

    private void GenerateSpikes(int zLoc)
    {
        var opening = Random.Range(-3, 2);
        opening = opening * 2; // number msut be even

        for (int i = -6; i <= 6; i += 2)
        {
            if (i != opening && i != opening + 2)
            {
                var spike = Instantiate(spikePrefab);
                spike.transform.position = new Vector3(i, 2.25f, zLoc);
            }
        }
    }

    private void GenerateLava(int zLoc)
    {
        var bridgeLoc = Random.Range(-2f, 2f);

        var lavaObj = Instantiate(lavaPrefab);
        lavaObj.transform.position = new Vector3(0, 0.26f, zLoc);
        var bridge = lavaPrefab.transform.GetChild(0).gameObject;
        bridge.transform.position = new Vector3(bridgeLoc, 2.5f, 10);
    }
}
