# Virtual Machine Placement
How to Install ?
Before the run, please install .NET 5.0, you can download in https://dotnet.microsoft.com/download

```sh
$ git clone https://github.com/lubisarieff/VirtualMachinePlacement.git
$ cd VirtualMachinePlacement/test/Example/Program.cs
```

Setting untuk virtual machine dan server 
```sh
//setting jumlah virtual machine
int maxVirtualMachine = 10;

//setting nilai maximum untuk capasitas sebuah server
int maxBandwidth = 1000;
int maxCpu = 16;
int maxDisk = 1000;
int maxMemory = 8;
```

Run project
```sh
cd VirtualMachinePlacement
dotnet build VirtualMachinePlacement.sln
cd VirtualMachinePlacement/test/Example
dotnet run
```
