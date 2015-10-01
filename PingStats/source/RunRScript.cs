using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingStats
{
    class RunRScript
    {

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

    }
}
