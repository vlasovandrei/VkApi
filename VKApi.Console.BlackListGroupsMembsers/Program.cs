﻿using System;
using VKApi.BL;
using VKApi.BL.Interfaces;
using VKApi.Console.BlackListGroupsMembsers;

namespace VKApi.Console.Blacklister
{
    internal static class Program
    {
        private static void ConfigureServices()
        {
            ServiceInjector.Register<IGroupSerice, GroupService>();
            ServiceInjector.Register<IConfigurationProvider, ConfigurationProvider>();
            ServiceInjector.Register<IVkApiFactory, VkApiFactory>();
            ServiceInjector.Register<IUserService, UserService>();
        }

        private static void Main(string[] args)
        {
            ConfigureServices();

            var configurationProvider = ServiceInjector.Retrieve<IConfigurationProvider>();
            var groupService = ServiceInjector.Retrieve<IGroupSerice>();

            var phrase = configurationProvider.GetConfig("SearchPhrase");
            var waitStr = configurationProvider.GetConfig("Wait");
            var city = configurationProvider.GetConfig("City");
            var olderFirst = Convert.ToBoolean(configurationProvider.GetConfig("OlderFirst"));

            var wait = Convert.ToDouble(waitStr);
            System.Console.Clear();
            groupService.BlackListGroupMembsersByGroupName(phrase, wait, city, olderFirst);
        }
    }
}
