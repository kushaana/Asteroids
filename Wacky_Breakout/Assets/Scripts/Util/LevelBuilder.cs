using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    GameObject paddle;
    [SerializeField]
    GameObject[] brick = new GameObject[3];

	float standardBrickWidth; float standardBrickHeight;
	int spawnBrickRows = 3; int spawnBrickColumns = 12;
	static float standardBlockProbability;
	static float bonusBlockProbability;
	static float pickUpBlockProbability;
	float[] probabilityArray = new float[3];
	Probability randomBlock;
	Vector2 standardBrickSpawnStartPosition;
	// Start is called before the first frame update
	void Start()
    {
		standardBlockProbability = ConfigurationUtils.StdBlockProbability;
		bonusBlockProbability = ConfigurationUtils.BonusBlockProbability;
		pickUpBlockProbability = ConfigurationUtils.PickupBlockProbability;
		probabilityArray[0] = standardBlockProbability;
		probabilityArray[1] = bonusBlockProbability;
		probabilityArray[2] = pickUpBlockProbability;
		randomBlock = new Probability();
		Instantiate(paddle);
		SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void SpawnBlock()
	{
		standardBrickWidth = brick[0].transform.lossyScale.x;
		standardBrickHeight = brick[0].transform.lossyScale.y;
		float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
		float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
		standardBrickSpawnStartPosition = new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2 - spawnBrickColumns / 2 * standardBrickWidth, ScreenUtils.ScreenTop - screenHeight / 5);
		float spawnBlockStartX; float spawnBlockStartY = standardBrickSpawnStartPosition.y;
		Vector2 spawnPosition;
		for (int y = 0; y < spawnBrickRows; y++)
		{
			spawnBlockStartX = standardBrickSpawnStartPosition.x;
			for (int x = 0; x < spawnBrickColumns; x++)
			{
				spawnPosition = new Vector2(spawnBlockStartX, spawnBlockStartY);
				int randomBlockIndex = randomBlock.choose(probabilityArray);
				Instantiate(brick[randomBlockIndex],spawnPosition,Quaternion.identity);
				spawnBlockStartX += standardBrickWidth;
			}
			spawnBlockStartY -= standardBrickHeight;
		}
	}
}
