using Unity.Mathematics;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    [SerializeField] private LootDropDataHolder _lootDropDataHolder;

    public void SpawnDrop(GameObject spawnFrom)
    {
        for (int i = 0; i < _lootDropDataHolder.lootList.Length; i++)
        {
            LootData targetLootData = _lootDropDataHolder.lootList[i];

            targetLootData.overallDropChance = ChanceCalculater.RollChance(targetLootData.dropChance, targetLootData.overallDropChance);
            if (targetLootData.overallDropChance == 0)
                SpawnItem(targetLootData.item, spawnFrom);
        }
    }

    void SpawnItem(GameObject item, GameObject comesFrom)
    {
        Instantiate(item, comesFrom.transform.position, quaternion.identity);
    }
}