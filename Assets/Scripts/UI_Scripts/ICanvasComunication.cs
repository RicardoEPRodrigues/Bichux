using UnityEngine;
using System.Collections;

public interface ICanvasComunication {


    void SetGameManager(GameManager gameObject);

    void UpdateScore(int score);
    void UpdateHighScore(int score);
    


}

