using System.Collections;
using System.Collections.Generic;
using System.Linq; // needed for cloning the list with .ToList()
using UnityEngine;
using UnityEngine.Tilemaps; // needed for Tilemap

public class TileCollision : MonoBehaviour {
    Tilemap tilemap;
    GridLayout gridLayout;

    private void OnCollisionEnter2D(Collision2D collision) {
        //EraseOnCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        //EraseOnCollision(collision);
    }

    private void EraseOnCollision(Collision2D collision) {
        List<ContactPoint2D> contacts = new List<ContactPoint2D>();
        collision.GetContacts(contacts);

        List<Vector3Int> positions = new List<Vector3Int>();
        contacts.ForEach((contact) => {
            Vector3Int palettePosition = gridLayout.WorldToCell(contact.point);

            positions.AddRange(new List<Vector3Int> {
            palettePosition,
            new Vector3Int(palettePosition.x + 1, palettePosition.y),
            new Vector3Int(palettePosition.x - 1, palettePosition.y),
            new Vector3Int(palettePosition.x, palettePosition.y + 1),
            new Vector3Int(palettePosition.x, palettePosition.y - 1),
            new Vector3Int(palettePosition.x + 1, palettePosition.y + 1),
            new Vector3Int(palettePosition.x - 1, palettePosition.y + 1),
            new Vector3Int(palettePosition.x - 1, palettePosition.y + 1),
            new Vector3Int(palettePosition.x - 1, palettePosition.y - 1)
            });
        });

        positions.ForEach((position) => tilemap.SetTile(position, null));
    }
}