using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Lesson_6_1
{
    [Serializable]
    public class KillProcessException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public string ProcessName { get; }
        public int ExitCode { get; }

        public KillProcessException(string processName, int exitCode) : base(
            $"Didn't kill process: {processName}. ExitCode: {exitCode}")
        {
            ProcessName = processName;
            ExitCode = exitCode;
        }

        public KillProcessException(string message, string processName, int exitCode) : base(message)
        {
            ProcessName = processName;
            ExitCode = exitCode;
        }

        public KillProcessException(string message, string processName, int exitCode, Exception inner) : base(message,
            inner)
        {
            ProcessName = processName;
            ExitCode = exitCode;
        }

        protected KillProcessException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    class KillProcessNotFountException : KillProcessException
    {
        public KillProcessNotFountException(string processName, int exitCode) : base(
            $"Process with name: {processName} , Not found",
            processName, exitCode)
        {
        }

        public KillProcessNotFountException(string message, string processName, int exitCode) : base(message,
            processName, exitCode)
        {
        }

        public KillProcessNotFountException(string message, string processName, int exitCode, Exception inner) : base(
            message,
            processName, exitCode, inner)
        {
        }
    }

    class Program
    {
        static void ShowAllProcesses()
        {
            var process = new Process();
            process.StartInfo.FileName = "ps";
            process.StartInfo.Arguments = "ux";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            var output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine(output);
        }

        static bool KillProcessByPid(int pid)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "kill",
                    Arguments = $"-9 {pid}",
                    UseShellExecute = false,
                    RedirectStandardError = true
                }
            };

            process.Start();
            var errorOutput = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0 && errorOutput.Contains("No such process"))
            {
                throw new KillProcessNotFountException(pid.ToString(), process.ExitCode);
            }

            if (process.ExitCode != 0)
            {
                throw new KillProcessException(pid.ToString(), process.ExitCode);
            }

            return true;
        }

        private static bool KillProcessByName(string processName)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "pkill",
                    Arguments = $"{processName}",
                    UseShellExecute = false,
                    RedirectStandardError = true
                }
            };

            process.Start();
            var errorOutput = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0 && errorOutput.Contains("No such process"))
            {
                throw new KillProcessNotFountException(processName, process.ExitCode);
            }

            if (process.ExitCode != 0)
            {
                throw new KillProcessException(processName, process.ExitCode);
            }

            return true;
        }

        static bool KillProcess(string nameProcess)
        {
            var isPidArgument = int.TryParse(nameProcess, out int processPid);

            if (isPidArgument)
            {
                return KillProcessByPid(processPid);
            }

            return KillProcessByName(nameProcess);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Все процессы в системе:");
            ShowAllProcesses();

            var wasKilledProcess = false;

            do
            {
                try
                {
                    Console.Write("Введите название или ID процессе для завершения: ");
                    var nameProcess = Console.ReadLine();

                    wasKilledProcess = KillProcess(nameProcess);
                }
                catch (KillProcessNotFountException error)
                {
                    Console.WriteLine($"Процесс с именем {error.ProcessName} не найден");
                }
                catch (KillProcessException error)
                {
                    Console.WriteLine(
                        $"Проблемы при закрытии процесса. ProcessName: {error.ProcessName}. ExitCode: {error.ExitCode}");
                    wasKilledProcess = true;
                }
            } while (!wasKilledProcess);
        }
    }
}