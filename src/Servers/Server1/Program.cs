﻿using System;
using Autofac;
using Jimu;
using Jimu.Server;

namespace Server1
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            var hostBuilder = new ServiceHostServerBuilder(containerBuilder)
                    .LoadServices(new[] { "IServices", "Services" })
                    .UseLog4netLogger()
                    .UseHttpForTransfer("127.0.0.1", 8001)// http server ip and port,becareful the firewall blocker
                    .UseInServerForDiscovery()// in memory discovery mode
                ;
            using (var host = hostBuilder.Build())
            {
                host.Run();
            }
        }
    }
}
