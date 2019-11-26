namespace Manusquare.API.Commands.Semantic.Matching
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Boxed.AspNetCore;
    using CliWrap;
    using Database;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Models;
    using Utilities;

    public interface IGetSemanticScoreCommand : IAsyncCommand<SemanticInput>
    {
    }

    /*
     * Working RFQ:
     * {\"nda\":\"no\",\"projectName\":\"Project1\",\"projectDescription\":\"ProjectDescription\",\"selectionType\":\"Manual\",\"supplierMaxDistance\":\"100\",\"servicePolicy\":\"true\",\"projectId\":\"project-1254161155\",\"id\":\"project-1254161155\",\"projectType\":\"Capacity Sharing\",\"projectAttributes\":[{\"attributeId\":\"E\",\"processName\":\"Drilling\",\"attributeKey\":\"material\",\"attributeValue\":\"CarbonSteel\"},{\"attributeId\":\"E\",\"processName\":\"HoleMaking\",\"attributeKey\":\"material\",\"attributeValue\":\"Steel\"}],\"supplierAttributes\":[{\"id\":\"supplier-attribute-430396576\",\"attributeKey\":\"certification\",\"attributeValue\":\"ISO9003\"},{\"id\":\"supplier-attribute-430396577\",\"attributeKey\":\"certification\",\"attributeValue\":\"ISO9004\"},{\"id\":\"supplier-attribute-430396577\",\"attributeKey\":\"certification\",\"attributeValue\":\"AS9000\"}]}
     */

    public class GetSemanticScoreCommand : IGetSemanticScoreCommand
    {
        private readonly MatchmakingContext _context;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;

        public GetSemanticScoreCommand(IActionContextAccessor actionContextAccessor, MatchmakingContext context, IHostingEnvironment hostingEnvironment)
        {
            _actionContextAccessor = actionContextAccessor;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

#pragma warning disable 1998
        public async Task<IActionResult> ExecuteAsync(SemanticInput parameter, CancellationToken cancellationToken)
        {
            string filepath = Path.Combine(this._hostingEnvironment.WebRootPath, "Matchmaking.jar");
            string args = "/C java -jar " + filepath;
            string standaloneArguments = "java -jar Matchmaking.jar" + " " + HttpUtility.JavaScriptStringEncode(parameter.ToJson());
            string complete_args = args + " " + HttpUtility.JavaScriptStringEncode(parameter.ToJson());

            System.Diagnostics.Process clientProcess = new Process
            {
                StartInfo = {FileName = "java",
                    Arguments = @"-jar " + filepath + " " + HttpUtility.JavaScriptStringEncode(parameter.ToJson()),
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            clientProcess.Start();
//            clientProcess.WaitForExit();
            var result = clientProcess.StandardOutput.ReadToEnd();
            var isError = clientProcess.StandardError.ReadToEnd();
            int code = clientProcess.ExitCode;
            Console.WriteLine(code);
            Console.WriteLine();


          //  var result = await Cli.Wrap("cmd.exe").SetArguments(complete_args).SetCancellationToken(cancellationToken)
           //     .ExecuteAsync();

       /*     var result = await Cli.Wrap("cmd.exe").SetStandardInput(complete_args)
                .SetStandardOutputCallback(l => Console.WriteLine($"StdOut> {l}")) // triggered on every line in stdout
                .SetStandardErrorCallback(l => Console.WriteLine($"StdErr> {l}")) // triggered on every line in stderr
                .SetCancellationToken(cancellationToken).ExecuteAsync();
            */

            /*var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = complete_args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            var output = new List<string>();

            while (process.StandardOutput.Peek() > -1)
            {
                output.Add(process.StandardOutput.ReadLine());
            }

            while (process.StandardError.Peek() > -1)
            {
                output.Add(process.StandardError.ReadLine());
            }*/
        //    process.WaitForExit();
            //string result = process.StandardOutput.ReadToEnd();
            //process.WaitForExit();

            //  var result = await Cli.Wrap("cli.exe").SetArguments(args).SetCancellationToken(cancellationToken)
            //      .ExecuteAsync();

     /*       var process = Opener.Open(args, processStartInfo: new ProcessStartInfo()
            {
                WorkingDirectory = this._hostingEnvironment.WebRootPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            });
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();*/
            //Console.WriteLine("ok");
            bool isErr = result.Split('\n').Length > 5;

            return isErr ? new OkObjectResult(isError) : new OkObjectResult(result);
        }
    }
}