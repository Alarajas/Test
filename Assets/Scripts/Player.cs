using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;

    #region Singleton
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    [SerializeField]
    public CharacterCombat characterCombat;
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
