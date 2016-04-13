using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

using Microsoft.Owin.Hosting;

namespace OwinServer
{
    public class Program
    {

        private readonly string _selfHostingListenPort;

        public Program()
        {
            //Load the settings from the config file.
            //_selfHostingListenPort = ConfigurationManager.AppSettings[Enums.AppSettingKeys.SelfHostingListenPort.ToString()];
            _selfHostingListenPort = "9000";
        }

        public void ConfigureOwinMiddleware()
        {
            //If no self hosting listen port has been configured then just return.
            if (string.IsNullOrEmpty(_selfHostingListenPort)) return;

            try
            {
                var selfHostingListenPort = Convert.ToInt32(_selfHostingListenPort);

                //Enable the static files configuration.
                WebApp.Start<Infrastructure.OwinApiConfig>($"http://localhost:{selfHostingListenPort}/");
            }
            catch (Exception ex)
            {
                //Exception.

                //todo: report this somewhere.
            }

        }


    }
}
