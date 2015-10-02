using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet.Devices;
using RDotNet;
using RDotNet.NativeLibrary;

namespace PingStats
{
    class RunRScript
    {

        // D-D-D-D-Deprecated
        public static string RunFromCmd(string ScriptPath, string ScriptExecPath)
        {
            string file = ScriptPath;
            string result = string.Empty;

            try
            {
                var info = new ProcessStartInfo();
                info.FileName = ScriptExecPath;
                info.WorkingDirectory = Path.GetDirectoryName(ScriptExecPath);
                info.Arguments = ScriptPath + " ";

                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                info.CreateNoWindow = true;

                using (var proc = new Process())
                {
                    proc.StartInfo = info;
                    proc.Start();
                    result = proc.StandardOutput.ReadToEnd();
                }

                return result;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public static void RunScript()
        {
            string RPath = @"C:\Program Files\R\R-3.2.2\bin\x64";
            REngine.SetEnvironmentVariables();
            REngine Engine = REngine.GetInstance();

        
            Engine.Evaluate("source('GraphJson.R')");

     
        }
    }
}
