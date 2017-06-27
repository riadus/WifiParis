using System;
using Android.OS;

namespace ServiceInutile
{
    public class BinderUtile : Binder
    {
        MonService _service;

		public BinderUtile(MonService service)
		{
			this._service = service;
		}

		public MonService GetDemoService()
		{
			return _service;
		}
    }
}
