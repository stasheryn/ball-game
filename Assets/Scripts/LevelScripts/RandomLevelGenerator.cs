using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LevelScripts
{
    public class RandomLevelGenerator : MonoBehaviour
    {
        public GameObject prefabCube;

        public GameObject prefabTargetStar;

        public int numberOfBlocksObstcles = 10;
        public int numberOfStars = 3;

        public bool isSpawn = false;

        // Points in space
        public List<Vector3> takenPosition;
        public List<Vector3> noSpawnHere;
        public List<Vector3> starSpawnHere;

        private void Start()
        {
            StartCoroutine(MyCor());
            //1 create instances cubes
            MethodUsingWhileCreatingBlocksObst();
            //2 create list where NOT ALLOWED to spawn Stars
            CreateListNoSpawnHere();
            //3 spawn Stars instances
            CreateListStars();
            
        }

        IEnumerator MyCor()
        {
            yield return null;
            Debug.Log("blalblalbla");
        }
        // new code 19 07 2024
        public void MethodUsingWhileCreatingBlocksObst()
        {
            // #CUBE
            while (takenPosition.Count < numberOfBlocksObstcles)
            {
                isSpawn = true;
                // rand
                int randPosOne = Random.Range(1, 11);
                int randHight = Random.Range(4, 7);
                // but vector is float ...
                float randPosTwo = Random.Range(10f, 10f);

                Vector3 randPos = new Vector3(randPosOne, randHight, randPosOne);

                // add new Vector3 to takenPosition
                for (int i = 0; i <= takenPosition.Count; i++)
                {
                    if (randPos == takenPosition[i])
                    {
                        isSpawn = false;
                        break;
                    }
                }

                if (isSpawn)
                {
                    takenPosition.Add(randPos);
                }
                // else just re-While
            }
            // add 'spawn' Instanciate method

            // #CUBE Instances
            for (int i = 0; i < takenPosition.Count; i++)
            {
                Instantiate(prefabCube, takenPosition[i], Quaternion.identity);
            }
            // add else Item spawn method
        }


        // create list of vectors where cant spawn Stars
        // мб переробити бо за таке можна получити по пальцях\руках
        public void CreateListNoSpawnHere()
        {
            //noSpawnHere.Count
            for (int i = 0; i < takenPosition.Count; i++)
            {
                // new vector3 or I modify takenPosition[i] ? i think new
                // можна змінити на більше блоків ніж 1, але треба ще цикли мб j<countBlocks

                // 1    0   0
                var vita = new Vector3(takenPosition[i].x + 1, takenPosition[i].y + 0, takenPosition[i].z + 0);
                noSpawnHere.Add(vita);
                // 1    1   0
                vita = new Vector3(takenPosition[i].x + 1, takenPosition[i].y + 1, takenPosition[i].z + 0);
                noSpawnHere.Add(vita);
                // 1    1   1
                vita = new Vector3(takenPosition[i].x + 1, takenPosition[i].y + 1, takenPosition[i].z + 1);
                noSpawnHere.Add(vita);
                // 0    1   0
                vita = new Vector3(takenPosition[i].x + 0, takenPosition[i].y + 1, takenPosition[i].z + 0);
                noSpawnHere.Add(vita);
                // 0    1   1
                vita = new Vector3(takenPosition[i].x + 0, takenPosition[i].y + 1, takenPosition[i].z + 1);
                noSpawnHere.Add(vita);
                // 0    0   1
                vita = new Vector3(takenPosition[i].x + 0, takenPosition[i].y + 0, takenPosition[i].z + 1);
                noSpawnHere.Add(vita);
            }
            // мб треба ще цикл для видалення дублікатів


            // добавляє позиції самих перешкод в список точок де не можна спавнити Stars
            for (int i = 0; i < takenPosition.Count; i++)
            {
                noSpawnHere.Add(takenPosition[i]);
            }
        }

        // create list of vectors where Stars spawns
        public void CreateListStars()
        {
            // create list of coordinates stars to hit
            while (starSpawnHere.Count < numberOfStars)
            {
                isSpawn = true;
                int randXZ = Random.Range(1, 11);
                int randY = Random.Range(1, 7);
                // but vector is float ...
                Vector3 randPos = new Vector3(randXZ, randY, randXZ);

                // add new Vector3 to takenPosition
                for (int i = 0; i <= takenPosition.Count; i++)
                {
                    if (randPos == takenPosition[i])
                    {
                        isSpawn = false;
                        break;
                    }
                }

                if (isSpawn)
                {
                    starSpawnHere.Add(randPos);
                }
                // else just re-While
            }

            // add 'spawn' Instanciate method
            for (int i = 0; i < starSpawnHere.Count; i++)
            {
                Instantiate(prefabTargetStar, starSpawnHere[i], Quaternion.identity);
            }
        }
    }
}