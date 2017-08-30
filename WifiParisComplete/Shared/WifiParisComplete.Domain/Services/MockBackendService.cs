﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WifiParisComplete.Data;
using WifiParisComplete.Domain.API;
using WifiParisComplete.Domain.Attributes;
using WifiParisComplete.Domain.Interfaces;

namespace WifiParisComplete.Domain
{
	[RegisterInterfaceAsDynamic]
	public class MockBackendService : IBackendService
	{
		private IMapper<Record, WifiHotspot> WifiHotspotMapper { get; }
		private List<WifiHotspot> Data { get; set; }

		public MockBackendService(IMapper<Record, WifiHotspot> wifiHotspotMapper)
		{
			WifiHotspotMapper = wifiHotspotMapper;
			Data = new List<WifiHotspot>();
		}

		private int _lastId;

		public async Task<IEnumerable<WifiHotspot>> GetMoreWifiHotspots(string postalCodeFilter)
		{
			await Task.Delay(1000).ConfigureAwait(false);
			await LoadData();
			var list = Data.Where(x => x.Address.PostalCode == postalCodeFilter).Skip(_lastId).Take(10);

			_lastId += list.Count();
			return list;
		}

		public async Task<IEnumerable<WifiHotspot>> GetWifiHotspots(string postalCodeFilter)
		{
			await Task.Delay(1000).ConfigureAwait(false);
			await LoadData();
            var list = Data.Where(x => string.IsNullOrEmpty(postalCodeFilter) || x.Address.PostalCode == postalCodeFilter).Take(10);
			_lastId = list.Count();
			return list;
		}

		private async Task LoadData()
		{
			if (Data.Any()) return;
			var assembly = typeof(MockBackendService).GetTypeInfo().Assembly;
			var stream = assembly.GetManifestResourceStream($"WifiParisComplete.Domain.Content.Data.json");

			if (stream == null)
			{
				return;
			}
			string data;
			using (var reader = new StreamReader(stream))
			{
				data = await reader.ReadToEndAsync().ConfigureAwait(false);
			}
			var rootObject = JsonConvert.DeserializeObject<RootObject>(data);
			Data = rootObject.Records.Select(x => WifiHotspotMapper.Map(x)).ToList();
		}

		public Task AddWifiHotspot(WifiHotspot wifiHotspot)
		{
			throw new NotImplementedException();
		}
	}
}
