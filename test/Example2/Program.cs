using CloudService.Core;
using CloudService.Resources;
using CloudService.Servers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example2 {
	class Program {
		static void Main(string[] args) {
			List<VirtualMachine> virtualMachines = new List<VirtualMachine>();
			//setup server -> nilai maximum untuk capasitas sebuah server
			Console.WriteLine("---------------------------------------------------------------------------------------");
			Console.WriteLine("Setting kapasitas server");
			Console.Write("Masukkan jumlah kapasitas maksimum CPU server : ");
			int maxCpu = Convert.ToInt32(Console.ReadLine());
			Console.Write("Masukkan jumlah kapasitas maksimum Disk server : ");
			int maxDisk = Convert.ToInt32(Console.ReadLine()); ;
			Console.Write("Masukkan jumlah kapasitas maksimum Memory server : ");
			int maxMemory = Convert.ToInt32(Console.ReadLine()); 
			Console.Write("Masukkan jumlah kapasitas maksimum Bandwidth server : ");
			int maxBandwidth = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("---------------------------------------------------------------------------------------");

			var setupServer = new SetupCapacityServer(new Bandwidth(maxBandwidth), new Cpu(maxCpu), new Disk(maxDisk), new Memory(maxMemory));
			//setting nilai maximum untuk capasitas sebuah server
			
			Console.Write("Masukkan Jumlah Permintaan Virtual Machine dari User : ");
			int jumlahVirtualMachine = Convert.ToInt32(Console.ReadLine());

			for (int i = 1; i <= jumlahVirtualMachine; i++) {
				string name = $"vm-{i}";
				Console.WriteLine("-----------------------------------------------------");

				Console.WriteLine(name);
				Console.Write("Masukkan jumlah cpu : ");
				int jumlahCpu = Convert.ToInt32(Console.ReadLine());

				Console.Write("Masukkan jumlah Disk : ");
				int jumlahDisk = Convert.ToInt32(Console.ReadLine());
				
				Console.Write("Masukkan jumlah Memory : ");
				int jumlahMemory = Convert.ToInt32(Console.ReadLine());

				Console.Write("Masukkan jumlah Bandwidth : ");
				int jumlahBw = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine("-----------------------------------------------------");

				virtualMachines.Add(new VirtualMachine(name, new Resource {
					Cpu = new Cpu(jumlahCpu),
					Disk = new Disk(jumlahDisk),
					Memory = new Memory(jumlahMemory),
					Bandwidth = new Bandwidth(jumlahBw)
				}));
			}

			//resource manager virtual machine
			ResourceManagerVM resourceManager = new ResourceManagerVM(jumlahVirtualMachine);
			//add virtual machine to resource manager
			resourceManager.AddRangeVirtualMachine(virtualMachines);
			//Console.WriteLine();
			//Console.WriteLine($"Maximum Capacity Server : [{setupServer.CapacityServer.Cpu}, {setupServer.CapacityServer.Memory}, {setupServer.CapacityServer.Disk}, {setupServer.CapacityServer.Bandwidth}]");

			//packing virtual machine ke dalam server
			var serverManagerPlacement = new ServerManagerPlacement(setupServer, resourceManager.VirtualMachines);
			serverManagerPlacement.VMPack();

			Console.WriteLine();
			Console.WriteLine($"Total Virtual Machine : {resourceManager.VirtualMachines.Count()} unit");
			Console.WriteLine($"Total Server yang dibutuhkan : {serverManagerPlacement.Servers.Count} unit");

			Console.WriteLine();
			foreach (var s in serverManagerPlacement.Servers) {
				Console.WriteLine(s.Name);
				Console.WriteLine("---------------------------------------------------------------------------------------");
				foreach (var v in s.VirtualMachines) {
					Console.WriteLine($"| {v.Name} in {s.Name} : [{v.Resource.Cpu}, {v.Resource.Memory}, {v.Resource.Disk},{ v.Resource.Bandwidth}] |");
				}
				Console.WriteLine("---------------------------------------------------------------------------------------");
				Console.WriteLine();
			}
		}
	}
}
