﻿using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarScrapper.Core
{
    public abstract class BaseSelector : ISelector
    {
        //private const string CONFIG_PATH = @"Config/Dealers.json";
        internal readonly string Make;
        internal readonly string Model;
        internal List<DealerInfo> DealersBase = new List<DealerInfo>();


        public BaseSelector(string make, string model)
        {
            Make = make;
            Model = model;

            DealersBase = Util.GetDealers().Where(a => a.Make == Make).ToList();
        }

        public abstract string GetBodyStyleIdentifier();
        public abstract string GetCarUrlIdentifier();
        public abstract List<Tuple<string, string>> GetCleanupMap();

        public abstract string GetDriveTypeIdentifier();

        public abstract string GetEngineIdentifier();

        public abstract string GetExtColorIdentifier();

        public abstract string[] GetInfoSeparator();

        public abstract string GetIntColorIdentifier();

        public abstract string GetMakeIdentifier();

        public abstract string GetModelCodeIdentifier();

        public abstract string GetModelIdentifier();

        public abstract string GetMsrpIdentifier();

        public abstract List<Tuple<string, Regex>> GetRegexMap();

        public abstract string[] GetRowSelectors();

        public abstract string GetStockNumberIdentifier();

        public abstract string GetTransmissionIdentifier();

        public abstract string GetUrlDetails();
        
        public abstract string GetVinIdentifier();

        public abstract CarInfo ParseHtmlIntoCarInfo(HtmlNode node);
        public abstract List<DealerInfo> GetDealers();
    }
}