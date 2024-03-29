﻿using System.Threading.Tasks;

namespace LighthouseDotnet.Core
{
    internal sealed class WhereCmd : TerminalBase
    {
        protected override string FileName => "where.exe";
        internal async Task<string> GetNodePath()
        {
            return await this.Execute("node");
        }
    }
}
