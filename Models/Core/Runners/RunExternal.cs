﻿namespace Models.Core.Runners
{
    using APSIM.Shared.Utilities;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    /// <summary>
    /// An exception class for external exceptions.
    /// </summary>
    class RunExternalException : Exception
    {
        public RunExternalException(string msg) 
            : base(msg)
        { }
    }

    /// <summary>
    /// This runnable class runs an external process.
    /// </summary>
    class RunExternal : IRunnable, IComputationalyTimeConsuming
    {
        /// <summary>Gets or sets the executable file.</summary>
        private string executable;

        /// <summary>Gets or sets the working directory.</summary>
        private string workingDirectory;

        /// <summary>The arguments.</summary>
        private string arguments;

        /// <summary>Should the child process' output be redirected?</summary>
        private bool verbose;

        /// <summary>Initializes a new instance of the <see cref="RunExternal"/> class.</summary>
        /// <param name="executable">Name of the executable file.</param>
        /// <param name="arguments">The arguments.</param>
        /// <param name="workingDirectory">The working directory.</param>
        /// <param name="verbose">Should the child process' output be redirected?</param>
        public RunExternal(string executable, string arguments, string workingDirectory, bool verbose)
        {
            this.executable = executable;
            this.workingDirectory = workingDirectory;
            this.arguments = arguments;
            this.verbose = verbose;
        }

        /// <summary>Called to start the job.</summary>
        /// <param name="cancelToken">The thread this job is running on.</param>
        public void Run(CancellationTokenSource cancelToken)
        {
            // Start the external process to run APSIM and wait for it to finish.
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.FileName = executable;
            if (!File.Exists(p.StartInfo.FileName))
                throw new Exception("Cannot find executable: " + p.StartInfo.FileName);
            p.StartInfo.Arguments = arguments;
            p.StartInfo.WorkingDirectory = workingDirectory;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            if (verbose)
            {
                p.OutputDataReceived += OnOutputDataReceived;
                p.ErrorDataReceived += OnErrorDataReceived;
            }

            p.Start();
            if (verbose)
            {
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
            }
            p.WaitForExit();
            if (verbose)
            {
                p.CancelOutputRead();
                p.CancelErrorRead();
            }
            string stdout = p.StandardOutput.ReadToEnd();
            if (p.ExitCode > 0)
            {
                string errorMessage = "Error in file: " + arguments + Environment.NewLine;
                errorMessage += stdout;
                throw new RunExternalException(errorMessage);
            }
        }

        /// <summary>
        /// Invoked whenever the child process writes to standard output or standard error.
        /// Writes the data to standard output.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="args">Event arguments.</param>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs args)
        {
            Console.WriteLine(args.Data);
        }

        /// <summary>
        /// Invoked whenever the child process writes to standard output or standard error.
        /// Writes the data to standard error.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="args">Event arguments.</param>
        private void OnErrorDataReceived(object sender, DataReceivedEventArgs args)
        {
            Console.Error.WriteLine(args.Data);
        }
    }
}
