using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSun : MonoBehaviour

{
    public GameObject earth;
    public GameObject sun;
    int alpha = 0;

    
    float[,] ScaleMatrix(float x, float y, float z)
    {
        float[,] scaleMatrix = new float[4, 4] { { x,0,0,0 }, { 0,y,0,0 }, { 0,0,z,0 }, { 0,0,0,1} };
        return scaleMatrix;
    }

    float[,] TranslationMatrix(float x, float y, float z)
    {
        float[,] translationMatrix = new float[4, 4] { { 1,0,0,x }, { 0, 1, 0, y }, { 0, 0, 1, z }, { 0, 0, 0, 1 } };
        return translationMatrix;
    }

    float[,] RotationMatrix(float alpha)
    {
        float[,] rotationMatrix = new float[4, 4] { { 1,0,0,0 }, { 0,Mathf.Cos(alpha),-1*Mathf.Sin(alpha),0}, { 0, Mathf.Sin(alpha), Mathf.Cos(alpha), 0 }, { 0, 0, 0, 1 } };
        return rotationMatrix;
    }

    public float[,] MultiplyMatrix(float[,] A, float[,] B)
    {
        int rA = A.GetLength(0);
        int cA = A.GetLength(1);
        int rB = B.GetLength(0);
        int cB = B.GetLength(1);
        Debug.Log("zxcw"+rA+cA+rB+cB);
        float temp = 0;
        float[,] kHasil = new float[rA, cB];
 
    
            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    temp = 0;
                    for (int k = 0; k < cA; k++)
                    {
                        temp += A[i, k] * B[k, j];
                    }
                    kHasil[i, j] = temp;
                }
            }
            return kHasil;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alpha += 5;

        float earthX = earth.transform.position.x;
        float earthY = earth.transform.position.y;
        float earthZ = earth.transform.position.z;


        float[,] earthMatrix = new float[4, 1] { { earthX }, { earthY }, { earthZ }, { 1 } };

        float sunX = sun.transform.position.x;
        float sunY = sun.transform.position.y;
        float sunZ = sun.transform.position.z;

        var earthScaleMatrix = ScaleMatrix(earthX, earthY, earthZ);
        var earthRotationMatrix = RotationMatrix(alpha);
        var earthTranslationMatrix = TranslationMatrix(earthX, earthY, earthZ);

        var sunScaleMatrix = ScaleMatrix(sunX, sunY, sunZ);
        var sunRotationMatrix = RotationMatrix(alpha);
        var sunTranslationMatrix = TranslationMatrix(sunX, sunY, sunZ);

        //float[,] matrixVar1 = MultiplyMatrix(sunScaleMatrix, sunRotationMatrix);
        //float[,] matrixVar2 = MultiplyMatrix(matrixVar1, sunTranslationMatrix);
        //float[,] matrixVar3 = MultiplyMatrix(matrixVar2, earthScaleMatrix);
        //float[,] matrixVar4 = MultiplyMatrix(matrixVar3, earthRotationMatrix);
        //float[,] matrixVar5 = MultiplyMatrix(matrixVar4, earthTranslationMatrix);
        //float[,] finalMatrix = MultiplyMatrix(matrixVar5, m);

        float[,] matrixVar1 = MultiplyMatrix(earthMatrix, earthTranslationMatrix);
        float[,] matrixVar2 = MultiplyMatrix(matrixVar1, earthRotationMatrix);
        float[,] matrixVar3 = MultiplyMatrix(matrixVar2, earthScaleMatrix);
        float[,] matrixVar4 = MultiplyMatrix(matrixVar3, sunTranslationMatrix);
        float[,] matrixVar5 = MultiplyMatrix(matrixVar4, sunRotationMatrix);
        float[,] finalMatrix = MultiplyMatrix(matrixVar5, sunScaleMatrix);



        this.earth.transform.position = new Vector3(finalMatrix[0, 0], finalMatrix[1, 0], finalMatrix[2, 0]); 

    }
}
