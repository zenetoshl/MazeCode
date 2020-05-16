using System.Collections;
using System.Collections.Generic;
using RoslynCSharp;
using RoslynCSharp.Compiler;

using UnityEngine.Networking;
using UnityEngine;

public class LoadAssembly : MonoBehaviour {

    public GameObject begin;
    // Start is called before the first frame update
    IEnumerator Start () {
        ScriptDomain domain = ScriptDomain.CreateDomain ("MyDomain", true);
        string source = ConnectionManager.ToCode (begin.GetComponent<RectTransform> ()) + "}}}";
        string reference = "UnityEngine.dll";
        using (UnityWebRequest uwr = UnityWebRequest.Get (Application.streamingAssetsPath + "/bin/Data/Managed" + "/" + reference)) {
            yield return uwr.SendWebRequest ();
            if (uwr.isNetworkError || uwr.isHttpError) {
                Debug.Log ("www error:" + uwr.error + " " + ("jar:file://" + Application.dataPath + "!/assets/" + reference));
            } else {
                Debug.Log ("1");
                domain.RoslynCompilerService.ReferenceAssemblies.Add(AssemblyReference.FromImage (uwr.downloadHandler.data));
                Debug.Log (uwr.downloadHandler.data);
                ScriptType type = domain.CompileAndLoadMainSource (source);
            }
        }
        
    }
}