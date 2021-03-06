using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestScript
    {

        public Ball ball;
        public Paddle paddle;
        bool etat = false;
        GameSession gameSession;

        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene(1);
        }

        [UnityTest]
        public IEnumerator TestScript0Lives()
        {
            LoseCollider.lives = 3;
            while (LoseCollider.lives != 0)
            {
                Paddle.paddle.theBall.LaunchWithFunction();
                yield return new WaitForSeconds(4.0f);
            }
            Assert.AreEqual(0, LoseCollider.lives);
        }

    }