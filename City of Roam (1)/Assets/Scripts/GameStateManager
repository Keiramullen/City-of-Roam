using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameStateManager : Monobehaviour
{
	[SerializeField]
	private List<string> m_Levels = new List<string>();
	[SerializeField]
	private string m_TitleScene;
	[SerializeField]
	private int m_StartingHealth;

	[SerializeField]
	private AudioClip m_DieMusic;

	[SerializeField]
	private AudioSource m_AudioSource;

	private static int m_CurrentHealth;

	private static GameStateManager _instance;

	enum GAMESTATE
    {
		MENU,
		PLAYING,
		PAUSED,
		GAMEOVER
    }

	private static GAMESTATE m_State;

	public delegate void InitLevel(int health);
	public delegate IEnumerator LoseHealthDelegate(int health);
	public delegate IEnumerator GameOverDelegate();

	public static LoseHealthDelegate OnLoseHealth;
	public static GameOverDelegate OnGameOver;
	public static InitLevel OnLevelInit;



	private void Awake()
    {
		if(_instance == null)
        {
			_instance = this;
			m_CurrentHealth = _instance.m_StartingHealth;
			DontDestroyOnLoad(_instance);
        }
		else
        {
			Destroy(this);
        }
    }

	private void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
			GameStateManager.TogglePause();
        }
    }

	public static void NewGame()
	{
		m_State = GAMESTATE.PLAYING;
		m_CurrentHealth = _instance.m_StartingHealth;
		PlayerPrefs.SetInt("Checkpoint", 0);
		if(_instance.m_Levels.Count > 0)
		{
			SceneManager.LoadScene(_instance.m_Levels[0]);
			if(OnLevelInit != null)
			{
				OnLevelInit(m_CurrentHealth);
			}
		}
	}

	public static void Resume()
    {
		m_State = GAMESTATE.PLAYING;
		m_CurrentHealth = PlayerPrefs.GetInt("Health");
		if(_instance.m_Levels.Count > 0)
        {
			SceneManager.LoadScene(_instance.m_Levels[0]);
			if(OnLevelInit != null)
            {
				OnLevelInit(m_CurrentHealth);
            }
        }
    }

	public static void SaveGame()
    {
		PlayerPrefs.SetInt("Health", m_CurrentHealth);
    }

	public static void GameOver()
    {
		m_State = GAMESTATE.MENU;
		SceneManager.LoadScene(_instance.m_TitleScene);
    }

	public static void TogglePause()
    {
		if(m_State == GAMESTATE.PLAYING)
		{
			m_State = GAMESTATE.PAUSED;
			Time.timeScale = 0;
		}
		else if(m_State == GAMESTATE.PAUSED)
        {
			m_State = GAMESTATE.PLAYING;
			Time.timeScale = 1;
        }
    }

	public static void ResetScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		if(OnLevelInit != null)
        {
			OnLevelInit(m_CurrentHealth);
        }
    }

	public static void LoseHealth()
    {
		_instance.m_AudioSource.PlayOneShot(_instance.m_DieMusic);
		m_CurrentHealth -= 10;
		if (m_CurrentHealth <= 0)
        {
			//if (OnGameOver != null)
			{
				_instance.StartCoroutine(_instance.GameOverRoutine());
			}
        }
		else
        {
            //if (OnLoseHealth != null)
            {
				_instance.StartCoroutine(_instance.LoseHealthRoutine(m_CurrentHealth));

			}
		}
    }

	private IEnumerator LoseHealthRoutine(int health)
    {
		//yield return OnLoseHealth(health);
		ResetScene();
		yield return null;
    }

}
