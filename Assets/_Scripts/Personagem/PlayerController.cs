using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TilemapVisualizer tilemapVisualizer;  // Refer�ncia ao TilemapVisualizer

    private void Start()
    {
        // Certifique-se de atribuir a refer�ncia do TilemapVisualizer no Inspector
        if (tilemapVisualizer == null)
        {
            Debug.LogError("TilemapVisualizer n�o atribu�do ao PlayerController. Atribua-o no Inspector.");
        }
    }

    private void Update()
    {
        // Movimenta��o com as setas do teclado
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Obt�m as posi��es v�lidas do ch�o do TilemapVisualizer
        HashSet<Vector2Int> floorPositions = tilemapVisualizer.GetFloorPositions();

        // Movimenta��o com as setas do teclado
        Vector2Int movement = new Vector2Int((int)Input.GetAxisRaw("Horizontal"), (int)Input.GetAxisRaw("Vertical"));

        // Calcula a nova posi��o desejada
        Vector2Int newPosition = new Vector2Int(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y)) + movement;

        // Verifica se a nova posi��o � uma posi��o v�lida do ch�o
        if (floorPositions.Contains(newPosition))
        {
            // Move o jogador para a nova posi��o
            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }
}
