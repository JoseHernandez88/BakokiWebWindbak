﻿using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BakokiWeb.Shared
{
	public class Cuenta
	{
		[Key]
		public string AccountNumber { get; set; }
			= "";
		public string AccountName { get; set; }
			= "";
		public bool IsOpen { get; set; }
			= true;
		public virtual Cliente Cliente { get; set; }
			= new Cliente();
		public virtual ICollection<Transaccion> Transacciones { get; set; }
			= new List<Transaccion>();

		public Cuenta() { }
        public Cuenta(CuentaViewModel cue)
		{
			AccountNumber = cue.AccountNumber;
			AccountName = cue.AccountName;
			IsOpen = cue.IsOpen;
			foreach(var tran in cue.Transacciones)
			{
				Transacciones.Add(new Transaccion(tran));
			}
		}
        public double Balance()
		{
			Int64 sum = 0;
			if (Transacciones.Any())
			{
				foreach (var t in Transacciones)
				{
					sum = t.Sum(sum);
				}
			}

			return sum / 100.0;
		}
		
		
	}
}
		