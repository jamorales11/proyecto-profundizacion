using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sixe : MonoBehaviour
{   
    public GameObject coral;
    public float lenght;
    public float tiempo;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        int rndTriStart = Random.Range(0,(mesh.vertices.Length-2)); //pick a triangle
        Vector2 rndNorm = new Vector2((Random.value), (Random.value)); //find random point in normalized square
        if (rndNorm.x + rndNorm.y >= 1f) {
        rndNorm = new Vector2((1f - rndNorm.x), (1f - rndNorm.y)); //cut the square diagonally in half by reflecting points not in the normalized triangle
        }
        Vector3 prueba1 = (mesh.vertices[rndTriStart]+(mesh.vertices[rndTriStart+1])+(mesh.vertices[rndTriStart+2]))/3;
        Vector3 position = prueba1;
        Vector3 normal = mesh.normals[rndTriStart] + (rndNorm.x * mesh.normals[rndTriStart+1]) + (rndNorm.y * mesh.normals[rndTriStart+2]);
        Instantiate(coral,transform);
        //Instantiate(coral, position, Quaternion.FromToRotation(Vector3.up, normal));
        coral.transform.position = prueba1;
        coral.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        coral.transform.localScale =  new Vector3(0.08f,0.08f, 0.08f);}
        Material newMatg = Resources.Load("algas", typeof(Material)) as Material;
        coral.GetComponent<Renderer>().material = newMatg;       
        lenght=0.08f;
    }


    public void Update() {
        float t2= Time.time-tiempo;
        Debug.Log(t2);
        Debug.Log(lenght);
        if(t2>5){
            lenght= lenght*1.1f;
            algas();
            tiempo= Time.time;
        }    
    } 


     void algas(){

        for (int i = 0; i < 10; i++)
        {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
        int rndTriStart = Random.Range(0,(mesh.vertices.Length-2)); //pick a triangle
        Vector2 rndNorm = new Vector2((Random.value), (Random.value)); //find random point in normalized square
        if (rndNorm.x + rndNorm.y >= 1f) {
        rndNorm = new Vector2((1f - rndNorm.x), (1f - rndNorm.y)); //cut the square diagonally in half by reflecting points not in the normalized triangle
        }
        Vector3 prueba1 = (mesh.vertices[rndTriStart]+(mesh.vertices[rndTriStart+1])+(mesh.vertices[rndTriStart+2]))/3;
        Vector3 position = prueba1;
        Vector3 normal = mesh.normals[rndTriStart] + (rndNorm.x * mesh.normals[rndTriStart+1]) + (rndNorm.y * mesh.normals[rndTriStart+2]);
        Instantiate(coral,transform);
        //Instantiate(coral, position, Quaternion.FromToRotation(Vector3.up, normal));
        coral.transform.position = prueba1;
        coral.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        coral.transform.localScale =  new Vector3(0.08f,lenght, 0.08f);}
        Material newMatg = Resources.Load("algas", typeof(Material)) as Material;
        coral.GetComponent<Renderer>().material = newMatg;
    }
    
}
