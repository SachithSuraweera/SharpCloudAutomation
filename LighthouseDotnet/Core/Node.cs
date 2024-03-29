﻿using System;
using System.Threading.Tasks;

namespace LighthouseDotnet.Core
{
    internal sealed class Node : TerminalBase
    {
        protected override string FileName => "node";
        public async Task<string> Run(string jsFilePath)
        {
            return await this.Execute($"--harmony --no-warnings --trace-warnings --unhandled-rejections=strict {jsFilePath}").ConfigureAwait(false);
        }
        protected override void OnError(string message)
        {
            throw new Exception(message);
        }
    }
}
