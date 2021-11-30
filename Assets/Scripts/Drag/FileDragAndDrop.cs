using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using B83.Win32;
using System.Text;
using System.Windows;


public class FileDragAndDrop : MonoBehaviour
{
    List<string> log = new List<string>();
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
            aFiles.Aggregate((a, b) => a + "\n\t" + b);
        Debug.Log(str);
        log.Add(str);

        StringBuilder sb= new StringBuilder();

        sb.Append("拖拽文件进来了\n\n");
        foreach (var path in aFiles)
        {
            sb.Append(path);
            sb.Append("了\n\n");
        }

        // MessageBox.Show(sb.ToString());
    }

    private void OnGUI()
    {
        if (GUILayout.Button("clear log"))
            log.Clear();
        foreach (var s in log)
            GUILayout.Label(s);
    }
}
