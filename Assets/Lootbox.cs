using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootbox : MonoBehaviour
{
    private TileManagement tilemap;
    private GridLayout gridLayout;
    private bool triggered = false;

    public CreatureType[] awards;
    
    // Start is called before the first frame update
    void Start()
    {
       GameObject GlobalTileMap = GameObject.FindGameObjectWithTag("TileMap");

        tilemap = GlobalTileMap.GetComponent<TileManagement>();
        gridLayout = GlobalTileMap.GetComponentInParent<GridLayout>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.GetComponent<CanTriggerLootbox>())
        {
            InventoryManager inventoryManager =  FindObjectOfType<InventoryManager>();
            foreach (CreatureType c in awards)
            {
                inventoryManager.AddInventory(c);
            }
            triggered = true;
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
    }
}
