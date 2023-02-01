using System.Collections;
using System.Collections.Generic;
using System.Linq; // needed for cloning the list with .ToList()
using UnityEngine;
using UnityEngine.Tilemaps; // needed for Tilemap

public class TileCollision : MonoBehaviour {
    List<Vector3Int> trackedCells;
    Tilemap tilemap;
    GridLayout gridLayout;

    void Awake() {
        trackedCells = new List<Vector3Int>();
        tilemap = GetComponent<Tilemap>();
        gridLayout = GetComponentInParent<GridLayout>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        EraseOnCollision(collision);
    }

    private void OnCollisionStay2D(Collision2D collision) {
        EraseOnCollision(collision);
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

    //void OnTriggerEnter2D(Collider2D other) {
    //    // NB: Bounds cannot have zero width in any dimension, including z
    //    var cellBounds = new BoundsInt(
    //        gridLayout.WorldToCell(other.bounds.min),
    //        gridLayout.WorldToCell(other.bounds.size) + new Vector3Int(0, 0, 1));

    //    IdentifyIntersections(other, cellBounds);
    //}

    //void OnTriggerStay2D(Collider2D other) {
    //    // Same as OnTriggerEnter2D()
    //    var cellBounds = new BoundsInt(
    //        gridLayout.WorldToCell(other.bounds.min),
    //        gridLayout.WorldToCell(other.bounds.size) + new Vector3Int(0, 0, 1));

    //    IdentifyIntersections(other, cellBounds);
    //}

    //void OnTriggerExit2D(Collider2D other) {
    //    // Intentionally pass zero size bounds
    //    IdentifyIntersections(other, new BoundsInt(Vector3Int.zero, Vector3Int.zero));
    //}

    void IdentifyIntersections(Collider2D other, BoundsInt cellBounds) {
        // Take a copy of the tracked cells
        var exitedCells = trackedCells.ToList();

        // Find intersections within cellBounds
        foreach (var cell in cellBounds.allPositionsWithin) {
            // First check if there's a tile in this cell
            if (tilemap.HasTile(cell)) {
                // Find closest world point to this cell's center within other collider
                var cellWorldCenter = gridLayout.CellToWorld(cell);
                var otherClosestPoint = other.ClosestPoint(cellWorldCenter);
                var otherClosestCell = gridLayout.WorldToCell(otherClosestPoint);

                // Check if intersection point is within this cell
                if (otherClosestCell == cell) {
                    if (!trackedCells.Contains(cell)) {
                        // other collider just entered this cell
                        trackedCells.Add(cell);

                        // Do actions based on other collider entered this cell
                    } else {
                        // other collider remains in this cell, so remove it from the list of exited cells
                        exitedCells.Remove(cell);
                    }
                }
            }
        }

        // Remove cells that are no longer intersected with
        foreach (var cell in exitedCells) {
            trackedCells.Remove(cell);

            // Do actions based on other collider exited this cell
        }
    }
}