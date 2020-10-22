﻿using UnityEngine;

namespace DiepMono.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        public bool DontDestroy;

        #region Fields

        /// <summary>
        /// The instance.
        /// </summary>
        private static T instance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use this for initialization.
        /// </summary>
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;

            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            if (DontDestroy)
                DontDestroyOnLoad(gameObject);
        }

        #endregion

    } 
}