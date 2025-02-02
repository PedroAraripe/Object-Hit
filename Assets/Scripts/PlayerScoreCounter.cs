using System.Threading;
using UnityEngine;

public class PlayerScoreCounter : MonoBehaviour
{
    int count = 0;

    public void AddCount() {
        count++;
    }

    public int SeeCount() {
        return count;
    }
}
