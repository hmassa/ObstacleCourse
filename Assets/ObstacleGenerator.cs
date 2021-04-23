using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject brickWallPrefab;

    private float _lastObstaclePosition = 0;
    private const float ObstacleSpacing = 10f;
    private const float TrackWidth = 14f;
    private const float TrackWallX = TrackWidth / 2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            GenerateBrickWall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBrickWall()
    {
        var openingWidth = Random.Range(2f, 7f);
        var minX = TrackWallX - openingWidth / 2;
        var openingLoc = Random.Range(-1 * minX, minX);

        var rightEnd = openingLoc + openingWidth / 2;
        var leftEnd = openingLoc - openingWidth / 2;
        var rightCenter = (rightEnd + TrackWidth/2) / 2;
        var leftCenter = (leftEnd - TrackWidth/2) / 2;

        var zLoc = _lastObstaclePosition + ObstacleSpacing;
        _lastObstaclePosition = zLoc;

        var leftWall = Instantiate(brickWallPrefab);
        var leftLength = leftEnd - TrackWidth/2;
        leftWall.transform.localScale = new Vector3(leftLength, 4, 1);
        leftWall.transform.position = new Vector3(leftCenter, 2, zLoc);

        var rightWall = Instantiate(brickWallPrefab);
        var rightLength = TrackWidth / 2 - rightEnd;
        rightWall.transform.localScale = new Vector3(rightLength, 4, 1);
        rightWall.transform.position = new Vector3(rightCenter, 2, zLoc);


    }
}
