using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CSVParse : MonoBehaviour
{

    public TextAsset csvFile;
    public InputField rollNoInputField;// Reference of rollno input field
    public InputField nameInputField; // Reference of name input filed
    public Text contentArea; // Reference of contentArea where records are displayed

    private char lineSeperater = '\n'; // It defines line seperate character
    private char fieldSeperator = ',';

    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> pts = new List<Vector3>();
        TextAsset csvData = Resources.Load<TextAsset>("pointsmask");
        string[] Ptsdata = csvData.text.Split(new char[] { '\n' });
        Debug.Log(Ptsdata.Length);

        for (int i = 1; i < Ptsdata.Length - 1; i++)
        {
            string[] row = Ptsdata[i].Split(new char[] { ',' });
            Debug.Log(i);
            pts.Add(new Vector3(float.Parse(row[1]), float.Parse(row[2]), float.Parse(row[3])));
        }


        List<Vector2> uvs = new List<Vector2>();
        TextAsset csvData2 = Resources.Load<TextAsset>("uvsmask");
        string[] Uvsdata = csvData2.text.Split(new char[] { '\n' });
        Debug.Log(Uvsdata.Length);

        for (int i = 1; i < Uvsdata.Length - 1; i++)
        {
            string[] row = Uvsdata[i].Split(new char[] { ',' });
            uvs.Add(new Vector3(int.Parse(row[1]), int.Parse(row[2])));
        }


        List<int> triangles  = new List<int>();
        TextAsset csvData3 = Resources.Load<TextAsset>("trianglesmask");
        string[] Tridata = csvData3.text.Split(new char[] { '\n' });

        for (int i = 1; i < Tridata.Length - 1; i++)
        {
            string[] row = Tridata[i].Split(new char[] { ',' });
            triangles.Add(int.Parse(row[1]));
            triangles.Add(int.Parse(row[2]));
            triangles.Add(int.Parse(row[3]));
        }

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = pts.ToArray();
        mesh.uv = uvs.ToArray();
        mesh.triangles = triangles.ToArray();


    }

    // Update is called once per frame
    void Update()
    {


    }
}
