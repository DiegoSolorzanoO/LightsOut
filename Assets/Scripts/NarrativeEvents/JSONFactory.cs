using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

namespace JSONFactory {
    class JSONAssembly {
        private static Dictionary<int, string> _resourceList = new Dictionary<int, string> {
            { 1, "/Resources/Dialogues/Event1.json" }, {0, "/Resources/Dialogues/Event0.json" },
            { 2, "/Resources/Dialogues/Event2.json" }, { 3, "/Resources/Dialogues/Event3.json" }
        };

        public static NarrativeEvent RunJSONFactoryForScene(int sceneNumber) {
            string resourcePath = PathForScene(sceneNumber);
            if (IsValidJSON(resourcePath)) {
                string jsonString = File.ReadAllText(Application.dataPath + resourcePath);
                Debug.Log(jsonString);
                NarrativeEvent narrativeEvent = JsonMapper.ToObject<NarrativeEvent>(jsonString);
                return narrativeEvent;
            } else {
                throw new Exception("The JSON is not valid, please check the file.");
            }
        }

        private static string PathForScene(int sceneNumber) {
            if (_resourceList.TryGetValue(sceneNumber, out string resourcePathResult)) {
                return _resourceList[sceneNumber];
            } else {
                throw new Exception("The scene number you provided is not in the resource list.");
            }
        }

        private static bool IsValidJSON(string path) {
            return (Path.GetExtension(path).Equals(".json") ? true : false);
        }
    }
}
