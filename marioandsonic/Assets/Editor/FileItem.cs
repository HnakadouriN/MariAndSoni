using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System;
using System.Reflection;

namespace UnityEditorExtension
{
    public class FileItem
    {
        [MenuItem("File/Restart &r")]
        static void RestartUnityEditor()
        {
            string command = getCommandToRestartEditor();
            string args = getRestartEditorArgs();
            Process.Start(command, args);
            EditorApplication.Exit(0);
        }

        [MenuItem("File/Clear Console &c")]
        static void ClearConsole()
        {
            MethodInfo clearMethod = getClearConsoleMethodInfo();
            clearMethod.Invoke(null, null);
        }

        [MenuItem("File/Toggle Inspector Lock &i")]
        static void ToggleConsole()
        {
            ActiveEditorTracker tracker = ActiveEditorTracker.sharedTracker;
            tracker.isLocked = !tracker.isLocked;
            tracker.ForceRebuild();
        }

        static MethodInfo getClearConsoleMethodInfo()
        {
            Type logEntries = Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
            MethodInfo clearMethodInfo = logEntries.GetMethod("Clear", BindingFlags.Static | BindingFlags.Public);
            return clearMethodInfo;
        }

        static string getCommandToRestartEditor()
        {
            return "/bin/bash";
        }

        static string getRestartEditorArgs()
        {
            string shPath = Application.dataPath + "/Editor/restart_unity_editor.sh";
            string unityEditorPath = EditorApplication.applicationPath;
            string args = "-projectPath " + Application.dataPath.Replace("/Assets", "");
            string command = unityEditorPath + " " + args;
            return $"-c \"{shPath} {command}\"";
        }
    }
}