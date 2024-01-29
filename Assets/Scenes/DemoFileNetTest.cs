using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DemoFileNetTest : MonoBehaviour
{
    async void Start()
    {
#if UNITY_EDITOR

        string demoFilePath = UnityEditor.EditorUtility.OpenFilePanel("Open demo file", null, "dem");
#else
        string demoFilePath = "test.dem";
#endif

        var parser = new DemoFile.DemoParser();

        using var file = File.OpenRead(demoFilePath);

        await parser.StartReadingAsync(file, default);

        Debug.Log("Opened demo file");

        var sw = Stopwatch.StartNew();

        while (await parser.MoveNextAsync(default))
        {

        }

        Debug.Log($"Finished, ticks {parser.CurrentDemoTick}, elapsed {sw.ElapsedMilliseconds} ms");
    }
}
