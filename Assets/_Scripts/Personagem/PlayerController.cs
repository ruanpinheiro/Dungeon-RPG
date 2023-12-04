using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TilemapVisualizer tilemapVisualizer;  // Referência ao TilemapVisualizer

    private void Start()
    {
        // Certifique-se de atribuir a referência do TilemapVisualizer no Inspector
        if (tilemapVisualizer == null)
        {
            Debug.LogError("TilemapVisualizer não atribuído ao PlayerController. Atribua-o no Inspector.");
        }
    }

    private void Update()
    {
        // Movimentação com as setas do teclado
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Obtém as posições válidas do chão do TilemapVisualizer
        HashSet<Vector2Int> floorPositions = tilemapVisualizer.GetFloorPositions();

        // Movimentação com as setas do teclado
        Vector2Int movement = new Vector2Int((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));

        // Calcula a nova posição desejada
        Vector2Int newPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + movement;

        // Verifica se a nova posição é uma posição válida do chão
        if (floorPositions.Contains(newPosition))
        {
            // Move o jogador para a nova posição
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
